using NUnit.Framework;
using System;
using models;
using GraphProject;
using System.Collections.Generic;

namespace Tests {

	[TestFixture ()]
	public partial class GraphTestsStructure {
		private Graph<City> g;
		private City c;
		private Node<City> n;

		[SetUp]
		public void SetUp() {
			g = new Graph<City> ();
			c = new City ("poz", "wlkp", 1234);
			n = new Node<City> (c);
		}

	}
}

