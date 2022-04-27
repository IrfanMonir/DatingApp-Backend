namespace Api.Configurations
{
    internal static class ConfigurationRegister
    {
        internal static ConfigureHostBuilder AddConfigurations(this ConfigureHostBuilder host)
        {
            host.ConfigureAppConfiguration((context, config) =>
            {
                const string configurationsDirectory = "Configurations";
                var env = context.HostingEnvironment;

                config
            .AddJsonFile($"{configurationsDirectory}/security.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"{configurationsDirectory}/security.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"{configurationsDirectory}/securityheaders.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"{configurationsDirectory}/securityheaders.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            });
            return host;
        }
    }
}
