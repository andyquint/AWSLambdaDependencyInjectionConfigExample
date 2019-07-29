using LambdaConfigExample.Handlers;
using LambdaConfigExample.Models;
using LambdaConfigExample.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LambdaConfigExample.Functions
{
    public class GetUserFunction : LambdaFunction<int, UserInfo>
    {
        protected override Type Handler => typeof(GetUser);

        protected override void RegisterDependencies(ServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAppConfig, AppConfig>();
            serviceCollection.AddSingleton<IDataAccess, DataAccess>();
        }
    }
}
