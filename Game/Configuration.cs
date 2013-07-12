using System.Collections.Generic;

namespace Game
{
	public class Configuration
	{
		public List<UnitCard> Units;
		public List<AbilityCard> Abilities;
		public List<AttachmentCard> Attachments;

		public Configuration()
		{
			Units = new List<UnitCard>();
			Abilities = new List<AbilityCard>();
			Attachments = new List<AttachmentCard>();
		}
	}
}
