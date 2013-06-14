using System;
using System.Net;
using System.Threading;

using Alchemy;
using Alchemy.Classes;

namespace AlchemyTest
{
	class Program
	{
		static void Main(string[] arguments)
		{
			WebSocketServer server = new WebSocketServer(81, IPAddress.Any)
			{
				OnReceive = OnReceive,
				OnSend = OnSend,
				OnConnected = OnConnect,
				OnDisconnect = OnDisconnect,
				TimeOut = new TimeSpan(0, 0, 5)
			};

			server.Start();
		}

		static string GetTimestamp()
		{
			return DateTime.Now.ToString("HH:mm:ss");
		}

		static void Write(string message, UserContext context, params object[] arguments)
		{
			Console.WriteLine("{0} [{1}] {2}", GetTimestamp(), context.ClientAddress, string.Format(message, arguments));
		}

		static void OnReceive(UserContext context)
		{
			Write("Received: {0}", context, context.DataFrame.ToString());
		}

		static void OnSend(UserContext context)
		{
			Write("Sent data", context);
		}

		static void OnConnect(UserContext context)
		{
			Write("Connected", context);
			new Thread(() => HandleClient(context)).Start();
		}

		static void OnDisconnect(UserContext context)
		{
			Write("Disconnected", context);
		}

		static void HandleClient(UserContext context)
		{
			while (true)
			{
				context.Send(GetTimestamp());
				Thread.Sleep(1000);
			}
		}
	}
}
