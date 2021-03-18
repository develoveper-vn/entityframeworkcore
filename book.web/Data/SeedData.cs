using book.web.Data.Generators;
using book.web.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace book.web.Data
{
	public static  class SeedData
	{
		public static IHost MigrateDatabase(this IHost host)
		{
			using (var scope = host.Services.CreateScope())
			{
				using (var _context = scope.ServiceProvider.GetRequiredService<BookContext>())
				{
					try
					{
						if (_context.Categories.Count() == 0)
						{
							Category[] categories = CategoryGenerator.CreateCategories();

							_context.Categories.AddRange(categories);

							_context.SaveChanges();
						}

						if (_context.Authors.Count() == 0)
						{
							Author[] authors = AuthorGenerator.CreateAuthors();

							_context.Authors.AddRange(authors);

							_context.SaveChanges();
						}

						if (_context.Books.Count() == 0)
						{
							Book[] books = BookGenerator.CreateBooks();

							_context.Books.AddRange(books);

							_context.SaveChanges();
						}

					}
					catch (Exception ex)
					{
						//Log errors or do anything you think it's needed
						throw;
					}
				}
			}
			return host;
		}
	}


}
