using LambdaConfigExample.Handlers;
using LambdaConfigExample.Models;
using LambdaConfigExample.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LambdaConfigExample.Functions
{
    public class GetUserFileFunction : LambdaFunction<UserInfo, string, GetUserFile>
    {
        protected override void RegisterDependencies(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAppConfig, AppConfig>();
            serviceCollection.AddSingleton<IDataAccess, DataAccess>();
            serviceCollection.AddSingleton<IFileStorage, FileStorage>();
        }
    }
}
