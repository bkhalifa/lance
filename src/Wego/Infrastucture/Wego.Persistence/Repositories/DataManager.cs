//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;

//using System.Data.Common;
//using System.Data;
//using System.Dynamic;
//using System.Globalization;

//using Wego.Application.Contracts.Persistence;
//using Wego.Persistence.EF;

//namespace Wego.Persistence.Respositories
//{
//    public class DataManager : IDataManager
//    {
//        private readonly PortoDbContext _dbContext;
//        public DataManager(PortoDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }
//        public async Task<List<TEntity>> GetListAsync<TEntity>(string storedProcedure, IEnumerable<SqlParameter> parameters, CancellationToken cancellationToken = default) where TEntity : class
//        {
//            _dbContext.Database.OpenConnection();

//            using var command = _dbContext.Database.GetDbConnection().CreateCommand();
//            command.CommandText = storedProcedure;
//            command.CommandType = CommandType.StoredProcedure;
//            command.CommandTimeout = 1000;
//            command.Parameters.AddRange(GetParameterArray(parameters));

//            using CancellationTokenRegistration ctr = cancellationToken.Register(() => command.Cancel());
//            using var dataReader = await command.ExecuteReaderAsync(cancellationToken);

//            return await DataReaderToListAsync<TEntity>(dataReader, cancellationToken);

//        }
//        private async Task<List<T>> DataReaderToListAsync<T>(DbDataReader dr, CancellationToken cancellationToken)
//        {
//            var columnDictionary = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
//            for (var i = 0; i < dr?.FieldCount; i++)
//            {
//                columnDictionary.Add(dr.GetName(i));
//            }

//            var list = new List<T>();
//            while (await dr.ReadAsync(cancellationToken))
//            {
//                if (typeof(T).IsValueType)
//                {
//                    list.Add((T)Convert.ChangeType(dr[0], typeof(T), CultureInfo.InvariantCulture));
//                }
//                else
//                {
//                    var entity = Activator.CreateInstance<T>();
//                    if (entity.GetType().GetProperties().Length == 0)
//                    {
//                        dynamic dynamicObject = new ExpandoObject();
//                        foreach (var columnName in columnDictionary)
//                        {
//                            ((IDictionary<string, object>)dynamicObject)[columnName] = dr[columnName];
//                        }
//                        entity = dynamicObject;
//                    }
//                    else
//                    {
//                        foreach (var property in entity.GetType().GetProperties())
//                        {
//                            var propertyFound = false;
//                            var hasColumnDefinition = false;

//                            var columnName = property.Name;

//                            var attributes = property.GetCustomAttributes(true);
//                            foreach (var attribute in attributes)
//                            {
//                                if (attribute is System.ComponentModel.DataAnnotations.Schema.ColumnAttribute column && column.Name != null)
//                                {
//                                    hasColumnDefinition = true;
//                                    if (columnDictionary.Contains(column.Name))
//                                    {
//                                        columnName = column.Name;
//                                        propertyFound = true;
//                                    }
//                                }
//                            }

//                            if (!propertyFound && !columnDictionary.Contains(property.Name) || object.Equals(dr[columnName], DBNull.Value) || hasColumnDefinition && !propertyFound) continue;

//                            var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
//                            if (type.IsEnum)
//                            {
//                                var value = Enum.Parse(type, dr[columnName].ToString());
//                                property.SetValue(entity, value, null);
//                            }
//                            else if (type == typeof(string) && dr.GetFieldType(dr.GetOrdinal(columnName)) == typeof(Guid))
//                                property.SetValue(entity, dr[columnName]?.ToString(), null);
//                            else if (type == typeof(Guid) && dr.GetFieldType(dr.GetOrdinal(columnName)) == typeof(string))
//                                property.SetValue(entity, new Guid(dr[columnName]?.ToString()), null);
//                            else
//                                property.SetValue(entity, Convert.ChangeType(dr[columnName], type), null);
//                        }
//                    }
//                    list.Add(entity);
//                }
//            }

//            return list;
//        }
//        private static SqlParameter[] GetParameterArray(IEnumerable<SqlParameter> parameters)
//        {
//            var res = parameters.ToArray();
//            foreach (var parameter in res)
//            {
//                if (parameter.Value == null)
//                    parameter.Value = DBNull.Value;
//            }
//            return res;
//        }
//    }
//}
