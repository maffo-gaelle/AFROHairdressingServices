using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairdressingServices.Tools
{
    public class Connection
    {
        private readonly DbProviderFactory _providerFactory;
        private readonly string _connectionString;

        public Connection(DbProviderFactory providerFactory, string connectionString)
        {
            _providerFactory = providerFactory;
            _connectionString = connectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(Command command)
        {
            using(DbConnection dbConnection = CreateConnection())
            {
                using(DbCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    dbConnection.Open();
                    return dbCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="command"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public IEnumerable<TResult> ExecuteReader<TResult>(Command command, Func<IDataRecord, TResult> selector)
        {
            using (DbConnection dbConnection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    dbConnection.Open();

                    using (DbDataReader dbDataReader = dbCommand.ExecuteReader())
                    {
                        while (dbDataReader.Read())
                        {
                            yield return selector(dbDataReader);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public object ExecuteScalar(Command command)
        {
            using (DbConnection dbConnection = CreateConnection())
            {
                using DbCommand dbCommand = CreateCommand(command, dbConnection);
                dbConnection.Open();
                object o = dbCommand.ExecuteScalar();
                return o is DBNull ? null : o;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataTable GetDataTable(Command command)
        {
            using (DbConnection dbConnection = CreateConnection())
            {
                using (DbCommand dbCommand = CreateCommand(command, dbConnection))
                {
                    using DbDataAdapter dbDataAdapter = _providerFactory.CreateDataAdapter();
                    dbDataAdapter.SelectCommand = dbCommand;
                    DataTable dataTable = new DataTable();
                    dbDataAdapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="dbConnection"></param>
        /// <returns></returns>
        private DbCommand CreateCommand(Command command, DbConnection dbConnection)
        {
            DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = command.Query;

            if (command.IsStoredProcedure)
                dbCommand.CommandType = CommandType.StoredProcedure;

            foreach(KeyValuePair<string, object> kvp in command.Parameters)
            {
                DbParameter dbParameter = dbCommand.CreateParameter();
                dbParameter.ParameterName = kvp.Key;
                dbParameter.Value = kvp.Value;

                dbCommand.Parameters.Add(dbParameter);
            }
            return dbCommand;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DbConnection CreateConnection()
        {
            DbConnection dbConnection = _providerFactory.CreateConnection();
            dbConnection.ConnectionString = _connectionString;

            return dbConnection;
        }
    }
}
