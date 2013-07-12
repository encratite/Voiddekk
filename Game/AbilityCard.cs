using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game
{
	[XmlType(TypeName = "Ability")]
	public class AbilityCard : BaseCard
	{
		public AbilityTarget Target { get; set; }
		public List<AbilityEffect> Effects { get; set; }

		public AbilityCard()
		{
			Effects = new List<AbilityEffect>();
		}
	}
}
