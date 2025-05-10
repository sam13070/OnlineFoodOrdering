using System.Web.Mvc;

namespace OnlineFoodOrderingDemo.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return RedirectToAction("Index", "Menu");
		}
	}
}
