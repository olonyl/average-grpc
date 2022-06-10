using Average;
using Grpc.Core;
using System;
using System.IO;

namespace server
{
    class Program
    {
        const int Port = 50023;
        static void Main(string[] args)
        {
            Server server = null;

            try
            {
                server = new Server
                {
                    Services = { AverageService.BindService(new AverageServiceImpl()) },
                    Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
                };

                server.Start();
                Console.WriteLine($"The server is listening on Port: {Port}");
                Console.ReadKey();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error Initializing the server in port {Port}", ex.Message);
                throw;
            }
            finally
            {
                if (server != null)
                    server.ShutdownAsync().Wait();
            }


        }
    }
}
