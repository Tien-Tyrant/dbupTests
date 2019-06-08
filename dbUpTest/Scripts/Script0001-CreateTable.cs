using System;
using System.Data;
using DbUp.Engine;

namespace dbUpTest.Scripts
{
    class Script0001_CreateTable : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            using (var cmd = dbCommandFactory())
            {
                cmd.CommandText = "CREATE TABLE dbup_test( Name TEXT NOT NULL )";
                cmd.ExecuteNonQuery();
            }

            return "";
        }
    }
}
