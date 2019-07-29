using LambdaConfigExample.Handlers;
using LambdaConfigExample.Models;
using LambdaConfigExample.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LambdaConfigExample.Functions
{
    public class GetUserFunction : LambdaFunction<int, UserInfo, GetUser>
    {
        protected override void RegisterDependencies(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAppConfig, AppConfig>();
            serviceCollection.AddSingleton<IDataAccess, DataAccess>();
        }
    }
}
