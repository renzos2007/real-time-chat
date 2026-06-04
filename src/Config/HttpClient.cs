using System;
using System.Net;
using DotNetEnv;

namespace Config
{
    class Http
    {
        private static readonly HttpClientHandler handler;
        public static readonly HttpClient SharedClient;

        static Http()
        {
            Env.Load();

            handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };

            SharedClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(
                    Environment.GetEnvironmentVariable("BASE_URL")
                    ?? "https://jsonplaceholder.typicode.com"
                ),
            };
        }
    }
}