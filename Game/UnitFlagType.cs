namespace Game
{
	public enum UnitFlagType
	{
		// Reduces the damage from attacks by units by n, does not reduce damage from abilities
		Armour,
		// Attacks affect all enemy units in the lane
		Charge,
		// Immobilises enemy unit for one turn when dealing damage
		// Entangle,
		// Does not suffer the damage penalty from being blocked, can target any enemy unit in its lane and the two adjacent lanes
		Flying,
		// Heals up to n missing life of other friendly units located in the same lane
		Heal,
		// All damage dealt to this unit is dealt to its owner aswell, healing effects work, too
		// HealthLink,
		// Immune to the effects of abilities used against it, cannot have any attachments either, though
		// Immune,
		// Able to perform an attack right after deployment
		Initiative,
		// Increases the damage of all friendly units by n
		Leader,
		// This unit heals whenever it causes damage and the amount healed is equal to the damage dealt but it cannot gain more than its maximum life
		// LifeSteal,
		// When an enemy unit is killed the remaining damage is applied to the unit behind it or, if there is no such unit, to the enemy player
		Overrun,
		// When causing damage, the target will become poisoned for n turns, taking one damage from the poison at the beginning of each turn of the target's owner, poison damage does not stack, only the number of turns can be refreshed, the duration does not stack additively either
		// Poison,
		// Does not suffer the damage penalty from being blocked and can target any enemy unit in its lane
		Ranged,
		// When attacked by a unit it will reflect the damage to the attacker
		// ReflectDamage,
		// Regenerates n life at the beginning of every turn of its owner
		Regenerate,
		// Every time an allied unit dies this unit gains +n attack for its next attack
		// Revenge,
		// Can perform an attack after moving, but cannot attack and then move
		// Rush,
		// Can block up to n damage until the shield is destroyed, it regenerates at the beginning of every turn of its owner, can also block damage from abilities
		// Shield,
		// Dies after performing one attack
		// Suicide,
		// Prevents the opponent from deploying more units into the same lane
		// Tactician,
		// Deals n damage to melee and flying attackers
		Thorns,
		// Reduces the damage of a unit by n down to a minimum of 0 for one turn when dealing damage to an enemy unit
		// Weaken,
	}
}
