namespace Game
{
	public class BaseCard
	{
		// Actual name shown in the client only, not used internally by the server, may contain Unicode
		public string Name { get; set; }
		// Used for image paths and also as an identifier in packets and in the database
		public string InternalName { get; set; }
		// Numeric limit per deck
		public int Limit { get; set; }
		// Amount of resource points required to play this card
		public int Resources { get; set; }

		public BaseCard()
		{
			Limit = Constants.DefaultCardLimit;
		}
	}
}

