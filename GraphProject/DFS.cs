using System;
using System.Collections.Generic;
using System.Linq;
using GraphProject;

namespace GraphProject {

	public partial class Graph<T> {

		public IEnumerable<Tuple<Node<T>, Node<T>>> DFS(Node<T> node) {
			Stack<Tuple<Node<T>, Node<T>>> stack = new Stack<Tuple<Node<T>, Node<T>>>();
			HashSet<Node<T>> visited = new HashSet<Node<T>>();

			stack.Push(new Tuple<Node<T>, Node<T>>(null, node));

			while (stack.Count > 0) {
				Tuple<Node<T>, Node<T>> current = stack.Pop();

				if (!visited.Contains(current.Item2)) {
					yield return current;

					visited.Add(current.Item2);

					foreach (var n in current.Item2.successors) {
						stack.Push(new Tuple<Node<T>, Node<T>>(current.Item2, n));
					}
				}
			}

		}
	}
}
