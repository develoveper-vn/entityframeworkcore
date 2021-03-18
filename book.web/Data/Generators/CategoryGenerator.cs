﻿using book.web.Models;

namespace book.web.Data.Generators
{
	public class CategoryGenerator
	{
        public static Category[] CreateCategories()
        {
            string[] categoryNames = new string[]
            {
                "Science Fiction",
                "Drama",
                "Action",
                "Adventure",
                "Romance",
                "Mystery",
                "Horror",
                "Health",
                "Travel",
                "Children's",
                "Science",
                "History",
                "Poetry",
                "Comics",
                "Art",
                "Cookbooks",
                "Journals",
                "Biographies",
                "Fantasy",
            };

            int categoryCount = categoryNames.Length;

            Category[] categories = new Category[categoryCount];

            for (int i = 0; i < categoryCount; i++)
            {
                Category category = new Category()
                {
                    Name = categoryNames[i],
                };

                categories[i] = category;
            }

            return categories;
        }
    }
}
