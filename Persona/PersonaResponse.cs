using System.Runtime.Serialization;

namespace Persona
{
	[DataContract]
	public class PersonaResponse
	{
		[DataMember(Name = "status")]
		public string Status { get; set; }

		[DataMember(Name = "email")]
		public string Email { get; set; }

		[DataMember(Name = "audience")]
		public string Audience { get; set; }

		[DataMember(Name = "expires")]
		public long Expires { get; set; }

		[DataMember(Name = "issuer")]
		public string Issuer { get; set; }
	}
}
