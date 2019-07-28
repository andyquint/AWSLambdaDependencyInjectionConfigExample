using Amazon.Lambda.Core;
using LambdaConfigExample.Models;
using LambdaConfigExample.Services;
using System.Threading.Tasks;

namespace LambdaConfigExample.Handlers
{
    public class GetUserFile : IRun<UserInfo, string>
    {
        private readonly IAppConfig appConfig;
        private readonly IDataAccess dataAccess;
        private readonly IFileStorage fileStorage;

        public GetUserFile(IAppConfig appConfig, IDataAccess dataAccess, IFileStorage fileStorage)
        {
            this.appConfig = appConfig;
            this.dataAccess = dataAccess;
            this.fileStorage = fileStorage;
        }

        public async Task<string> Handler(UserInfo input, ILambdaContext context)
        {
            var filePath = await this.dataAccess.GetFilePath(input);
            return await this.fileStorage.GetTextFileContents(this.appConfig.UserFileBucket, filePath);
        }
    }
}
