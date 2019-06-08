using System;
using System.Data;
using DbUp.Engine;

namespace dbUpTest.Scripts
{
    class Script0002_InsertB : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            using (var cmd = dbCommandFactory())
            {
                cmd.CommandText = $"INSERT INTO Test (Content) Values ('Insert From {GetType().FullName}')";
                cmd.ExecuteNonQuery();
            }

            return "";
        }
    }
}
