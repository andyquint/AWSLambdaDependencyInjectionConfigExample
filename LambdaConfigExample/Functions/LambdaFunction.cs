using Amazon.Lambda.Core;
using LambdaConfigExample.Handlers;
using LambdaConfigExample.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace LambdaConfigExample.Functions
{
    public abstract class LambdaFunction<TInput, TOutput>
    {
        private readonly IServiceProvider serviceProvider;

        protected abstract Type Handler { get; }

        public LambdaFunction()
        {
            if (!typeof(IRun<TInput, TOutput>).IsAssignableFrom(Handler))
            {
                throw new ArgumentException("Handler does not implement correct interface.", this.Handler.Name);
            }

            this.serviceProvider = ConfigureServices();
        }

        public async Task<TOutput> Run(TInput input, ILambdaContext context)
        {
            using (var scope = this.serviceProvider.CreateScope())
            {
                var result = await scope.ServiceProvider.GetService<IRun<TInput, TOutput>>().Handler(input, context);

                return result;
            }
        }

        private IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton(typeof(IRun<TInput, TOutput>), Handler);
            serviceCollection.AddSingleton(sp => BuildConfiguration());
            serviceCollection.AddSingleton<IAppConfig, AppConfig>();
            serviceCollection.AddSingleton<IDataAccess, DataAccess>();
            serviceCollection.AddSingleton<IFileStorage, FileStorage>();

            return serviceCollection.BuildServiceProvider();
        }

        private static IConfiguration BuildConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable("EnvironmentName");

            return new ConfigurationBuilder()
                .AddSystemsManager(configureSource =>
                {
                    configureSource.Path = $"/myapp/{environmentName}";
                    configureSource.ReloadAfter = TimeSpan.FromMinutes(1);
                })
                .Build();
        }
    }
}
