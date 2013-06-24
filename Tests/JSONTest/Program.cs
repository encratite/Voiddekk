using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace JSONTest
{
	class Call
	{
		public string Function;
		public object[] Arguments;

		public Call()
		{
		}

		public Call(string function, params object[] arguments)
		{
			Function = function;
			Arguments = arguments;
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Call call = new Call("function", 1, 2, 3, "string", false, true, null);
			JavaScriptSerializer serialiser = new JavaScriptSerializer();
			string serialisedData = serialiser.Serialize(call);
			Call output = serialiser.Deserialize<Call>(serialisedData);
		}
	}
}
