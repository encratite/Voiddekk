namespace Game
{
	public enum StateTrigger
	{
		// Any unit in the affected area performs an attack
		OnAttack,
		// Any melee unit in the affected area performs an attack
		OnMeleeAttack,
		// Any ranged unit in the affected area performs an attack
		OnRangedAttack,
		// Any flying unit in the affected area performs an attack
		OnFlyingAttack,
		// A player deploys a unit (global scope only)
		OnUnitDeployed,
		// A player uses an ability, attachment or state card (global scope only)
		OnSpellUsed,
		// A player plays a card (global scope only)
		OnCardPlayed,
	}
}

