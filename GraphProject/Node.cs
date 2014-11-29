using System;
using System.Collections.Generic;

namespace GraphProject {
	public class Node<T> {
		public T Data { get; set; }

		public List<Node<T>> successors = new List<Node<T>>();

		public Node (T m) { 
			Data = m;
		} 

		public Node<T> AddSuccessor(Node<T> n) {
			successors.Add (n);
			return this;
		}
			
		public bool RemoveSuccesor(Node<T> n) {
			return successors.Remove (n);
		}

		override public string ToString() {
			return Data.ToString ();
		}
	}
}

