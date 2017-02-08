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
            return GetListByParameters(new string[] { "Id" }, new { Id = id }).FirstOrDefault();
        }

        public IList<T> GetListByParameters(IEnumerable<string> parametersList, object param, string parametersSeparator = "AND")
        {
            var parameters = string.Join($" {parametersSeparator} ", parametersList.Select(p => $"[{p}] = @{p}").ToList());

            IList<T> result;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                result = connection.Query<T>($"SELECT * FROM [dbo].[{this.EntityName}] WHERE {parameters}", param).ToList();
            }

            return result;
        }
    }
}
