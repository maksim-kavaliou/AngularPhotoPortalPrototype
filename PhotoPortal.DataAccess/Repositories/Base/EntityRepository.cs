using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using PhotoPortal.DataAccess.Interfaces.Repositories.Base;
using PhotoPortal.DomainEntities.Entities.Base;
using PhotoPortal.Infrastructure.Interfaces;

namespace PhotoPortal.DataAccess.Repositories.Base
{
    public abstract class EntityRepository<T> : BaseRepository, IEntityRepository<T>
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

        public IList<T> GetListByParameters(IList<string> parametersList = null, object param = null, string parametersSeparator = "AND")
        {
            var whereQuery = string.Empty;
            if (parametersList != null && parametersList.Any())
            {
                var parameters = string.Join($" {parametersSeparator} ", parametersList.Select(p => $"[{p}] = @{p}").ToList());

                whereQuery = $" WHERE {parameters}";
            }

            IList<T> result;
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                result = connection.Query<T>($"SELECT * FROM [dbo].[{this.EntityName}] {whereQuery}", param ?? new {}).ToList();
            }

            return result;
        }
    }
}
