using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcServer;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // define the input for the Greeter
            var input = new HelloRequest { Name = "Nemanja" };

            // define the channel for the Greeter
            const string channelAddress = "https://localhost:5001";
            var channel = GrpcChannel.ForAddress(channelAddress);

            // define the Greeter 
            var greeter = new Greeter.GreeterClient(channel);

            // get the reply from the Greeter
            var reply = await greeter.SayHelloAsync(input);
            Console.WriteLine(reply.Message);

            Console.WriteLine("KTHNXBAI");
        }
    }
}