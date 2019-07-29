using Amazon.Lambda.Core;
using LambdaConfigExample.Handlers;
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
            if (!typeof(IHandler<TInput, TOutput>).IsAssignableFrom(Handler))
            {
                throw new ArgumentException("Handler does not implement correct interface.", this.Handler.Name);
            }

            this.serviceProvider = ConfigureServices();
        }

        public async Task<TOutput> Run(TInput input, ILambdaContext context)
        {
            using (var scope = this.serviceProvider.CreateScope())
            {
                var result = await scope.ServiceProvider.GetService<IHandler<TInput, TOutput>>().Run(input, context);

                return result;
            }
        }

        protected abstract void RegisterDependencies(ServiceCollection serviceCollection);

        private IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            this.RegisterDependencies(serviceCollection);
            serviceCollection.AddSingleton(typeof(IHandler<TInput, TOutput>), Handler);

            return serviceCollection.BuildServiceProvider();
        }
    }
}
