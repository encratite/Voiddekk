using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Script.Serialization;

namespace PersonaServer
{
	class PersonaException : Exception
	{
		public PersonaException(string message)
			: base(message)
		{
		}
	}

	class PersonaClient
	{
		public delegate void ResponseEvent(PersonaResponse response);
		public delegate void ExceptionEvent(Exception exception);

		string Assertion;
		string Audience;

		ResponseEvent OnResponse;
		ExceptionEvent OnException;

		HttpWebRequest Request;
		byte[] PostBytes;

		public PersonaClient(string assertion, string audience, ResponseEvent onResponse, ExceptionEvent onException = null)
		{
			Assertion = assertion;
			Audience = audience;

			OnResponse = onResponse;
			OnException = onException;

			Request = null;
			PostBytes = null;
		}

		public void Run()
		{
			try
			{
				string postString = string.Format("assertion={0}&audience={1}", HttpUtility.UrlEncode(Assertion), HttpUtility.UrlEncode(Audience));
				PostBytes = Encoding.ASCII.GetBytes(postString);
				Request = (HttpWebRequest)HttpWebRequest.Create("https://verifier.login.persona.org/verify");
				Request.UserAgent = "Persona Client";
				Request.Method = "POST";
				Request.ContentType = "application/x-www-form-urlencoded";
				Request.ContentLength = PostBytes.Length;
				Request.BeginGetRequestStream(new AsyncCallback(OnGetRequestStream), null);
			}
			catch (Exception exception)
			{
				HandleException(exception);
			}
		}

		void OnGetRequestStream(IAsyncResult asynchronousResult)
		{
			try
			{
				Stream postStream = Request.EndGetRequestStream(asynchronousResult);
				postStream.Write(PostBytes, 0, PostBytes.Length);
				postStream.Close();
				HttpWebResponse webResponse = (HttpWebResponse)Request.GetResponse();
				StreamReader stream = new StreamReader(webResponse.GetResponseStream(), Encoding.ASCII);
				string content = stream.ReadToEnd();
				JavaScriptSerializer serialiser = new JavaScriptSerializer();
				PersonaResponse personaResponse = serialiser.Deserialize<PersonaResponse>(content);
				if (personaResponse.status != "okay")
					throw new PersonaException("Persona login failed");
				OnResponse(personaResponse);
			}
			catch (Exception exception)
			{
				HandleException(exception);
			}
		}

		void HandleException(Exception exception)
		{
			if (OnException != null)
				OnException(exception);
		}
	}
}
