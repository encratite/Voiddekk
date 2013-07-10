using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game
{
	public class UnitType
    {
		// The ID is generated automatically later
		[XmlIgnore]
		public int? Id;
		public string Name { get; set; }
		// Used for image paths
		public string InternalName { get; set; }
		// A limit of null means the default limit
		public int? Limit { get; set; }
		public int Resources { get; set; }
		public int Damage { get; set; }
		public int Life { get; set; }
		public List<UnitFlag> Flags { get; set; }

		public UnitType()
		{
			Flags = new List<UnitFlag>();
		}
    }
}
