using System;
using System.Collections.Concurrent;

namespace ESP.Standard.Data.PostgreSql
{
    public static class ConnectionStringInitializer
    {
        private static ConcurrentDictionary<string, string> _instanceMapper;

        static ConnectionStringInitializer()
        {
            _instanceMapper = new ConcurrentDictionary<string, string>();
        }

        public static void Init(ConcurrentDictionary<string, string> instanceMapper)
        {
            _instanceMapper = instanceMapper;
        }

        public static string GetConnectionString(string instance)
        {
            string connectionString = null;
            _instanceMapper.TryGetValue(instance, out connectionString);
            return connectionString;
        }
    }
}
