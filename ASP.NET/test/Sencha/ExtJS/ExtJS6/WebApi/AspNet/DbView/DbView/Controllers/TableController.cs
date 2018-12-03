using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DbView.Domain;
using DbView.Domain.Interfaces;
using DbView.Models;

namespace DbView.Controllers
{
    public class TableController : ApiController
    {
        private ITable _tableManager;

        public TableController()
        {
            _tableManager = new TableManager();
        }

        [Route("api/data/{tableName}")]
        [HttpGet]
        public object Get(string tableName, [FromUri] GetRequestParams requestParams)
        {
            var table = _tableManager.GetDbSet(tableName);
            //var pageTables = tables.Skip(requestParams.start).Take(requestParams.limit).ToArray();

            if (!requestParams.needMetadata)
                return new { success = true, rows = table };

            var metadata = GetMetadata(tableName);
            return new { success = true, rows = table, metaData = metadata };
        }

        [Route("api/data/{tableName}")]
        [HttpPost]
        public object Post(string tableName, [FromBody] object requestParam)
        {
            return new { success = true };
        }

        private object GetMetadata(string tableName)
        {
            var dbFields = _tableManager.GetFields(tableName);
            return new { root = "rows", clientIdProperty = "id", fields = GetFields(dbFields), columns = GetColumns(tableName, dbFields) };
        }

        private object GetFields(ICollection<Domain.Models.Field> dbFields)
        {
            return dbFields.Select(field => new { name = field.Name, type = GetClientFieldType(field.Type) }).ToArray();
        }

        private object GetColumns(string tableName, ICollection<Domain.Models.Field> dbFields)
        {
            var fieldsWithDescriptions = _tableManager.GetFieldsWithDescriptions(tableName, dbFields);

            return fieldsWithDescriptions.Select(field => new { dataIndex = field.Name, header = field.Description, flex = 1, editor = GetClientEditorType(field.Type), align = GetClientAlign(field.Type) }).ToArray();
        }

        private Type GetFieldType(Type fieldType)
        {
            return fieldType.IsGenericType && fieldType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(fieldType) : fieldType;
        }

        private string GetClientFieldType(Type fieldType)
        {
            string result;

            switch (Type.GetTypeCode(GetFieldType(fieldType)))

            {
                case TypeCode.Boolean:
                {
                    result = "boolean";
                    break;
                }
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                {
                    result = "int";
                    break;
                }
                case TypeCode.Char:
                case TypeCode.String:
                {
                    result = "string";
                    break;
                }
                case TypeCode.DateTime:
                {
                    result = "date";
                    break;
                }
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                {
                    result = "float";
                    break;
                }
                default:
                {
                    result = "auto";
                    break;
                }
            }

            return result;
        }

        private string GetClientEditorType(Type fieldType)
        {
            string result;

            switch (Type.GetTypeCode(GetFieldType(fieldType)))

            {
                case TypeCode.Boolean:
                {
                    result = "checkbox";
                    break;
                }
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                {
                    result = "numberfield";
                    break;
                }
                case TypeCode.Char:
                case TypeCode.String:
                {
                    result = "textfield";
                    break;
                }
                case TypeCode.DateTime:
                {
                    result = "datefield";
                    break;
                }
                default:
                {
                    result = "";
                    break;
                }
            }

            return result;
        }

        private string GetClientAlign(Type fieldType)
        {
            string result;

            switch (Type.GetTypeCode(GetFieldType(fieldType)))

            {
                case TypeCode.Boolean:
                {
                    result = "center";
                    break;
                }
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                {
                    result = "right";
                    break;
                }
                case TypeCode.Char:
                case TypeCode.String:
                {
                    result = "left";
                    break;
                }
                case TypeCode.DateTime:
                {
                    result = "right";
                    break;
                }
                default:
                    {
                        result = "";
                        break;
                    }
            }

            return result;
        }
    }
}
