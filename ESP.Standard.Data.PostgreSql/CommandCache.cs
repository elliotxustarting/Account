using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace ESP.Standard.Data.PostgreSql
{
    class CommandCache : Dictionary<string, NpgsqlCommand>
    {
        internal NpgsqlCommand GetCommandCopy(NpgsqlConnection connection, string databaseInstanceName, string procedureName)
        {
            NpgsqlCommand copiedCommand;
			string commandCacheKey = databaseInstanceName + procedureName;

			if (!this.ContainsKey(commandCacheKey))
            {
                NpgsqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;

				if(connection.State != ConnectionState.Open)
					connection.Open();
                NpgsqlCommandBuilder.DeriveParameters(command);
                connection.Close();

                lock (this)
                {
					this[commandCacheKey] = command;
                }
            }

			copiedCommand = this[commandCacheKey].Clone();
            copiedCommand.Connection = connection;
            return copiedCommand;
        }
    }
}
