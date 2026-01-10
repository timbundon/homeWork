using System;
using System.Data;
using Npgsql;

namespace DapperLesson.Database;

class DapperContext {
    private readonly IDbConnection dbConnection;
    public DapperContext() {
        dbConnection = new NpgsqlConnection("Server=localhost; Port=5432; Username=postgres; Password=123; Database=StepBank");
    }
    public IDbConnection DbConnection => dbConnection;
}