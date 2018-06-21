using System;
using System.Text;
using Npgsql;

namespace ESP.Standard.Data.PostgreSql
{
    /// <summary>
    /// Debug Output Utility class
    /// </summary>
    public static class DebugUtil
    {
        /// <summary>
        /// Returns string representation of object array
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetParameterString(object[] parameters)
        {
            string ret = string.Empty;

            if (parameters == null) return ret;

            try
            {
                var builder = new StringBuilder();
                foreach (object obj in parameters)
                {
                    builder.Append($"{{{GetDebugParamValue(obj)}}}");
                    //ret += "{" + GetDebugParamValue(obj) + "}";
                }
                ret = builder.ToString();
            }
            catch (Exception) { return "!error!"; }

            return ret;
        }

        /// <summary>
        /// Returns string representation of int array
        /// </summary>
        /// <param name="parameters">Int array</param>
        /// <returns>String</returns>
        public static string GetParameterString(int[] parameters)
        {
            string ret = string.Empty;

            if (parameters == null) return ret;

            try
            {
                var builder = new StringBuilder();
                foreach (int param in parameters)
                {
                    builder.Append($"{{{param.ToString()}}}");
                    //ret += "{" + param.ToString() + "}";
                }
                ret = builder.ToString();
            }
            catch (Exception) { return "!error!"; }

            return ret;
        }

        /// <summary>
        /// Returns string representation of object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDebugParamValue(object value)
        {
            if (value == null) return "null";

            try
            {
                // Truncate long strings
                if (value is string)
                {
                    string strVal = (string)value;
                    if (strVal == null)
                        return string.Empty;

                    if (strVal.Length > 20)
                        return strVal.Substring(0, 20) + "...";
                    else
                        return strVal;
                }

                var type = value.GetType();

                if (type.IsPrimitive || type.IsValueType || type.IsEnum ) 
                    return value.ToString();

                return $"object:{type.Name}";
            }
            catch (Exception) { return "!error!"; }
        }

        /// <summary>
        /// Returns string representation of SqlCommand parameters
        /// </summary>
        /// <param name="c">SQL Command</param>
        /// <returns>String</returns>
        public static string GetParameterString(NpgsqlCommand c)
        {
            string ret = string.Empty;

            if (c == null) return ret;

            try
            {
                var builder = new StringBuilder();

                foreach (NpgsqlParameter p in c.Parameters)
                {
                    builder.AppendFormat("{0}={1},", p.ParameterName, DebugUtil.GetDebugParamValue(p.Value));
                    //builder.Append($"{{@{ p.ParameterName }={{{DebugUtil.GetDebugParamValue(p.Value)}}}");
                    //ret += "{@" + p.ParameterName + "}={" + DebugUtil.GetDebugParamValue(p.Value) + "}";
                }
                ret = builder.ToString();
            }
            catch (Exception) { return "!error!"; }

            return ret;
        }

    }
}
