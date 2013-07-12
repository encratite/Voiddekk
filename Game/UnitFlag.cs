using System.Xml.Serialization;

namespace Game
{
	[XmlType(TypeName = "Flag")]
	public class UnitFlag
	{
		public UnitFlagType Type { get; set; }
		public int? Parameter { get; set; }

		public UnitFlag()
		{
		}

		public UnitFlag(UnitFlagType type)
		{
			Type = type;
			Parameter = null;
		}

		public UnitFlag(UnitFlagType type, int parameter)
		{
			Type = type;
			Parameter = parameter;
		}
	}
}
