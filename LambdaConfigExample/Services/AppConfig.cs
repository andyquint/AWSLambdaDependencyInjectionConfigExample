using Microsoft.Extensions.Configuration;

namespace LambdaConfigExample.Services
{
    public class AppConfig : IAppConfig
    {
        private readonly IConfiguration configuration;

        public AppConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string ConnectionString => this.configuration["connectionString"];

        public string UserFileBucket => this.configuration["userFileBucket"];
    }
}
