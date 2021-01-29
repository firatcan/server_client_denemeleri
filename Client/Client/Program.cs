using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            socket.Connect(IPAddress.Parse("127.0.0.1"),600);//gönderilecek veri
            byte[] buffer = Encoding.ASCII.GetBytes(Console.ReadLine());
            socket.Send(buffer);
            socket.Close();
            Console.Read();
        }
    }
}
