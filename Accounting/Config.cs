using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;

namespace Accounting
{
    /**
     * Singleton, Usage:
     * Config.Instance.SetString("GLOBAL", "Active");
     * 
     * Config.Instance.GetString("GLOBAL");
     */

    public class Config
    {
        // make this singleton
        private static Config _config;

        private string _connectionstring = null;

        // singleton entry

        private readonly Dictionary<String, String> _dataDictionary = new Dictionary<string, string>();

        public static Config Instance
        {
            get { return _config ?? (_config = new Config()); }
        }

        public void SetString(string key, string value)
        {
            _dataDictionary[key] = value;
        }


        public string GetString(string key, string defaultValue = "")
        {
            var value = defaultValue;
            _dataDictionary.TryGetValue(key, out value);
            return value;
        }

        public bool GetBoolean(String key, bool defaultValue = false)
        {
            var value = GetString(key, "");
            if (value == "") return false;

            try
            {
                var numValue = Convert.ToBoolean(value);
                return numValue;
            }
            catch
            {
            }

            return false;
        }

        public String GetConnectionString()
        { // create connection with passwd n user id on runtime.
            if (_connectionstring != null)
            {
                return _connectionstring;
            }

            var originalConnectionString = ConfigurationManager.ConnectionStrings["accountingEntities"].ConnectionString;
            var entityBuilder = new EntityConnectionStringBuilder(originalConnectionString);
            var factory = DbProviderFactories.GetFactory(entityBuilder.Provider);
            var providerBuilder = factory.CreateConnectionStringBuilder();
            if (providerBuilder == null)
            {
                return null;
            }

            providerBuilder.ConnectionString = entityBuilder.ProviderConnectionString;
            providerBuilder.Add("Password", "P@ss123");
            providerBuilder.Add("User Id", "si");
            entityBuilder.ProviderConnectionString = providerBuilder.ToString();
            _connectionstring = entityBuilder.ToString();
            return _connectionstring;
        }
    }
}