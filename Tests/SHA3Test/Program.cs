using System.Security.Cryptography;
using System.Text;

namespace SHA3Test
{
	class Program
	{
		static void Main(string[] arguments)
		{
			string input = "The quick brown fox jumps over the lazy dog";
			var hash = new SHA3Managed();
			byte[] output = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
		}
	}
}
