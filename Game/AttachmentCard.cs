using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game
{
	[XmlType(TypeName = "Attachment")]
	public class AttachmentCard : BaseCard
	{
		public AttachmentCardType Type { get; set; }
		public List<UnitFlag> Flags { get; set; }

		public AttachmentCard()
		{
			Flags = new List<UnitFlag>();
		}
	}
}
