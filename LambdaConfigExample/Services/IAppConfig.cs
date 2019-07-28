namespace LambdaConfigExample.Services
{
    public interface IAppConfig
    {
        string ConnectionString { get; }
        string UserFileBucket { get; }
    }
}
