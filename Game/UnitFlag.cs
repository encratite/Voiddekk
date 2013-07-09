namespace Game
{
	enum UnitFlagType
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

	class UnitFlag
	{
		public UnitFlagType Type { get; set; }
		public int Parameter { get; set; }
	}
}
