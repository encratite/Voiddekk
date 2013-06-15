using System;
using System.Threading;

using SuperWebSocket;
using SuperSocket.SocketBase;

namespace SuperWebSocketTest
{
	class Program
	{
		static void Main(string[] arguments)
		{
			WebSocketServer server = new WebSocketServer();
			server.NewSessionConnected += new SessionHandler<WebSocketSession>(OnConnect);
			server.SessionClosed += new SessionHandler<WebSocketSession, CloseReason>(OnDisconnect);
			server.NewMessageReceived += new SessionHandler<WebSocketSession, string>(OnMessage);
			server.Setup(81);
			server.Start();
			while (true)
				Thread.Sleep(0);
		}

		static string GetTimestamp()
		{
			return DateTime.Now.ToString("HH:mm:ss");
		}

		static void Write(string message, WebSocketSession session, params object[] arguments)
		{
			Console.WriteLine("{0} [{1}] {2}", GetTimestamp(), session.Host, string.Format(message, arguments));
		}

		static void OnConnect(WebSocketSession session)
		{
			Write("Connected", session);
			new Thread(() => HandleClient(session)).Start();
		}

		static void OnDisconnect(WebSocketSession session, CloseReason reason)
		{
			Write("Disconnected", session);
		}

		static void OnMessage(WebSocketSession session, string message)
		{
			Write("Message: {0}", session, message);
		}

		static void HandleClient(WebSocketSession session)
		{
			while (session.Connected)
			{
				Write("Sending timestamp", session);
				session.Send(GetTimestamp());
				Thread.Sleep(1000);
			}
		}
	}
}
