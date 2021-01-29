using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace TcpListenerUygulamasi
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server;
            try
            {
                server = new TcpListener(IPAddress.Parse("127.0.0.1"), 600);
                server.Start();
                byte[] buffer = new byte[250];
                string mesaj;
                while(true)
                {
                    Console.WriteLine("Client Bekleniyor...");
                    TcpClient client = server.AcceptTcpClient(); //return TcpClient
                    Console.WriteLine("Client Bağlandı...");
                    NetworkStream ns = client.GetStream();
                    int counter = ns.Read(buffer, 0, buffer.Length);
                    while (counter != 0)
                    {
                        mesaj = Encoding.ASCII.GetString(buffer, 0, counter);
                        Console.WriteLine("Gelen Mesaj: ", mesaj);
                    }
                    client.Close();
                }
                server.Stop();
            }
            catch(SocketException exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.ReadLine();
        }
    }
}
