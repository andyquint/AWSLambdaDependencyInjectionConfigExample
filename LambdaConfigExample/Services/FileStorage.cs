using System;
using System.Threading.Tasks;

namespace LambdaConfigExample.Services
{
    public class FileStorage : IFileStorage
    {
        public async Task<string> GetTextFileContents(string bucketName, string key)
        {
            if (string.IsNullOrWhiteSpace(bucketName))
            {
                throw new ArgumentException("Invalid bucket name", nameof(bucketName));
            }

            return await Task.Run(() => $"hello.txt in bucket://{bucketName}/{key}");
        }
    }
}
