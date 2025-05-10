using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OnlineFoodOrderingDemo.Models;

namespace OnlineFoodOrderingDemo.Controllers
{
	public class MenuController : Controller
	{
		public static List<MenuItem> Menu = new List<MenuItem>
		{
			new MenuItem { Id = 1, Name = "牛肉麵", Description = "香濃紅燒湯頭", Price = 120 },
			new MenuItem { Id = 2, Name = "雞腿飯", Description = "酥脆雞腿配菜", Price = 100 },
			new MenuItem { Id = 3, Name = "陽春麵", Description = "經典台式小吃", Price = 50 }
		};

		public ActionResult Index()
		{
			return View(Menu);
		}

		public ActionResult AddToCart(int id)
		{
			var item = Menu.FirstOrDefault(m => m.Id == id);
			if (item == null) return RedirectToAction("Index");

			var cart = Session["Cart"] as List<MenuItem> ?? new List<MenuItem>();
			var existingItem = cart.FirstOrDefault(c => c.Id == id);

			if (existingItem != null)
			{
				existingItem.Quantity++;
			}
			else
			{
				var newItem = new MenuItem
				{
					Id = item.Id,
					Name = item.Name,
					Description = item.Description,
					Price = item.Price,
					Quantity = 1
				};
				cart.Add(newItem);
			}

			Session["Cart"] = cart;
			return RedirectToAction("Index", "Cart");
		}
	}
}
