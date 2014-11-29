using NUnit.Framework;
using System;
using models;
using GraphProject;
using System.Collections.Generic;

namespace Tests
{
	[TestFixture ()]
	public class GraphTests
	{
		private Graph<City> g;
		private City c;
		private Node<City> n;

		[SetUp]
		public void SetUp() {
			g = new Graph<City> ();
			c = new City ("poz", "wlkp", 1234);
			n = new Node<City> (c);
		}

		[Test ()]
		public void AddNodeTest_T ()
		{
			g.AddNode (c);
			Assert.AreSame (c, g["poz"].data);
		}

		[Test ()]
		[ExpectedException(typeof(KeyNotFoundException))]
		public void IndexerNodeTest_Invalid_Key() {
			Node<City> nc = g["war"];
		}

		[Test ()]
		public void AddNodeTest_Node_T ()
		{
			g.AddNode (n);
			Assert.AreSame (n, g["poz"]);
		}

		[Test ()]	
		public void RemoveNodeTest_T ()
		{
			g.AddNode (c);
			Assert.True(g.RemoveNode (c));
		}

		[Test ()]
		public void RemoveNodeTest_T_non_existing ()
		{
			Assert.False(g.RemoveNode (c));
		}

		[Test ()]
		public void RemoveNodeTest_Node_T ()
		{
			g.AddNode (n);
			Assert.True(g.RemoveNode (n));
		}

		[Test ()]
		public void RemoveNodeTest_Node_T_non_existing ()
		{
			Assert.False(g.RemoveNode (n));
		}

		[Test ()]
		public void RemoveNodeTest_str ()
		{
			g.AddNode (n);
			Assert.True(g.RemoveNode ("poz"));
		}

		[Test ()]
		public void RemoveNodeTest_str_non_existing ()
		{
			g.AddNode (n);
			Assert.False(g.RemoveNode ("war"));
		}

	}
}

