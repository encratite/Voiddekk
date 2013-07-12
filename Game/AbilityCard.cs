using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game
{
	[XmlType(TypeName = "Ability")]
	public class AbilityCard : BaseCard
	{
		AbilityTarget Target { get; set; }
		List<AbilityEffect> Effects { get; set; }
	}
}
