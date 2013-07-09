using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;

using SuperWebSocket;
using SuperSocket.SocketBase;

using Persona;

namespace PersonaServer
{
	class Program
	{
		static void Main(string[] arguments)
		{
			WebSocketServer server = new WebSocketServer();
			server.NewSessionConnected += new SessionHandler<WebSocketSession>(OnConnect);
			server.SessionClosed += new SessionHandler<WebSocketSession, CloseReason>(OnDisconnect);
			server.NewMessageReceived += new SessionHandler<WebSocketSession, string>(OnMessage);
			server.Setup(82);
			server.Start();
			ManualResetEvent resetEvent = new ManualResetEvent(false);
			resetEvent.WaitOne();
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
		}

		static void OnDisconnect(WebSocketSession session, CloseReason reason)
		{
			Write("Disconnected", session);
		}

		static void OnMessage(WebSocketSession session, string message)
		{
			Write("Message: {0}", session, message);
			string audience = "http://persona/";
			PersonaClient client = new PersonaClient(message, audience, (PersonaResponse response) => OnPersonaResponse(session, response), (Exception exception) => OnPersonaException(session, exception));
			client.Run();
		}

		static void OnPersonaResponse(WebSocketSession session, PersonaResponse response)
		{
			string message = string.Format("Persona response: email {0}, audience {1}, expires {2}, issuer {3}", response.Email, response.Audience, response.Expires, response.Issuer);
			Write(message, session);
			session.Send(message);
		}

		static void OnPersonaException(WebSocketSession session, Exception exception)
		{
			string message = string.Format("Persona exception: {0}", exception.Message);
			Write(message, session);
			session.Send(message);
		}
	}
}
