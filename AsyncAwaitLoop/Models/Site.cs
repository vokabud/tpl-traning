namespace AsyncAwaitLoop.Models
{
    public class Site
    {
        public Site(
            string url, 
            string content)
        {
            this.Url = url;
            this.Content = content;
        }

        public string Url { get; }

        public string Content { get; }
    }
}
