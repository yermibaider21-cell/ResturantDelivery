using System.Data;
using System.Data.OleDb;

namespace ResturantWebService.ORM
{
    public class DBContext : IDBContext
    {
        OleDbConnection connection; // ליצור קשר עם מסד נתונים (צריך לדעת את סוג מסד הנתונים ומיקום הקובץ במחשב
        OleDbCommand command;//לשלוח פקודות למסד נתונים
        OleDbDataReader reader;
        OleDbTransaction transaction;
        public DBContext()
        {
            this.connection = new OleDbConnection();
            this.connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\ירמי מגמה\פרויקט יב\ResturantDelivery\ResturantWebService\AppData\ResturantDeliveryA.accdb""";
            this.command = new OleDbCommand();
            this.command.Connection = this.connection;
        }

        public void CloseConnection()
        {
            this.connection?.Close(); 
        }

        public void CloseTransaction()
        {
            if (this.transaction != null)
            {
                this.transaction.Dispose();
            }
        }

        public void Commit()
        {
           this.transaction?.Commit();
        }

        public int ChangeData(string sql)
        {
            this.command.CommandText = sql;
            return this.command.ExecuteNonQuery();
        }

      

        public void OpenConnection()
        {
            this.connection.Open();
        }

        public void OpenTransaction()
        {
            this.transaction = this.connection.BeginTransaction();
        }

        public void Rollback()
        {
            this.transaction.Rollback();
        }

        public IDataReader select(string sql)
        {
            this.command.CommandText = sql;
            return this.command.ExecuteReader();
        }

        
    }
}
