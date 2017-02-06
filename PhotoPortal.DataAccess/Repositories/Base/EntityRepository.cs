using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using PhotoPortal.DomainEntities.Entities;
using PhotoPortal.DomainEntities.Entities.Base;
using PhotoPortal.Infrastructure.Interfaces;

namespace PhotoPortal.DataAccess.Repositories.Base
{
    public abstract class EntityRepository<T> : BaseRepository
        where T : BaseEntity
    {
        protected readonly string EntityName;

        protected EntityRepository(IConfigurationManager configurationManager, string entityName)
            : base(configurationManager)
        {
            this.EntityName = entityName;
        }

        public T Get(int id)
        {
            T result;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                result = connection.Query<T>($"SELECT * FROM [dbo].[{this.EntityName}] WHERE Id = @id", new { id }).FirstOrDefault();
            }

            return result;
        }
    }
}
