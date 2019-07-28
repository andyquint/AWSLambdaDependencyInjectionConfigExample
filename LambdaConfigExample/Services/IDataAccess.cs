using LambdaConfigExample.Models;
using System.Threading.Tasks;

namespace LambdaConfigExample.Services
{
    public interface IDataAccess
    {
        Task<UserInfo> GetUserInfo(int id);

        Task<string> GetFilePath(UserInfo userInfo);
    }
}
