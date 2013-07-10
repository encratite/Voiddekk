using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game
{
	[XmlType(TypeName = "Unit")]
	public class UnitType: CardType
    {
		public int Damage { get; set; }
		public int Life { get; set; }
		public List<UnitFlag> Flags { get; set; }

		public UnitType()
		{
			Flags = new List<UnitFlag>();
		}
    }
}
