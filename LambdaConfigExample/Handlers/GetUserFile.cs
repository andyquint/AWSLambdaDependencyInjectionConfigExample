using Amazon.Lambda.Core;
using LambdaConfigExample.Models;
using LambdaConfigExample.Services;
using System.Threading.Tasks;

namespace LambdaConfigExample.Handlers
{
    public class GetUserFile : IHandler<UserInfo, string>
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

        public async Task<string> Run(UserInfo input, ILambdaContext context)
        {
            var filePath = await this.dataAccess.GetFilePath(input);
            return await this.fileStorage.GetTextFileContents(this.appConfig.UserFileBucket, filePath);
        }
    }
}
