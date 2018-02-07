using System;
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

        protected readonly Func<string, string> WrapParameter = (s) => $"@{s}";
        protected readonly Func<string, string> WrapTableField = (s) => $"[{s}]";
        protected readonly Func<string, string> WrapTableFieldParameterCompare = (s) => $"[{s}] = @{s}";

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

        public int Create(T entity)
        {
            int result;
            var parameters = GetObjectProperties(entity, new List<string> { "Id" });
            var intoFields = GetWrappedParameters(parameters, WrapTableField);
            var valueParameters = GetWrappedParameters(parameters, WrapParameter);

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                result = connection.Query<int>(
                    $@"
                    INSERT INTO [dbo].[{this.EntityName}] ({intoFields}) VALUES({valueParameters});
                    SELECT SCOPE_IDENTITY();",
                    entity).FirstOrDefault();
            }

            return result;
        }

        public void Update(T entity)
        {
            var parameters = GetObjectProperties(entity, new List<string> { "Id" });
            var setParams = GetCompareParameters(parameters, ", ");

            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Execute(
                    $@"UPDATE {this.EntityName}
                      SET {setParams}
                      WHERE [id] = @id;",
                    entity);
            }
        }

        protected IList<string> GetObjectProperties(object model, IList<string> ignoreList = null)
        {
            var ignored = (ignoreList ?? new List<string>());

            return model.GetType()
                .GetProperties()
                .Select(p => p.Name)
                .Where(n => !ignored.Contains(n))
                .ToList();
        }

        protected string GetWrappedParameters(IEnumerable<string> parameters, Func<string, string> wrapper, string separator = ", ")
        {
            return string.Join(separator, parameters.Select(wrapper));
        }

        protected string GetCompareParameters(IEnumerable<string> parameters, string separator = " AND ")
        {
            return GetWrappedParameters(parameters, WrapTableFieldParameterCompare, separator);
        }
    }
}
