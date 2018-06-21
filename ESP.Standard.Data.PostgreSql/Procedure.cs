using System;
using System.Data;
using ESP.Standard.Data.PostgreSql.Exceptions;
using Npgsql;

namespace ESP.Standard.Data.PostgreSql
{


    /// <summary>
    /// Wraps the execution of a stored procedure.
    /// </summary>
    public static class Procedure
    {
        /// <summary>
        /// Executes and returns an open IRecordSet, which encapsulates an OPEN DATAREADER.  DISPOSE IN FINALLY CLAUSE.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="procedureName"></param>
        /// <param name="parameterMapper"></param>
        /// <returns></returns>
        /// <param name="objectInstance"></param>
        public static IRecordSet Execute<T>(Database database, string procedureName, 
            ParameterMapper<T> parameterMapper, T objectInstance)
        {

            NpgsqlConnection connection = database.GetConnection();
            NpgsqlCommand command = CommandFactory.CreateParameterMappedCommand<T>(
                connection, database.InstanceName, procedureName, parameterMapper, objectInstance);

            try
            {

                command.Connection.Open();
                IRecordSet record = new DataRecord(command.ExecuteReader(CommandBehavior.CloseConnection));
                return record;
            }
            catch (Exception exc)
            {
                command.Connection.Close();

                throw new DatabaseExecutionException(database, procedureName, command, exc);

            }
        }

        private const string LOG_PREFIX = "DB_CALL_LOG - Procedure";

        /// <summary>
        /// Executes and returns an open IRecordSet, which encapsulates an OPEN DATAREADER.  DISPOSE IN FINALLY CLAUSE.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="procedureName"></param>
        /// <param name="parameterMapper"></param>
        /// <returns></returns>
        public static IRecordSet Execute(Database database, string procedureName, ParameterMapper parameterMapper)
        {

            NpgsqlConnection connection = database.GetConnection();
			NpgsqlCommand command = CommandFactory.CreateParameterMappedCommand(connection, database.InstanceName, procedureName, parameterMapper);

            try
            {
                command.Connection.Open();
                IRecordSet record = new DataRecord(command.ExecuteReader(CommandBehavior.CloseConnection));
                return record;
            }
            catch(Exception exc)
            {
                command.Connection.Close();
                throw new DatabaseExecutionException(database, procedureName, command, exc);
            }
        }

        /// <summary>
        /// Executes and returns an open IRecordSet, which encapsulates an OPEN DATAREADER.  DISPOSE IN FINALLY CLAUSE.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IRecordSet Execute(Database database, string procedureName, params object[] parameters)
        {
            IRecordSet recordSet;

            NpgsqlConnection connection = database.GetConnection();

			NpgsqlCommand command = CommandFactory.CreateCommand(connection, database.InstanceName, procedureName, parameters);
            try
            {

                connection.Open();
                recordSet = new DataRecord(command.ExecuteReader(CommandBehavior.CloseConnection));
                return recordSet;
            }
            catch(Exception exc)
            {
                connection.Close();

                throw new DatabaseExecutionException(database, procedureName, command, exc);
            }
        }
        /// <summary>
        /// wzg添加
        /// </summary>
        /// <param name="database"></param>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IRecordSet Execute(Database database, string procedureName, NpgsqlParameter[] parameters)
        {

            IRecordSet recordSet;
            NpgsqlConnection connection = database.GetConnection();

            
            NpgsqlCommand command = CommandFactory.CreateCommand(connection, database.InstanceName, procedureName, parameters);
            
            try
            {

                connection.Open();
                recordSet = new DataRecord(command.ExecuteReader(CommandBehavior.CloseConnection));
                return recordSet;
            }
            catch (Exception exc)
            {
                connection.Close();

                throw new DatabaseExecutionException(database, procedureName, command, exc);
            }
        }

    
        /// <summary>
        /// Assembly-scoped class for returning a DataReader
        /// </summary>
        /// <param name="database"></param>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        internal static IDataReader ExecuteReader(Database database, string procedureName, params object[] parameters)
        {
            IDataReader reader;

            NpgsqlConnection connection = database.GetConnection();
			NpgsqlCommand command = CommandFactory.CreateCommand(connection, database.InstanceName, procedureName, parameters);

            try
            {

                connection.Open();
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                return reader;
            }
            catch(Exception exc)
            {
                connection.Close();

                throw new DatabaseExecutionException(database, procedureName, command, exc);
            }
        }


        /// <summary>
        /// Assembly-scoped class for returning a DataReader.
        /// </summary>
        /// <param name="database"></param>
        /// <param name="procedureName"></param>
        /// <param name="parameterMapper"></param>
        /// <returns></returns>
           internal static IDataReader ExecuteReader(Database database, string procedureName, ParameterMapper parameterMapper)
           {

               NpgsqlConnection connection = database.GetConnection();
			   NpgsqlCommand command = CommandFactory.CreateParameterMappedCommand(connection, database.InstanceName, procedureName, parameterMapper);

               try
               {

                   command.Connection.Open();
                   IDataReader record = command.ExecuteReader(CommandBehavior.CloseConnection);
                   return record;
               }
               catch(Exception exc)
               {
                   command.Connection.Close();

                   throw new DatabaseExecutionException(database, procedureName, command, exc);
               }
           }
    }
}
