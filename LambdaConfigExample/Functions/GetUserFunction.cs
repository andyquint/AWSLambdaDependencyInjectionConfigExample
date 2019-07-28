using LambdaConfigExample.Handlers;
using LambdaConfigExample.Models;
using System;

namespace LambdaConfigExample.Functions
{
    public class GetUserFunction : LambdaFunction<int, UserInfo>
    {
        protected override Type Handler => typeof(GetUser);
    }
}
