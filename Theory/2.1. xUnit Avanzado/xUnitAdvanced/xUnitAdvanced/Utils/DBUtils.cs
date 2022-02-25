using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitAdvanced.Utils
{
    public class DBUtils
    {
        public static int ExecuteNonQuery(SqlConnection db,
                                        string sqlQuery,
                                        SqlParameter[] param = null,
                                        SqlTransaction tran = null)
        {
            SqlCommand command = db.CreateCommand();
            command.CommandText = sqlQuery;
            if (param != null) command.Parameters.AddRange(param);
            if (tran != null) command.Transaction = tran;

            return command.ExecuteNonQuery();
        }

        public static object ExecuteScalar(SqlConnection db, 
                                        string sqlQuery,
                                        SqlParameter[] param = null,
                                        SqlTransaction tran = null)
        {
            SqlCommand command = db.CreateCommand();
            command.CommandText = sqlQuery;
            if (param != null) command.Parameters.AddRange(param);
            if (tran != null) command.Transaction = tran;

            return command.ExecuteScalar();
        }

        public static List<T> ExecuteReaderToList<T>(SqlConnection db,
                                        string sqlQuery) 
            where T : IEntity<T>, new()
        {
            List<T> result = new List<T>();
            SqlCommand command = db.CreateCommand();
            command.CommandText = sqlQuery;

            var objT = new T();
            using (var dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    result.Add(objT.GetEntity(dataReader));
                }
            }

            return result;
        }
    }
}
