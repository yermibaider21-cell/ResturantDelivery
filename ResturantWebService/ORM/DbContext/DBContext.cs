using System.Data;
using System.Data.OleDb;

namespace ResturantWebService.ORM.DbContext
{
    public class DBContext : IDBContext
    {
        OleDbConnection connection; // ליצור קשר עם מסד נתונים (צריך לדעת את סוג מסד הנתונים ומיקום הקובץ במחשב
        OleDbCommand command;//לשלוח פקודות למסד נתונים
        OleDbDataReader reader;
        OleDbTransaction transaction;
        public DBContext()
        {
            connection = new OleDbConnection();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\ירמי מגמה\פרויקט יב\ResturantDelivery\ResturantWebService\AppData\ResturantDeliveryA.accdb""";
            command = new OleDbCommand();
            command.Connection = connection;
        }

        public void CloseConnection()
        {
            connection?.Close(); 
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
            }
        }

        public void Commit()
        {
           transaction?.Commit();
        }

        public int ChangeData(string sql)
        {
            command.CommandText = sql;
            return command.ExecuteNonQuery();
        }

      

        public void OpenConnection()
        {
            connection.Open();
        }

        public void OpenTransaction()
        {
            transaction = connection.BeginTransaction();
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public IDataReader select(string sql)
        {
            command.CommandText = sql;
            return command.ExecuteReader();
        }

        
    }
}
