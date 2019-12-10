using Bluelinky.Net;
using System;
using System.Threading.Tasks;

namespace BlueLink.Net.TestConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bluelinkClient = new BluelinkyClient("someuser@gmail.com", "somepassword");
            await bluelinkClient.LoginAsync();

            Console.Read();
        }
    }
}
