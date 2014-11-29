using NUnit.Framework;
using System;
using models;

namespace Tests
{
	[TestFixture ()]
	public class ModelsTests
	{
		[Test ()]
		public void CityTest ()
		{
			City c = new City ("Poznan", "Wlkp", 547000);
			Assert.True (c.Name == "Poznan");
			Assert.True (c.Land == "Wlkp");
			Assert.True (c.Population == 547000);
			Assert.True (c.ToString () == "Poznan"); 
		}
	}
}

