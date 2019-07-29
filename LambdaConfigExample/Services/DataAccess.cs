using LambdaConfigExample.Models;
using System.Threading.Tasks;

namespace LambdaConfigExample.Services
{
    public class DataAccess : IDataAccess
    {
        private readonly IAppConfig config;

        public DataAccess(IAppConfig config)
        {
            this.config = config;
        }

        public async Task<string> GetFilePath(UserInfo userInfo)
        {
            return await Task.Run(() => "hello.txt");
        }

        public async Task<UserInfo> GetUserInfo(int id)
        {
            return await Task.Run(() => new UserInfo
            {
                Id = id,
                Name = "some user",
            });
        }
    }
}
