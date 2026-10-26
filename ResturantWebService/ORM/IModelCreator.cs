using System.Data;

namespace ResturantWebService.ORM
{
    public interface IModelCreator<T>
    {
        T CreateModel(IDataReader dataReader);
    }
}
