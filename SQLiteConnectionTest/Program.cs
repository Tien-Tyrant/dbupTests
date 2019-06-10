using System;
using System.Data;
using System.Data.SQLite;

namespace SQLiteConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source='E:\projects\dbuptest\SQLiteDb\test_db.db'";

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                var result = Execute(Insert, conn);
            }
        }

        private static string Execute(Func<Func<IDbCommand>, string> actionWithResult, IDbConnection dbConnection)
        {

            using (var tran = dbConnection.BeginTransaction())
            {
                var result = actionWithResult(() =>
                {
                    var command = dbConnection.CreateCommand();
                    command.Transaction = tran;
                    return command;
                });
                tran.Commit();
                return result;
            }
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
