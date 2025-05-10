namespace OnlineFoodOrderingDemo.Models
{
	public class MenuItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Price { get; set; }

		// 👇 這是目前缺少的屬性
		public int Quantity { get; set; } = 1;
	}
}
