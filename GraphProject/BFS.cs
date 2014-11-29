using System;
using System.Collections.Generic;
using GraphProject;

namespace GraphProject {

	public partial class Graph<T> {

		public IEnumerable<Node<T>> BFS(Node<T> node) {
			Queue<Node<T>> queue = new Queue<Node<T>>();
			HashSet<Node<T>> visited = new HashSet<Node<T>>();

			visited.Add(node);
			queue.Enqueue(node);

			while (queue.Count > 0) {
				Node<T> current = queue.Dequeue();
				yield return current;

				foreach (var n in current.successors) {
					if (!visited.Contains(n)) {
						visited.Add(n);
						queue.Enqueue(n);
					}
				}

			}
		}
	}
}