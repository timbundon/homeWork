using System;
using System.Reflection.PortableExecutable;
using Dapper;
using DapperLesson.Bank;
using DapperLesson.Database;

namespace DapperLesson.Repositories;

class BankRepository: IDisposable {
    private readonly DapperContext dapperContext;
    public BankRepository() {
        dapperContext = new DapperContext();
    }
    public void Transfer(int sender, int reciver, double amount) {
        var conn = dapperContext.DbConnection;
        string query = $"UPDATE \"Client\" SET \"Amount\" = (SELECT \"Amount\" FROM \"Client\" WHERE \"Id\" = {sender}) - {amount} WHERE \"Id\" = {sender};UPDATE \"Client\" SET \"Amount\" = (SELECT \"Amount\" FROM \"Client\" WHERE \"Id\" = {reciver}) + {amount} WHERE \"Id\" = {reciver};";
        conn.Execute(query);
    }
    public void TakeCredit(int id, int amount) {
        var conn = dapperContext.DbConnection;
        string query = $"INSERT INTO \"Credit\"(\"Amount\", \"ClientId\", \"Procent\") VALUES ({amount}, {id}, 1.35)";
        conn.Execute(query);
    }
    public void PayCredit(int id, int amount) {
        var conn = dapperContext.DbConnection;
        string query = 
        @$"
        UPDATE ""Client"" SET ""Amount"" = (SELECT ""Amount"" FROM ""Client"" WHERE ""Id"" = {id}) - {amount} WHERE ""Id"" = {id};
        UPDATE ""Credit"" SET ""Amount"" = (SELECT ""Amount"" FROM ""Credit"" WHERE ""Id"" = {id}) - {amount} WHERE ""Id"" = {id};
        DELETE FROM ""Credit"" WHERE ""Id"" = {id} AND ""Amount"" <= {amount};
        ";
        conn.Execute(query);
    }
    public void Dispose() {
        dapperContext.DbConnection.Dispose();
    }
}