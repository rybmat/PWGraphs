using NUnit.Framework;
using System;
using models;
using GraphProject;

namespace Tests
{
	[TestFixture ()]
	public class NodeTests
	{
		private City c;
		private Node<City> n;

		[SetUp]
		public void SetUp() {
			c = new City ("Poznan", "wlkp", 5435);
			n = new Node<City> (c);
		}

		[Test]
		public void NodeTest ()
		{
			Assert.AreSame (c, n.data);
		}

		[Test]
		public void ToStringTest() {
			Assert.True (n.ToString () == c.ToString ());
		}
	}
}

