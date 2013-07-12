using System.Xml.Serialization;

namespace Game
{
	[XmlType(TypeName = "Effect")]
	public class AbilityEffect
	{
		public AbilityEffectType Type { get; set; }
		public int? Parameter { get; set; }

		public AbilityEffect()
		{
		}

		public AbilityEffect(AbilityEffectType type)
		{
			Type = type;
			Parameter = null;
		}

		public AbilityEffect(AbilityEffectType type, int parameter)
		{
			Type = type;
			Parameter = parameter;
		}
	}
}
