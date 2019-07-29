using Microsoft.Extensions.Configuration;
using System;

namespace LambdaConfigExample.Services
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration configuration;

        public AppConfig()
        {
            var environmentName = Environment.GetEnvironmentVariable("EnvironmentName");

            this.configuration = new ConfigurationBuilder()
                .AddSystemsManager(configureSource =>
                {
                    configureSource.Path = $"/myapp/{environmentName}";
                    configureSource.ReloadAfter = TimeSpan.FromMinutes(1);
                })
                .Build();
        }

        public string ConnectionString => this.configuration["connectionString"];

        public string UserFileBucket => this.configuration["userFileBucket"];
    }
}
