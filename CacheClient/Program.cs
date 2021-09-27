using CacheCow.Client;
using CacheCow.Client.RedisCacheStore;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace CacheClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Clear();
            var client = ClientExtensions.CreateClient(new RedisStore("localhost:6381"));
            client.BaseAddress = new Uri("http://localhost:1337");

            var sw = new Stopwatch();
            while(true)
            {
                sw.Restart();
                Console.WriteLine("Hit enter to call the API");
                Console.ReadLine();
                var response = await client.GetAsync("/cached");
                response.EnsureSuccessStatusCode();
                Console.WriteLine(response.Headers.CacheControl.ToString());
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
                sw.Stop();
                Console.WriteLine($"That took about {sw.ElapsedMilliseconds} milliseconds!");
            }
        }
    }
}
