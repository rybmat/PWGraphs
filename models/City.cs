using System;

namespace models {

	public class City {
		public City (string name, string land, string funFact){
			Name = name;
			Land = land;
			FunFact = funFact;
		}

		public City(){
		}

		public string Name { get; set; }

		public string Land { get; set; }

		public string FunFact { get; set; }

		override public string ToString() {
			return Name;
		}
	}
}

