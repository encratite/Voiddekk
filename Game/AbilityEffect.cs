using System.Xml.Serialization;

namespace Game
{
	[XmlType(TypeName = "Effect")]
	public class AbilityEffect
	{
		AbilityEffectType Type { get; set; }
		int? Parameter { get; set; }
	}
}
