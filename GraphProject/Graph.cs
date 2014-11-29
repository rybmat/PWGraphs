using System;
using System.Collections;
using System.Collections.Generic;
using GraphProject;

namespace GraphProject
{
	public class Graph<T>: IEnumerable<Node<T>>
	{
		private Dictionary<string, Node<T>> nodes = new Dictionary<string, Node<T>>();

		public Node<T> this [string id] {
			get {
				if (nodes.ContainsKey (id))
					return nodes [id];
				else
					throw new KeyNotFoundException();
			}
		}

		public Graph<T> AddNode (T n) {
			nodes [n.ToString ()] = new Node<T> (n);
			return this;
		}

		public Graph<T> AddNode (Node<T> n) {
			nodes [n.ToString ()] = n;
			return this;
		}

		public static Graph<T> operator +(Graph<T> g, T n) {
			g.AddNode (n);
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

		//IEnumerable
		public IEnumerator<Node<T>> GetEnumerator() {
			return nodes.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		//Algorithms
		public List<Node<T>> DFS(Node<T> node){
			return new List<Node<T>>();
		}

		public List<Node<T>> BFS(Node<T> node){
			return new List<Node<T>>();
		}

		public List<Node<T>> SortTopologically(){
			return new List<Node<T>>();
		}

		public List<Node<T>> EulerianDirectedPath(){
			return new List<Node<T>>();
		}
	}
}

