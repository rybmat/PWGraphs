using NUnit.Framework;
using System;
using models;
using GraphProject;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Tests {

	[TestFixture ()]
	public partial class GraphAlgorithmsTests {
		private Graph<Vertex> eulerianWithCycle;
		private Graph<Vertex> nonEulerian;
		private Graph<Vertex> withoutCycle;

		[SetUp]
		public void SetUp() {
			eulerianWithCycle = new Graph<Vertex> ();
			eulerianWithCycle.AddNodeFromModel(new Vertex ("1")).AddNodeFromModel(new Vertex ("2")).AddNodeFromModel(new Vertex ("3")).AddNodeFromModel(new Vertex ("4")).AddNodeFromModel(new Vertex ("5")).AddNodeFromModel(new Vertex("6"));
			nonEulerian = new Graph<Vertex> ();
			nonEulerian.AddNodeFromModel(new Vertex ("1")).AddNodeFromModel(new Vertex ("2")).AddNodeFromModel(new Vertex ("3")).AddNodeFromModel(new Vertex ("4")).AddNodeFromModel(new Vertex ("5")).AddNodeFromModel(new Vertex("6"));
			withoutCycle = new Graph<Vertex> ();
			withoutCycle.AddNodeFromModel(new Vertex ("1")).AddNodeFromModel(new Vertex ("2")).AddNodeFromModel(new Vertex ("3")).AddNodeFromModel(new Vertex ("4")).AddNodeFromModel(new Vertex ("5"));


			//    .	  .
			//  ./ \./|
			//   \./ \.
			eulerianWithCycle ["1"].AddSuccessor (eulerianWithCycle ["2"]).AddSuccessor(eulerianWithCycle["6"]);
			eulerianWithCycle ["2"].AddSuccessor (eulerianWithCycle ["3"]).AddSuccessor(eulerianWithCycle["6"]);
			eulerianWithCycle ["3"].AddSuccessor (eulerianWithCycle ["4"]);
			eulerianWithCycle ["4"].AddSuccessor (eulerianWithCycle ["5"]);
			eulerianWithCycle ["5"].AddSuccessor (eulerianWithCycle ["2"]);

			//    .	  .
			//  ./_\./|
			//   \./ \.
			nonEulerian ["1"].AddSuccessor (nonEulerian ["2"]).AddSuccessor(nonEulerian["6"]);
			nonEulerian ["2"].AddSuccessor (nonEulerian ["3"]).AddSuccessor(nonEulerian["4"]).AddSuccessor(nonEulerian["6"]);
			nonEulerian ["3"].AddSuccessor (nonEulerian ["4"]);
			nonEulerian ["4"].AddSuccessor (nonEulerian ["5"]);
			nonEulerian ["5"].AddSuccessor (nonEulerian ["2"]);

			//	  .
			//	./_\.
			//    ./ \.

			withoutCycle ["1"].AddSuccessor(withoutCycle ["2"]).AddSuccessor(withoutCycle ["3"]);
			withoutCycle ["2"].AddSuccessor(withoutCycle ["3"]);
			withoutCycle ["3"].AddSuccessor(withoutCycle ["4"]).AddSuccessor(withoutCycle ["5"]);
		}

		[Test ()]
		public void DFStest() {
			CollectionAssert.AreEqual(new ArrayList{ "1", "6", "2", "4", "5", "3"},
				nonEulerian.DFS(nonEulerian["1"]).Select(
					n => n.Data.ToString()
				).ToList());

			CollectionAssert.AreEqual(new ArrayList{ "1", "3", "5", "4", "2" },
				withoutCycle.DFS(withoutCycle["1"]).Select(
					n => n.Data.ToString()
				).ToList());
		}

		[Test ()]
		public void BFStest() {
			CollectionAssert.AreEqual(new ArrayList{ "1", "2", "6", "3", "4", "5"},
				nonEulerian.BFS(nonEulerian["1"]).Select(
					n => n.Data.ToString()
				).ToList());

			CollectionAssert.AreEqual(new ArrayList{ "1", "2", "3", "4", "5" },
				withoutCycle.BFS(withoutCycle["1"]).Select(
					n => n.Data.ToString()
				).ToList());
		}

		[Test ()]
		[ExpectedException(typeof(GraphHasCycleException))]
		public void TopologicalSorttest() {
			CollectionAssert.AreEqual(new ArrayList{ "1", "2", "3", "4", "5" },
				withoutCycle.SortTopologically().Select(
					n => n.Data.ToString()
				).ToList());

			CollectionAssert.AreEqual(new ArrayList{ "1", "2", "6", "3", "4", "5"},
				nonEulerian.SortTopologically().Select(
					n => n.Data.ToString()
				).ToList());


		}

		[Test ()]
		[ExpectedException(typeof(GraphIsNotEulerianException))]
		public void EulerianDirectedPathSorttest() {
			CollectionAssert.AreEqual(new ArrayList{ "1", "2", "3", "4", "5", "2", "6" },
				eulerianWithCycle.EulerianDirectedPath().Select(
					n => n.Data.ToString()
				).ToList());

			CollectionAssert.AreEqual(new ArrayList{ "1", "2", "6", "3", "4", "5"},
				nonEulerian.EulerianDirectedPath().Select(
					n => n.Data.ToString()
				).ToList());


		}

	}
}

