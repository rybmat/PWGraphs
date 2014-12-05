using System;
using System.Collections.Generic;

namespace GraphProject {
	public class Node<T> {
		public T Data { get; set; }

		public List<Node<T>> successors = new List<Node<T>>();
		public List<Node<T>> predecessors = new List<Node<T>>();

		public Node (T m) { 
			Data = m;
		} 

		public Node<T> AddSuccessor(Node<T> n) {
			successors.Add (n);
			n.predecessors.Add (this);
			return this;
		}
			
		public bool RemoveSuccesor(Node<T> n) {
			n.predecessors.Remove (this);
			return successors.Remove (n);
		}

		public Node<T> AddPredecessor(Node<T> n) {
			predecessors.Add (n);
			n.successors.Add (this);
			return this;
		}

		public bool RemovePredecessor(Node<T> n) {
			n.successors.Remove (this);
			return predecessors.Remove (n);
		}

		public void RemoveNieghbours() {
			foreach (var p in predecessors) {
				p.successors.Remove (this);
			}
			predecessors.Clear ();

			foreach (var s in successors) {
				s.predecessors.Remove (this);
			}
			successors.Clear ();
		}

		override public string ToString() {
			return Data.ToString ();
		}

		public static implicit operator Node<T>(T model) {
			return new Node<T>(model);
		}
	}
}

