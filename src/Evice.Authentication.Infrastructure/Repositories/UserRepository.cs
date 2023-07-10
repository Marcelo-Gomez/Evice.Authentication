using Dapper;
using Evice.Authentication.Domain.AggregatesModel.UserAggregate;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Evice.Authentication.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration) 
            => this._connectionString = configuration.GetConnectionString("SqlServerDatabase");

        public async Task<bool> AddUser(User user)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(this._connectionString))
                {
                    dbConnection.Open();

                    await dbConnection.ExecuteAsync("");
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(this._connectionString))
                {
                    dbConnection.Open();

                    await dbConnection.ExecuteAsync("");
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUser(string id)
        {
            try
            {
                using (IDbConnection dbConnection = new SqlConnection(this._connectionString))
                {
                    dbConnection.Open();

                    await dbConnection.ExecuteAsync("");
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}