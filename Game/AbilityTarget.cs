namespace Game
{
	public enum AbilityTarget
	{
		// The ability can target enemy units only
		EnemyUnit,
		// The ability can target friendly units only
		FriendlyUnit,
		// The ability requires both an enemy unit and a position in the enemy half of the board
		// This is used for the forceful displacement ability
		EnemyUnitAndPosition,
		// The ability requires both a friendly unit and a position in the player's own half of the board
		FriendlyUnitAndPosition,
		// The ability targets a particular lane
		Lane,
		// The ability requires no target because it has a global effect
		Global,
		// The ability targets a state (for removal)
		State,
		// The ability targets an attachment (for removal)
		Attachment,
	}
}
