using System;
using System.Collections.Generic;
using GraphProject;

namespace GraphProject {

	public partial class Graph<T> {

		public IEnumerable<Tuple<Node<T>, Node<T>>> BFS(Node<T> node) {
			Queue<Tuple<Node<T>, Node<T>>> queue = new Queue<Tuple<Node<T>, Node<T>>>();
			HashSet<Node<T>> visited = new HashSet<Node<T>>();

			visited.Add(node);
			queue.Enqueue(new Tuple<Node<T>, Node<T>>(null, node));

			while (queue.Count > 0) {
				Tuple<Node<T>, Node<T>> current = queue.Dequeue();
				yield return current;

				foreach (var n in current.Item2.successors) {
					if (!visited.Contains(n)) {
						visited.Add(n);
						queue.Enqueue(new Tuple<Node<T>, Node<T>>(current.Item2, n));
					}
				}

			}
		}
	}
}