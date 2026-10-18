#nullable enable

using DTOResturant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DTOResturant.Models.Models
{
    public abstract class Model : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> errors =
            new Dictionary<string, List<string>>();

        private bool isNeedValidate;

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public bool HasErrors => errors.Count > 0;
        public bool IsValid => !HasErrors;

        public bool IsNeedValidate
        {
            get => isNeedValidate;
            set
            {
                if (isNeedValidate == value)
                    return;

                isNeedValidate = value;

                if (value)
                    Validate();
                else
                    ClearErrors();

                RaisePropertyChanged(nameof(IsNeedValidate));
            }
        }

        public void OnPropertyChanged(
            [CallerMemberName] string propertyName = "")
        {
            if (IsNeedValidate)
            {
                var property = GetType().GetProperty(propertyName);

                if (property != null)
                    ValidateProperty(property.GetValue(this), propertyName);
            }

            RaisePropertyChanged(propertyName);
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(
                this, new DataErrorsChangedEventArgs(propertyName));

            RaisePropertyChanged(nameof(HasErrors));
            RaisePropertyChanged(nameof(IsValid));
        }

        public IEnumerable GetErrors(string? propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return errors.Values.SelectMany(x => x).ToArray();

            if (errors.TryGetValue(propertyName, out var messages))
                return messages.ToArray();

            return Array.Empty<string>();
        }

        public Dictionary<string, List<string>> AllErrors()
        {
            return errors.ToDictionary(
                x => x.Key, x => new List<string>(x.Value));
        }

        public void ValidateProperty(
            object? value,
            [CallerMemberName] string propertyName = "")
        {
            if (!IsNeedValidate)
                return;

            var context = new ValidationContext(this)
            {
                MemberName = propertyName
            };

            var results = new List<ValidationResult>();
            Validator.TryValidateProperty(value, context, results);

            errors.Remove(propertyName);

            if (results.Count > 0)
            {
                errors[propertyName] = results
                    .Select(x => x.ErrorMessage ?? "ערך לא תקין.")
                    .Distinct()
                    .ToList();
            }

            OnErrorsChanged(propertyName);
        }

        public void Validate()
        {
            if (!IsNeedValidate)
                return;

            var results = new List<ValidationResult>();

            Validator.TryValidateObject(
                this,
                new ValidationContext(this),
                results,
                validateAllProperties: true);

            var changedProperties = new HashSet<string>(errors.Keys);
            errors.Clear();

            foreach (var result in results)
            {
                foreach (var propertyName in
                    result.MemberNames.DefaultIfEmpty(string.Empty))
                {
                    if (!errors.ContainsKey(propertyName))
                        errors[propertyName] = new List<string>();

                    errors[propertyName].Add(
                        result.ErrorMessage ?? "ערך לא תקין.");
                    changedProperties.Add(propertyName);
                }
            }

            foreach (var propertyName in changedProperties)
                OnErrorsChanged(propertyName);
        }

        private void ClearErrors()
        {
            var propertyNames = errors.Keys.ToArray();
            errors.Clear();

            foreach (var propertyName in propertyNames)
                OnErrorsChanged(propertyName);
        }
    }
}
