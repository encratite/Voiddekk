using System.Collections.Generic;
using System.Xml.Serialization;

namespace Game
{
	[XmlType(TypeName = "State")]
	public class StateCard : BaseCard
	{
		// Describes what areas of the board are affected by this card
		// For example, its effects may be limited to a lane
		public StateScope Scope { get; set; }
		// This field is optional and should only be used if this state applies unit flags
		// It controls what units in the affected area are affected by the flags
		public StateUnitTarget UnitTarget { get; set; }
		// These are flags applied to units in the affected area, according to the filter specified in the Target field
		public List<UnitFlag> UnitFlags { get; set; }
		// The duration of a state card is an optional parameter that determines how many turns it takes for the state to expire
		// The duration check is performed at the beginning of every turn of the player that owns it
		// The turn it was played in counts as "turn zero"
		// If this field is null, it does not expire on its own and needs to be triggered or forcefully removed
		public int? Duration { get; set; }
		// This is an optional parameter that must be specified if Duration is null
		// It specifies a trigger event that will cause this state to be removed
		// This can also have additional effects specified in the TriggerEffects field
		public StateTrigger Trigger { get; set; }
		// If a trigger is set, this field specifies the abilities triggered by it
		// No target is given because it is implicitly given by the trigger
		public List<AbilityEffect> TriggerEffects { get; set; }

		public StateCard()
		{
			UnitFlags = new List<UnitFlag>();
			TriggerEffects = new List<AbilityEffect>();
		}
	}
}

