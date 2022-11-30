using Microsoft.Extensions.Configuration;

namespace Home.Configuration
{
    public static class HomeConfig
    {
        private static readonly string _configFilePathEnv = "HOME_WEB_CONFIG";
        private static readonly string _defaultConfigFilePath = "appsettings.json";

        private static Config? _configurationData;
        public static Config Default
        {
            get
            {
                _configurationData ??= GetConfiguration();
                return _configurationData!;
            }
        }

        private static string GetConfigFilePath() {
            var path = Environment.GetEnvironmentVariable(_configFilePathEnv);

            if (path == null)
                return _defaultConfigFilePath;

            return path;
        }

        private static Config? GetConfiguration() =>
            new ConfigurationBuilder()
            .AddJsonFile(GetConfigFilePath())
            .Build()
            .Get<Config>();

    }
}