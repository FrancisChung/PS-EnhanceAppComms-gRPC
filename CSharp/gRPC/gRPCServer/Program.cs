using Grpc.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static Messages.EmployeeService;
using Messages;


namespace gRPCServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();

            const int Port = 9000;
            var cacert = File.ReadAllText(@"ca.crt");
            var cert = File.ReadAllText(@"server.crt");
            var key = File.ReadAllText(@"server.key");

            var keyPair = new KeyCertificatePair(cert, key);
            var sslCredentials = new SslServerCredentials(new List<KeyCertificatePair> {keyPair}, cacert, false);

            Server server = new Server
            {
                Ports = {new ServerPort("0.0.0.0", Port, sslCredentials)},
                Services = {BindService(new EmployeeService())}
            };

            server.Start();

            Console.WriteLine(("Starting server on port " + Port));
            Console.WriteLine("Press any key to stop ...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();

        }

        public class EmployeeService : Messages.EmployeeService.EmployeeServiceBase
        {
            public override async Task<EmployeeResponse> GetByBadgeNumber(GetByBadgeNumberRequest request, ServerCallContext context)
            {
                Metadata md = context.RequestHeaders;
                foreach (var entry in md)
                {
                    Console.WriteLine($"{entry.Key} : {entry.Value}");
                }

                return new EmployeeResponse();
            }
        }
    }
}
