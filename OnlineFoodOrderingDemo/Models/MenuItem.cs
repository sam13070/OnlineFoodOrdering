﻿namespace OnlineFoodOrderingDemo.Models
{
	public class MenuItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }
		public int Quantity { get; set; } = 1;
	}
}
