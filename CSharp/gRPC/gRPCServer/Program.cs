using System;
using System.Collections.Generic;
using System.IO;

using Grpc.Core;


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
                Ports = {new ServerPort("0.0.0.0", Port, sslCredentials)}
            };

            server.Start();

            Console.WriteLine(("Starting server on port " + Port));
            Console.WriteLine("Press any key to stop ...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();

        }
    }
}
//