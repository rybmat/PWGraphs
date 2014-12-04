using System;
using System.Collections;
using System.Collections.Generic;
using GraphProject;

namespace GraphProject {

	public partial class Graph<T>: IEnumerable<Node<T>> {

		private Dictionary<string, Node<T>> nodes = new Dictionary<string, Node<T>>(); 

		public Graph () {
		
		}

		public Node<T> this [string id] {
			get {
				if (nodes.ContainsKey (id))
					return nodes [id];
				else
					throw new KeyNotFoundException();
			}

			set {
				nodes [id] = value;
			}
		}

		public Graph<T> AddNodeFromModel (T n) {
			nodes [n.ToString ()] = new Node<T> (n);
			return this;
		}

		public Graph<T> AddNode (Node<T> n) {
			nodes [n.ToString ()] = n;
			return this;
		}

		public static Graph<T> operator +(Graph<T> g, T n) {
			g.AddNodeFromModel (n);
			return g;
		}

		public static Graph<T> operator +(Graph<T> g, Node<T> n) {
			g.AddNode (n);
			return g;
		}

		public bool RemoveNode (T n) {
			return nodes.Remove (n.ToString ());
		}

		public bool RemoveNode (Node<T> n) {
			return nodes.Remove (n.ToString ());
		}

		public bool RemoveNode (string n) {
			return nodes.Remove (n);
		}

		public void Clear() {
			nodes.Clear ();
		}

		//IEnumerable
		public IEnumerator<Node<T>> GetEnumerator() {
			return nodes.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
			
	}
}

