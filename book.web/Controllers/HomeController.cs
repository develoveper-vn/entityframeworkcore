using book.web.Data;
using book.web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

		public List<TotalProfitViewModel> GetTotalProfitByCategory()
		{
			var categories = bookContext
				.Categories
				.Select(c => new
				{
					c.Name,
					Profit = c.CategoryBooks
								.Select(cb => new
								{
									ProfitPerBook = cb.Book.Price * cb.Book.Copies,
								})
								.Sum(cb => cb.ProfitPerBook)
				})
				.OrderByDescending(c => c.Profit)
				.ThenBy(c => c.Name)
				.ToList();

			var result = new List<TotalProfitViewModel>();

			foreach (var category in categories)
			{
				var model = new TotalProfitViewModel();

				model.Name = category.Name;
				model.Profit = $"{category.Profit:f2}";

				result.Add(model);
			}

			return result;
		}

		public List<GetMostRecentViewModel> GetMostRecentBooks()
		{
			var categories = bookContext
			   .Categories
			   .Select(c => new
			   {
				   Books = c.CategoryBooks
						   .OrderByDescending(cb => cb.Book.ReleaseDate)
						   .Select(cb => new
						   {
							   cb.Book.Title,
							   cb.Book.ReleaseDate.Value.Year
						   })
						   .Take(3)
						   .ToList(),
				   c.Name
			   })
			   .OrderBy(c => c.Name);

			var listMostRecent = new List<GetMostRecentViewModel>();

			foreach (var item in categories)
			{

				foreach (var book in item.Books)
				{
					var model = new GetMostRecentViewModel();

					model.Name = item.Name;
					model.Title = book.Title;
					model.Year = book.Year;

					listMostRecent.Add(model);
				}

			}

			return listMostRecent;
		}
	}
}
