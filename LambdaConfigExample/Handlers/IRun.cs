using Amazon.Lambda.Core;
using System.Threading.Tasks;

namespace LambdaConfigExample.Handlers
{
    public interface IRun<TInput, TOutput>
    {
        Task<TOutput> Handler(TInput input, ILambdaContext context);
    }
}
