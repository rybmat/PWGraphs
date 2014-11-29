using System;

namespace GraphProject
{
	public class Node<T>
	{
		public T data { get; set; }

		public Node (T m)
		{
			data = m;
		} 

		override public string ToString() {
			return data.ToString ();
		}
	}
}

