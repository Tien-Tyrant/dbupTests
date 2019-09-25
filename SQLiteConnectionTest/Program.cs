using System;
using System.Data;
using System.Data.SQLite;

namespace SQLiteConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source='C:\projects\dbuptest\SQLiteDb\test_db.db'";

            var conn = new SQLiteConnection(connectionString);
                conn.Open();

            using (var tran = conn.BeginTransaction())
            {
                var result = Insert(() =>
                {
                    var command = conn.CreateCommand();
                    command.Transaction = tran;
                    return command;
                });
                tran.Commit();
            }

            conn.Dispose();

            using (var tran = conn.BeginTransaction())
            {
                var result = Insert(() =>
                {
                    var command = conn.CreateCommand();
                    command.Transaction = tran;
                    return command;
                });
                tran.Commit();
            }
        }

        private static string Execute(Func<Func<IDbCommand>, string> actionWithResult, IDbConnection dbConnection)
        {

           


            return string.Empty;
        }

        private static string Insert(Func<IDbCommand> cmdFactory)
        {
            var cmd = cmdFactory();
            cmd.CommandText = $"INSERT INTO Test (Content) Values ('Insert From conn test {DateTime.Now.ToString()}')";
            cmd.ExecuteNonQuery();
            return $"INSERT INTO Test (Content) Values ('Insert From conn test {DateTime.Now.ToString()}')";
        }
    }
}
