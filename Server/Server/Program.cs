using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 600));//ip ve dinleyeceği port
                socket.Listen(9);//kuyruk uzunluğu
                Socket client = socket.Accept();//client olustu ve soketin dönüş tipine esitlendi
                NetworkStream ns = new NetworkStream(client);
                StreamReader sr = new StreamReader(ns);
                Console.WriteLine(sr.ReadToEnd());//clienttan gelen veri sonuna kadar okundu
                sr.Close();
                ns.Close();
                socket.Shutdown(SocketShutdown.Both);
                client.Shutdown(SocketShutdown.Receive);
            }
            catch(SocketException exc)
            {
                Console.WriteLine("Hata Olustu");
            }
            Console.Read();
        }
    }
}
