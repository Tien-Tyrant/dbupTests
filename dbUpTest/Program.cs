using System;
using System.Reflection;
using DbUp;

namespace dbUpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Server=LAPTOP-1MAFGC2H\INEDO;Database=Test_dbup;MultipleActiveResultSets=true;Connection Timeout=120";

            var builder =
                DeployChanges.To
                    .SqlDatabase(connectionString);

            var upgrader = builder
                .WithScriptsAndCodeEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .WithTransactionPerScript()
                .LogToConsole()
                .Build();

            //var scripts = upgrader.GetScriptsToExecute().ToArray();
            //foreach (var s in scripts)
            //{
            //    Console.WriteLine(s.Contents);
            //}
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
