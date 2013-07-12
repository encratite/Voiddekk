namespace Game
{
	public class BaseCard
	{
		public string Name { get; set; }
		// Used for image paths and also as an identifier in packets and in the database
		public string InternalName { get; set; }
		public int Limit { get; set; }
		public int Resources { get; set; }

		public BaseCard()
		{
			Limit = Constants.DefaultCardLimit;
		}
	}
}

