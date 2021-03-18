using book.web.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book.web.Controllers
{
	public class HomeController : Controller
	{
		private readonly BookContext bookContext;

		public HomeController(BookContext bookContext)
		{
			this.bookContext = bookContext;
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
