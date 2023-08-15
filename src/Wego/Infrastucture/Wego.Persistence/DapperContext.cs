

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

using System.Data;

namespace Wego.Persistence;

public sealed class DapperContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("portoDB");
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
}
