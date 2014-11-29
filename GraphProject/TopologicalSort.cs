using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphProject {

	public partial class Graph<T> {

		// Kahn algorithm
		public IEnumerable<Node<T>> SortTopologically() {
			var incoming = new Dictionary<Node<T>, List<Node<T>>>();
			var outgoing = new Dictionary<Node<T>, List<Node<T>>>();

			foreach (var node in nodes.Values) {
				incoming.Add(node, new List<Node<T>>());
				outgoing.Add(node, new List<Node<T>>());
			}

			foreach (Node<T> node in nodes.Values) {
				outgoing[node].AddRange(node.successors);

				foreach (Node<T> n in node.successors) {
					incoming[n].Add(node);
				}
			}

			var queue = new Queue<Node<T>>();

			foreach (var n in incoming.Where(e => e.Value.Count == 0).Select(e => e.Key)) {
				queue.Enqueue(n);
			}

			while (queue.Count > 0) {
				var current = queue.Dequeue();

				yield return current;

				foreach (var adjacent in outgoing[current].ToList()) {
					outgoing[current].Remove(adjacent);
					incoming[adjacent].Remove(current);

					if (!incoming[adjacent].Any()) {
						queue.Enqueue(adjacent);
					}
				}
			}

			if (outgoing.Any(e => e.Value.Count > 0)) {
				throw new GraphHasCycleException();
			}

		}
	}


	public class GraphHasCycleException : Exception {

		public GraphHasCycleException() {
		}
	}
}