﻿using IUMS.Application.Interfaces.Contexts;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace IUMS.Infrastructure.DbContexts
{
    public class DapperContext : IDapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("ApplicationConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
