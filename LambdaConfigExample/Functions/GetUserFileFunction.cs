using LambdaConfigExample.Handlers;
using LambdaConfigExample.Models;
using System;

namespace LambdaConfigExample.Functions
{
    public class GetUserFileFunction : LambdaFunction<UserInfo, string>
    {
        protected override Type Handler => typeof(GetUserFile);
    }
}
