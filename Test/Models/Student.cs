using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Models
{
    internal class Student : User, IStudy
    {
        public List<string> Subjects { get; set; } 
        public List<string> Grades { get; set; }

        public virtual void GetStaff()
        {
            Console.WriteLine($" I am {Name}, I get Pen");
        }

        public virtual void Study()
        {
            Console.WriteLine($"At the lesson I study");
        }
    }
}
