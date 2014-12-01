﻿using System;

namespace models {

	public class Vertex {

		public string Label { get; set; }

		public Vertex (string label) {
			Label = label;
		}

		override public string ToString() {
			return Label;
		}
	}
}

