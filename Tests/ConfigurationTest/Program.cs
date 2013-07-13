using System;

using Game;
using Nil;

namespace ConfigurationTest
{
	class Program
	{
		static string ConfigurationPath = "Configuration.xml";

		static void RunTest()
		{
			Serialiser<Configuration> serialiser = new Serialiser<Configuration>(ConfigurationPath);
			Configuration configuration = new Configuration();

			UnitCard unit = new UnitCard();
			unit.Name = "Name";
			unit.InternalName = "FactionName";
			unit.Resources = 1;
			unit.Damage = 1;
			unit.Life = 1;
			UnitFlag flag1 = new UnitFlag(UnitFlagType.Regenerate, 1);
			unit.Flags.Add(flag1);
			configuration.Units.Add(unit);

			AbilityCard ability = new AbilityCard();
			ability.Name = "Name";
			ability.InternalName = "FactionName";
			ability.Resources = 1;
			ability.Target = AbilityTarget.Global;
			AbilityEffect effect = new AbilityEffect(AbilityEffectType.DamageUnit, 1);
			ability.Effects.Add(effect);
			configuration.Abilities.Add(ability);

			AttachmentCard attachment = new AttachmentCard();
			attachment.Name = "Name";
			attachment.InternalName = "FactionName";
			attachment.Resources = 1;
			attachment.Type = AttachmentCardType.Friendly;
			UnitFlag flag2 = new UnitFlag(UnitFlagType.Strong, 1);
			attachment.Flags.Add(flag2);
			configuration.Attachments.Add(attachment);

			StateCard state = new StateCard();
			state.Name = "Name";
			state.InternalName = "FactionName";
			state.Resources = 1;
			state.Scope = StateScope.Global;
			state.UnitTarget = StateUnitTarget.Friendly;
			state.UnitFlags.Add(flag2);
			state.Trigger = StateTrigger.OnAttack;
			state.TriggerEffects.Add(effect);

			configuration.States.Add(state);

			serialiser.Store(configuration);

			configuration = serialiser.Load();
			Console.WriteLine("Limit: {0}", configuration.Units[0].Limit);
		}

		static void Main(string[] arguments)
		{
			RunTest();
		}
	}
}
