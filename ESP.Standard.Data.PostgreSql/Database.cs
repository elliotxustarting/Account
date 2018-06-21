using System;
using System.Collections.Generic;
using System.Text;
using ESP.Standard.Data.PostgreSql.Exceptions;
using Npgsql;

namespace ESP.Standard.Data.PostgreSql
{
    internal class DatabaseCollection : System.Collections.ObjectModel.KeyedCollection<string, Database>
    {
        public DatabaseCollection():base(StringComparer.OrdinalIgnoreCase)
        {
        }

        /// <summary>
        /// Returns the database instance name.
        /// </summary>
        protected override string GetKeyForItem(Database item)
        {
            return item.InstanceName;
        }

    }

    /// <summary>
    /// Encapsulates information about a particular database and its connectivity.
    /// </summary>
    [Serializable]
    public class Database
    {
        private string connectionString;
        
        private string connectionStringAsync;

        internal void SetConnectionString(string connString)
        {
            this.connectionString = connString;
            this.connectionStringAsync = connString + ";async=true;";
        }

        internal Database(string instanceName)
        {
            this.instanceName = instanceName;

            try
            {
                SetConnectionString(ConnectionStringInitializer.GetConnectionString(instanceName));          
            }
            catch
            {
                throw new DatabaseNotConfiguredException(instanceName);
            }

        }

        private Database()
        {

        }

		/// <summary>
        /// The name of the database.
        /// </summary>
        private string instanceName;       


        /// <summary>
        /// The name of the database
        /// </summary>
        public string InstanceName
        {
            get
            {
                return instanceName;
            }
           
        }

        /// <summary>
        /// Retrieves the connection string.
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return connectionString;
        }

        public string GetAsyncConnectionString()
        {
            return connectionStringAsync;
        }

        public NpgsqlConnection GetAsyncConnection()
        {
            return new NpgsqlConnection(GetAsyncConnectionString());
        }

        /// <summary>
        /// Returns a closed SQL connection.
        /// </summary>
        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(GetConnectionString());
        }

		public NpgsqlConnection GetOpenConnection()
		{
			NpgsqlConnection connection = new NpgsqlConnection(GetConnectionString());
			connection.Open();
			return connection;
		}

        /// <summary>
        /// Returns a Database instance.
        /// </summary>
        /// <param name="instanceName">The name of the database (reflected in the ConnectionStrings section of the app config)</param>
        /// <example>  
        /// Database db = Database.GetDatabase("Films");
		///	</example>
        public static Database GetDatabase(string instanceName)
        {
            return DatabaseManager.Instance.GetDatabase(instanceName);
        }


        /// <summary>
        /// Get all registered Database instances (one per database).
        /// </summary>
        /// <returns></returns>
        public static List<Database> GetDatabases() => new List<Database>(DatabaseManager.Instance.Databases);

        /// <summary>
        /// Retrieve a CLOSED NpgsqlConnection object via an instance name.
        /// </summary>
        /// <param name="instanceName"></param>
        /// <returns></returns>
        public static NpgsqlConnection GetConnection(string instanceName)
        {
            return GetDatabase(instanceName).GetConnection();
        }
    }
}
