namespace AsyncAwaitLoop.Interfaces
{
    public interface IConfiguration
    {
        string[] GetSiteList();

        string JsonFileName { get; }
    }
}
