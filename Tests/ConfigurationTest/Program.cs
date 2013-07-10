using System;

using Game;
using Nil;

namespace ConfigurationTest
{
	class Program
	{
		static string ConfigurationPath = "Configuration.xml";

		static void ReadTest()
		{
			Serialiser<Configuration> serialiser = new Serialiser<Configuration>(ConfigurationPath);
			Configuration configuration = serialiser.Load();
			Console.WriteLine("Limit: {0}", configuration.Units[0].Limit);
		}

		static void WriteTest()
		{
			Serialiser<Configuration> serialiser = new Serialiser<Configuration>(ConfigurationPath);
			Configuration configuration = new Configuration();
			UnitType unit = new UnitType();
			unit.Name = "Name";
			unit.InternalName = "FactionName";
			unit.Damage = 1;
			unit.Life = 1;
			UnitFlag flag = new UnitFlag(UnitFlagType.Regenerate, 1);
			unit.Flags.Add(flag);
			configuration.Units.Add(unit);
			serialiser.Store(configuration);
		}

		static void Main(string[] arguments)
		{
			ReadTest();
		}
	}
}
