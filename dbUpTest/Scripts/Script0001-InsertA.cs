using System;
using System.Data;
using Dapper;
using DbUp.Engine;

namespace dbUpTest.Scripts
{
    class Script0001_CreateTable : IScript
    {
        public string ProvideScript(Func<IDbCommand> dbCommandFactory)
        {
            var cmd = dbCommandFactory();
            var values = cmd.Connection.Query<Result>("Select * From Test");

            return "";
        }

        class Result
        {
            public int Id { get; set; }
            public string content { get; set; }
        }
    }
}
