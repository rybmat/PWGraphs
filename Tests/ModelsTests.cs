﻿using NUnit.Framework;
using System;
using models;

namespace Tests { 

	[TestFixture ()]
	public class ModelsTests {

		[Test ()]
		public void CityTest () {
			City c = new City ("Poznan", "Wlkp", "123000");
			Assert.True (c.Name.Equals("Poznan"));
			Assert.True (c.Land.Equals("Wlkp"));
			Assert.True (c.FunFact.Equals("123000"));
			Assert.True (c.ToString ().Equals("Poznan")); 
		}
	}
}

