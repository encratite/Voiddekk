using Game;
using Nil;

namespace ConfigurationTest
{
	class Program
	{
		static void Main(string[] arguments)
		{
			Serialiser<Configuration> serialiser = new Serialiser<Configuration>("Configuration.xml");
			Configuration configuration = new Configuration();
			UnitType unit = new UnitType();
			unit.Name = "Name";
			unit.InternalName = "FactionName";
			unit.Limit = 4;
			unit.Damage = 1;
			unit.Life = 1;
			UnitFlag flag = new UnitFlag(UnitFlagType.Regenerate, 1);
			unit.Flags.Add(flag);
			configuration.Units.Add(unit);
			serialiser.Store(configuration);
		}
	}
}
