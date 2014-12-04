using NUnit.Framework;
using System;
using models;
using GraphProject;

namespace Tests {

	[TestFixture ()]
	public class NodeTests {
		private City c;
		private Node<City> n;

		[SetUp]
		public void SetUp() {
			c = new City ("Poznan", "wlkp", "aaa");
			n = new Node<City> (c);
		}

		[Test]
		public void NodeTest () {
			Assert.AreSame (c, n.Data);
		}

		[Test]
		public void ToStringTest() {
			Assert.True (n.ToString () == c.ToString ());
		}

		[Test]
		public void AddSuccessorTest() {
			Node<City> ct = new Node<City> (new City ("war", "maz", "bbb"));
			Node<City> r = n.AddSuccessor (ct);
			Assert.Contains (ct, n.successors);
			Assert.Contains (ct, r.successors);

			Assert.Contains (n, ct.predecessors);
			Assert.AreSame (n, r);
		}

		[Test]
		public void AddSuccessorTest_inokation_chain() {
			Node<City> ct = new Node<City> (new City ("war", "maz", "24351"));
			Node<City> ct2 = new Node<City> (new City ("kra", "mlp", "24351"));

			Node<City> r = n.AddSuccessor (ct).AddSuccessor(ct2);
			Assert.Contains (ct, n.successors);
			Assert.Contains (n, ct.predecessors);
			Assert.Contains (ct, r.successors);

			Assert.Contains (ct2, n.successors);
			Assert.Contains (n, ct2.predecessors);
			Assert.Contains (ct2, r.successors);

			Assert.AreSame (n, r);
		}

		[Test]
		public void RemoveSuccessorTest() {
			Node<City> ct = new Node<City> (new City ("war", "maz", "24351"));
			Node<City> r = n.AddSuccessor (ct);
			Assert.True (n.RemoveSuccesor (ct));

			Assert.False (n.successors.Contains(ct));
			Assert.False (ct.predecessors.Contains(n));
			Assert.False (r.successors.Contains(ct));
			Assert.AreSame (n, r);
		}

		[Test]
		public void RemoveSuccessorTest_not_contained() {
			Node<City> ct = new Node<City> (new City ("war", "maz", "24351"));
			Assert.False (n.RemoveSuccesor (ct));
			Assert.False (n.successors.Contains(ct));
		}
			
	}
}

