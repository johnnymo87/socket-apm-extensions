using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        public static async Task<Socket> OpenConnection(int version, string serverAddress, int serverPort, string socksAddress, int socksPort, string username = null, string password = null)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var endPoint = new DnsEndPoint(socksAddress, socksPort);
            Func<AsyncCallback, object, IAsyncResult> begin =
                (cb, s) => socket.BeginConnect(endPoint, cb, s);
            await Task.Factory.FromAsync(begin, socket.EndConnect, null);

            return socket;
        }
    }
}
