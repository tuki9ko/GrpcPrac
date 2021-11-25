using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using gRpcTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server
            {
                Services = { Example.BindService(new ExampleService()) },
                Ports = { new ServerPort("127.0.0.1", 12345, ServerCredentials.Insecure) }
            };

            server.Start();

            Console.WriteLine("Press any key to shutdown the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }

    public class ExampleService : Example.ExampleBase
    {
        public override Task<ExampleReply> GetMachineInfo(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new ExampleReply
            {
                MachineName = Environment.MachineName,
                UserName = Environment.UserName,
            });
        }
    }
}
