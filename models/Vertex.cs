﻿using System;

namespace models {

	public class Vertex {

		public string Label { get; set; }

		public Vertex (string label) {
			Label = label;
		}

		public Vertex() {
		}

		override public string ToString() {
			return Label;
		}
	}
}

