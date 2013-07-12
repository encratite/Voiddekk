using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game
{
	[XmlType(TypeName = "Unit")]
	public class UnitCard: BaseCard
    {
		public int Damage { get; set; }
		public int Life { get; set; }
		public List<UnitFlag> Flags { get; set; }

		public UnitCard()
		{
			Flags = new List<UnitFlag>();
		}
    }
}
