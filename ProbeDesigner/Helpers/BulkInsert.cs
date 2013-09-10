using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace RevolutionProbe.Common
{
    public class BulkInsert
    {
        public static void Insert<T>(string connectionString, string tableName, IList<T> list)
        {
            using (var bulkCopy = new SqlBulkCopy(connectionString))
            {
                bulkCopy.BatchSize = list.Count;
                bulkCopy.DestinationTableName = tableName;

                var table = new DataTable();
                PropertyDescriptor[] props = TypeDescriptor.GetProperties(typeof (T))
                                                           .Cast<PropertyDescriptor>()
                                                           .Where(
                                                               propertyInfo =>
                                                               propertyInfo.PropertyType.Namespace.Equals("System"))
                                                           .ToArray();

                foreach (PropertyDescriptor propertyInfo in props)
                {
                    bulkCopy.ColumnMappings.Add(propertyInfo.Name, propertyInfo.Name);
                    table.Columns.Add(propertyInfo.Name,
                                      Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType);
                }
                var values = new object[props.Length];
                foreach (T item in list)
                {
                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = props[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }
                bulkCopy.WriteToServer(table);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static void Reset(string connectionString, string tableName, int start = 0)
        {
            string queryString = String.Format("delete from {0}",tableName);
            string queryString2 = String.Format("dbcc checkident({0}, reseed, 0)",tableName);

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(queryString, connection);
                command.ExecuteNonQuery();
                command = new SqlCommand(queryString2, connection);
                command.ExecuteNonQuery();
            }

        }
    }
}