using System;
using GraphProject;

namespace Graphs {
	public class NodeVisualization<T>: Node<T> {

		public NodeVisualization (T data) {
			base.Data = data;
		}
	}
}

