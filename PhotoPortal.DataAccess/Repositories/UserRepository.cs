using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using PhotoPortal.DataAccess.Interfaces.Repositories;
using PhotoPortal.DataAccess.Repositories.Base;
using PhotoPortal.DomainEntities.Entities;
using PhotoPortal.Infrastructure.Interfaces;

namespace PhotoPortal.DataAccess.Repositories
{
    public class UserRepository : EntityRepository<User>, IUserRepository
    {
        public UserRepository(IConfigurationManager configurationManager)
            : base(configurationManager, "User")
        {
        }

        public void Create(User user)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(
                    @"
                    INSERT INTO [dbo].[User] ([Name], [Email], [Password])
                    VALUES(@Name, @Email, @Password)",
                    user);
            }
        }

        public User GetByEmail(string email)
        {
            return GetListByParameters(new string[] { "Email" }, new { Email = email }).FirstOrDefault();
        }

        public User Authenticate(string email, string password)
        {
            return GetListByParameters(new string[] { "Email", "Password" }, new { Email = email, Password = password }).FirstOrDefault();
        }
    }
}