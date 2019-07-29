using Amazon.Lambda.Core;
using System.Threading.Tasks;

namespace LambdaConfigExample.Handlers
{
    public interface IHandler<TInput, TOutput>
    {
        Task<TOutput> Run(TInput input, ILambdaContext context);
    }
}
