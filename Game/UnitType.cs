using System.Collections.Generic;

namespace Game
{
	public class UnitType
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int Limit { get; set; }
		public int Resources { get; set; }
		public int Damage { get; set; }
		public int Life { get; set; }
		public List<UnitFlag> Flags { get; set; }

		public UnitType()
		{
			Flags = new List<UnitFlag>();
		}
    }
}
