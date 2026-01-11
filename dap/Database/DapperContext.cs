using System;
using System.Data;
using Npgsql;

namespace dap.Database;

class DapperContext {
    private readonly IDbConnection dbConnection;
    public DapperContext() {
        dbConnection = new NpgsqlConnection("Server=localhost; Port=5432; Username=postgres; Password=1234; Database=test");
    }
    public IDbConnection DbConnection => dbConnection;
}