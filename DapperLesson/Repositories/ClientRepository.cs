using System;
using Dapper;
using DapperLesson.Bank;
using DapperLesson.Database;

namespace DapperLesson.Repositories;

class ClientRepository: IDisposable {
    private readonly DapperContext dapperContext;
    public ClientRepository() {
        dapperContext = new DapperContext();
    }
    public IEnumerable<Client> Get() {
        var conn = dapperContext.DbConnection;
        string query = "SELECT * FROM \"Client\"";
        return conn.Query<Client>(query);
    }
    public Client GetById(int Id) {
        var conn = dapperContext.DbConnection;
        string query = $"SELECT * FROM \"Client\" WHERE \"Id\" = {Id}";
        return conn.QueryFirst<Client>(query);
    }
    public void Create(Client client) {
        var conn = dapperContext.DbConnection;
        string query = $"INSERT INTO \"Client\"(\"Name\", \"Surname\") VALUES ('{client.Name}', '{client.Surname}')";
        conn.Execute(query);
    }
    public void Delete(int id) {
        var conn = dapperContext.DbConnection;
        string query = $"DELETE FROM \"Client\" WHERE \"Id\" = {id}";
        conn.Execute(query);
    }
    public void Update(int id, string property, string value) {
        var conn = dapperContext.DbConnection;
        string query = $"UPDATE \"Client\" SET \"{property}\" = \'{value}\'";
        conn.Execute(query);
    }
    public void Dispose() {
        dapperContext.DbConnection.Dispose();
    }
}