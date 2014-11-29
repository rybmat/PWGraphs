using System;
using System.Collections.Generic;
using System.Linq;
using GraphProject;

namespace GraphProject {

	public partial class Graph<T> {

		// Hierholzer algorithm (reversed output)
		public IEnumerable<Node<T>> EulerianDirectedPath() {
			var incoming = new Dictionary<Node<T>, List<Node<T>>>();
			var outgoing = new Dictionary<Node<T>, List<Node<T>>>();

			foreach (Node<T> node in this) {
				incoming.Add(node, new List<Node<T>>());
				outgoing.Add(node, new List<Node<T>>());
			}

			foreach (Node<T> node in nodes.Values) {
				outgoing[node].AddRange(node.successors);

				foreach (Node<T> n in node.successors) {
					incoming[n].Add(node);
				}
			}

			Node<T> found_io = null;
			Node<T> found_oi = null;
			Node<T> start = null;

			foreach (Node<T> node in nodes.Values) {
				if (incoming[node].Count - outgoing[node].Count == 1) {
					if (found_io != null)
						throw new GraphIsNotEulerianException();
					found_io = node;
				} else
					if (outgoing[node].Count - incoming[node].Count == 1) {
						if (found_oi != null)
							throw new GraphIsNotEulerianException();
						found_oi = node;
						start = node;
					} else
						if (outgoing[node].Count != incoming[node].Count) {
							throw new GraphIsNotEulerianException();
						} else
							if (start == null) {
								start = node;
							}
			}

			var stack = new Stack<Node<T>>();
			var current = start;

			do {
				if (outgoing[current].Count == 0) {
					yield return current;

					current = stack.Pop();
				} else {
					stack.Push(current);

					var previous = current;
					current = outgoing[current].Last();
					outgoing[previous].Remove(current);
				}
			} while (stack.Count > 0);

			yield return start;
		}
	}


	public class GraphIsNotEulerianException : Exception {

		public GraphIsNotEulerianException() {
		}
	}
}
