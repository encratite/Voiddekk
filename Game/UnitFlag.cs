namespace Game
{
	public enum UnitFlagType
	{
		Armour,
		Charge,
		Entangle,
		Flying,
		Heal,
		HealthLink,
		Immune,
		Initiative,
		LifeSteal,
		Overrun,
		Poison,
		Ranged,
		ReflectDamage,
		Regenerate,
		Rush,
		Shield,
		Suicide,
		Thorns,
		Weaken,
	}

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
