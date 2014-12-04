using NUnit.Framework;
using System;
using models;
using GraphProject;
using System.Collections.Generic;

namespace Tests {

	[TestFixture ()]
	public class GraphStructureTests {
		private Graph<City> g;
		private City c;
		private Node<City> n;

		[SetUp]
		public void SetUp() {
			g = new Graph<City> ();
			c = new City ("poz", "wlkp", "aaa");
			n = new Node<City> (c);
		}

		[Test ()]
		[ExpectedException(typeof(KeyNotFoundException))]
		public void IndexerNodeTest_Invalid_Key() {
			Node<City> nc = g["war"];
		}

		[Test ()]
		public void IndexerNodeTest_setter() {
			g ["ddd"] = c;
			Assert.AreSame (c, g ["ddd"].Data);
		}

		[Test ()]
		[ExpectedException(typeof(KeyNotFoundException))]
		public void IndexerNodeTest_setter_exeption() {
			g ["ddd"] = c;
			Assert.AreSame (c, g ["poz"].Data);
		}

		[Test ()]
		public void AddNodeTest_T ()
		{
			g.AddNodeFromModel (c);
			Assert.AreSame (c, g["poz"].Data);
		}

		[Test ()]
		public void AddNodeTest_Node_T ()
		{
			g.AddNode (n);
			Assert.AreSame (n, g["poz"]);
		}

		[Test ()]
		public void AddNodeTest_invocation_chain ()
		{
			City c1 = new City ("war", "maz", "bbb");
			Graph<City> r = g.AddNodeFromModel (c1).AddNode (n);

			Assert.AreSame (n, g["poz"]);
			Assert.AreSame (c1, g["war"].Data);
			Assert.AreSame (r, g);

		}

		[Test ()]
		public void AddNodeTest_T_operator ()
		{
			g += c;
			Assert.AreSame (c, g["poz"].Data);
		}

		[Test ()]
		public void AddNodeTest_Node_T_operator ()
		{
			g += n;
			Assert.AreSame (n, g["poz"]);
		}

		[Test ()]
		public void AddNodeTest_invocation_chain_operator ()
		{
			City c1 = new City ("war", "maz", "bbb");
			Graph<City> r = g + c1 +n;

			Assert.AreSame (n, g["poz"]);
			Assert.AreSame (c1, g["war"].Data);
			Assert.AreSame (r, g);

		}
			
		[Test ()]	
		public void RemoveNodeTest_T ()
		{
			g.AddNodeFromModel (c);
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

		[Test ()]
		public void EnumerableTest() {
			g.AddNodeFromModel (c);
			g.AddNodeFromModel( new City("war", "maz", "bbb"));
			g.AddNodeFromModel( new City("kra", "mlp", "ccc"));

			foreach (var n in g) {
				Assert.True (n.Data.Name.Equals ("war") || n.Data.Name.Equals ("kra") || n.Data.Name.Equals ("poz"));
			}
		}

	}
}

