using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

using Alchemy;
using Alchemy.Classes;

namespace AlchemyTest
{
	class Program
	{
		static List<UserContext> ActiveContexts;

		static void Main(string[] arguments)
		{
			ActiveContexts = new List<UserContext>();

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
			lock (ActiveContexts)
			{
				Write("Connected", context);
				ActiveContexts.Add(context);
				new Thread(() => HandleClient(context)).Start();
			}
		}

		static void OnDisconnect(UserContext context)
		{
			lock (ActiveContexts)
			{
				Write("Disconnected", context);
				ActiveContexts.Remove(context);
			}
		}

		static void HandleClient(UserContext context)
		{
			while (true)
			{
				lock (ActiveContexts)
				{
					if (!ActiveContexts.Contains(context))
						break;
					Write("Sending timestamp", context);
					context.Send(GetTimestamp());
				}
				Thread.Sleep(1000);
			}
		}
	}
}
