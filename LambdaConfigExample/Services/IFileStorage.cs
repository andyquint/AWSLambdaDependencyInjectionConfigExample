using System.Threading.Tasks;

namespace LambdaConfigExample.Services
{
    public interface IFileStorage
    {
        Task<string> GetTextFileContents(string bucketName, string key);
    }
}