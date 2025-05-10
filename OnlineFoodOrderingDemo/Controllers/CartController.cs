using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OnlineFoodOrderingDemo.Models;

namespace OnlineFoodOrderingDemo.Controllers
{
	public class CartController : Controller
	{
		// 查看購物車
		public ActionResult Index()
		{
			var cart = Session["Cart"] as List<MenuItem> ?? new List<MenuItem>();
			return View(cart);
		}

		// 增加數量
		public ActionResult AddQuantity(int id)
		{
			var cart = Session["Cart"] as List<MenuItem>;
			if (cart != null)
			{
				var item = cart.FirstOrDefault(m => m.Id == id);
				if (item != null)
					item.Quantity++;
			}
			return RedirectToAction("Index");
		}

		// 減少數量
		public ActionResult ReduceQuantity(int id)
		{
			var cart = Session["Cart"] as List<MenuItem>;
			if (cart != null)
			{
				var item = cart.FirstOrDefault(m => m.Id == id);
				if (item != null)
				{
					item.Quantity--;
					if (item.Quantity <= 0)
						cart.Remove(item);
				}
			}
			return RedirectToAction("Index");
		}

		// 移除單項
		public ActionResult Remove(int id)
		{
			var cart = Session["Cart"] as List<MenuItem>;
			if (cart != null)
			{
				var item = cart.FirstOrDefault(m => m.Id == id);
				if (item != null)
					cart.Remove(item);
			}
			return RedirectToAction("Index");
		}
		public ActionResult Checkout()
		{
			var cart = Session["Cart"] as List<MenuItem> ?? new List<MenuItem>();
			decimal total = cart.Sum(item => item.Price * item.Quantity);
			ViewBag.Total = total;
			return View(cart);
		}

		public ActionResult Increase(int id)
		{
			var cart = Session["Cart"] as List<MenuItem>;
			var item = cart?.FirstOrDefault(c => c.Id == id);
			if (item != null) item.Quantity++;
			Session["Cart"] = cart;
			return RedirectToAction("Index");
		}

		public ActionResult Decrease(int id)
		{
			var cart = Session["Cart"] as List<MenuItem>;
			var item = cart?.FirstOrDefault(c => c.Id == id);
			if (item != null && item.Quantity > 1)
				item.Quantity--;
			else if (item != null)
				cart.Remove(item);
			Session["Cart"] = cart;
			return RedirectToAction("Index");
		}

		public ActionResult ConfirmOrder()
		{
			var cart = Session["Cart"] as List<MenuItem> ?? new List<MenuItem>();
			decimal total = cart.Sum(i => i.Price * i.Quantity);

			// 清空購物車
			Session["Cart"] = null;

			ViewBag.Total = total;
			return View();
		}



		// 清空整個購物車
		public ActionResult Clear()
		{
			Session["Cart"] = null;
			return RedirectToAction("Index");
		}
	}
}
