using System.Xml.Serialization;

namespace Game
{
	public class CardType
	{
		// The ID is generated automatically later
		[XmlIgnore]
		public int? Id;
		public string Name { get; set; }
		// Used for image paths
		public string InternalName { get; set; }
		public int Limit { get; set; }
		public int Resources { get; set; }

		public CardType()
		{
			Limit = 4;
		}
	}
}

