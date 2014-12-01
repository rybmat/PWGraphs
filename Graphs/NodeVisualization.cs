using System;
using GraphProject;
using System.Drawing;

namespace Graphs {
	public class NodeVisualization<T>: Node<T> {

		Point Position { get; set; }

		public NodeVisualization (T data): base(data) {
		}
	}
}

