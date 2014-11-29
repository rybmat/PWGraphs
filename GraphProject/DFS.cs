using System;
using System.Collections.Generic;
using System.Linq;
using GraphProject;

namespace GraphProject {

	public partial class Graph<T> {

		public IEnumerable<Node<T>> DFS(Node<T> node) {
			Stack<Node<T>> stack = new Stack<Node<T>>();
			HashSet<Node<T>> visited = new HashSet<Node<T>>();

			stack.Push(node);

			while (stack.Count > 0) {
				Node<T> current = stack.Pop();

				if (!visited.Contains(current)) {
					yield return current;

					visited.Add(current);

					foreach (var n in current.successors) {
						stack.Push(n);
					}
				}
			}

		}
	}
}
