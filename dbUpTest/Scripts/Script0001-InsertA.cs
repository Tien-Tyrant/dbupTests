using System;
using System.Data;
using DbUp.Engine;

namespace dbUpTest.Scripts
{
    class Script0001_CreateTable : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            var cmd = dbCommandFactory();
                cmd.CommandText = $"INSERT INTO Test (Content) Values ('Insert From {GetType().FullName}')";
                cmd.ExecuteNonQuery();

            return "";
        }
    }
}
