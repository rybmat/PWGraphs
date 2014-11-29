using System;

namespace models
{
	public class City {
		public City (string name, string land, uint population){
			Name = name;
			Land = land;
			Population = population;
		}

		public string Name { get; set; }

		public string Land { get; set; }

		public uint Population { get; set; }

		override public string ToString() {
			return Name;
		}
	}
}

