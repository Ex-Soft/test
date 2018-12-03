using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using DbView.Domain.Interfaces;
using DbView.Domain.Helpers;
using DbView.Domain.Models;

namespace DbView.Domain
{
    public class TableManager : ITable
    {
        public DbSet GetDbSet(string tableName)
        {
            return GetDbSet(CreateTableType(tableName));
        }

        public ICollection<Field> GetFields(string tableName)
        {
            return MsSqlDbHelper.Instance.GetFields(tableName);
        }

        public ICollection<Field> GetFieldsWithDescriptions(string tableName, ICollection<Field> dbFields = null)
        {
            if (dbFields == null)
                dbFields = GetFields(tableName);

            var fieldsDescriptions = MsSqlDbHelper.Instance.GetFieldsDescriptions(tableName);

            return dbFields.GroupJoin(fieldsDescriptions, dbField => dbField.Name, fieldDescription => fieldDescription.Name, (dbField, listFieldsDescriptions) => new { dbField.Name, dbField.Type, dbField.IsKey, Description = listFieldsDescriptions.Select(field => field.Description) })
                .SelectMany(groupJoinItem => groupJoinItem.Description.DefaultIfEmpty(), (groupJoinItem, Description) => new Field(groupJoinItem.Name, groupJoinItem.Type, groupJoinItem.IsKey, Description)).ToArray();
        }

        private Type CreateTableType(string tableName)
        {
            var fields = GetFields(tableName);
            return fields.Count != 0 ? TableTypeBuilder.CompileResultType(tableName, fields) : null;
        }

        private DbSet GetDbSet(Type tableType)
        {
            var builder = new DbModelBuilder(DbModelBuilderVersion.Latest);
            builder.Conventions.Remove<PluralizingTableNameConvention>();
            var method = builder.GetType().GetMethod("Entity");
            method = method.MakeGenericMethod(tableType);
            method.Invoke(builder, null);

            var connection = new SqlConnection(MsSqlDbHelper.Instance.ConnectionString);
            var dbModel = builder.Build(connection);
            var dbCompiledModel = dbModel.Compile();
            var dbContext = new DbViewContext(connection, dbCompiledModel, false);
            return dbContext.Set(tableType);
        }
    }
}
