using System.Data;

namespace ResturantWebService.ORM.DbContext
{
    public interface IDBContext
    {
        void OpenConnection();
        void CloseConnection();
        IDataReader select(string sql);
        int ChangeData(string sql);
        void OpenTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
    }
}
