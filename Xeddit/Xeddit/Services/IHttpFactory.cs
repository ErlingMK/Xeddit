namespace Xeddit.Services
{
    interface IHttpFactory
    {
        IHttpClient Create();
    }

    internal class HttpFactory : IHttpFactory
    {
        private readonly IHttpClient m_httpClient;

        public HttpFactory(IHttpClient httpClient)
        {
            m_httpClient = httpClient;
        }

        public IHttpClient Create()
        {
            return m_httpClient;
        }
    }
}
