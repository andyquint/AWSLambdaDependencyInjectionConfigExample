using Amazon.Lambda.Core;
using LambdaConfigExample.Models;
using LambdaConfigExample.Services;
using System.Threading.Tasks;

namespace LambdaConfigExample.Handlers
{
    public class GetUser : IHandler<int, UserInfo>
    {
        private readonly IDataAccess dataAccess;

        public GetUser(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }

        public async Task<UserInfo> Run(int input, ILambdaContext context)
        {
            return await this.dataAccess.GetUserInfo(input);
        }
    }
}
