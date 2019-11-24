using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcServer;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {

        #region Non-default Customer with streams example
            const string address = "https://localhost:5001";
            var channel = GrpcChannel.ForAddress(address);
            var client = new Customer.CustomerClient(channel);
            using (var call = client.GetNewCustomers(new NewCustomersRequest()))
            {
                while(await call.ResponseStream.MoveNext())
                {
                    var currentCustomer = call.ResponseStream.Current;
                    Console.WriteLine(currentCustomer);
                }
            }
        #endregion
        #region Non-default Customer example
            // var input = new CustomerLookupModel { UserId = 1 };
            // const string channelAddres = "https://localhost:5001";
            // var channel = GrpcChannel.ForAddress(channelAddres);
            // var customer = new Customer.CustomerClient(channel);
            // var reply = await customer.GetCustomerInfoAsync(input);
            // Console.WriteLine(reply);
        #endregion
        #region Default Greeter example
            // // define the input for the Greeter
            // var input = new HelloRequest { Name = "Nemanja" };

            // // define the channel for the Greeter
            // const string channelAddress = "https://localhost:5001";
            // var channel = GrpcChannel.ForAddress(channelAddress);

            // // define the Greeter 
            // var greeter = new Greeter.GreeterClient(channel);

            // // get the reply from the Greeter
            // var reply = await greeter.SayHelloAsync(input);
            // Console.WriteLine(reply.Message);
        #endregion
            Console.WriteLine("KTHNXBAI");
        }
    }
}