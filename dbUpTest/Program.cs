using System;
using System.Reflection;
using DbUp;

namespace dbUpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source='E:\projects\dbuptest\SQLiteDb\test_db.db'";

            var upgrader =
                DeployChanges.To
                    .SQLiteDatabase(connectionString)
                    .WithScriptsAndCodeEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .WithTransactionPerScript()
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();

            Console.ReadLine();
        }
    }
}
