namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            throw new NotImplementedException();
        }

        public void Start(int port)
        {
            throw new NotImplementedException();
        }
    }
}
