using System;
using Microsoft.Extensions.Configuration;

namespace TestAdoNet
{
    public sealed class ConfigurationSettings
    {
        static readonly Lazy<ConfigurationSettings> lazy = new Lazy<ConfigurationSettings>(() => new ConfigurationSettings());

        public static ConfigurationSettings Instance => lazy.Value;

        const string
            AppSettingsKey = "AppSettings",
            DbConnectionNameKey = "DbConnectionName",
            ConnectionStringsKey = "ConnectionStrings",
            ConnectionStringKey = "ConnectionString",
            ProviderNameKey = "ProviderName";
        
        readonly IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        public static string DbConnectionName => Instance.config[$"{AppSettingsKey}:{DbConnectionNameKey}"];

        public static string GetConnectionString(string connectionName)
        {
            return Instance.config[$"{ConnectionStringsKey}:{connectionName}:{ConnectionStringKey}"];
        }
        
        public static string ConnectionString => Instance.config[$"{ConnectionStringsKey}:{DbConnectionName}:{ConnectionStringKey}"];
        public static string GetProviderName(string connectionName)
        {
            return Instance.config[$"{ConnectionStringsKey}:{connectionName}:{ProviderNameKey}"];
        }

        public static string ProviderName => Instance.config[$"{ConnectionStringsKey}:{DbConnectionName}:{ProviderNameKey}"];
    }
}
