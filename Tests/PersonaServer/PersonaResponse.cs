namespace PersonaServer
{
	class PersonaResponse
	{
		public string status { get; set; }
		public string email { get; set; }
		public string audience { get; set; }
		public long expires { get; set; }
		public string issuer { get; set; }
	}
}
