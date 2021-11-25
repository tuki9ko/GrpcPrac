using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using gRpcTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = new Channel("127.0.0.1", 12345, ChannelCredentials.Insecure);
            var client = new Example.ExampleClient(channel);
            var machineInfo = client.GetMachineInfo(new Empty());
            Console.WriteLine($"MachineName: {machineInfo.MachineName} / UserName: {machineInfo.UserName}");
        }
    }
}
