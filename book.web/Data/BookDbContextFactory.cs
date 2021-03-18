using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace book.web.Data
{
	public class BookDbContextFactory: IDesignTimeDbContextFactory<BookContext>
	{
		BookContext IDesignTimeDbContextFactory<BookContext>.CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var connectionString = configuration.GetConnectionString("BookContext");

			var optionsBuilder = new DbContextOptionsBuilder<BookContext>();
			optionsBuilder.UseSqlServer(connectionString);

			return new BookContext(optionsBuilder.Options);
		}
		
		
	}
}
