using SportsRetail.Data.Interfaces;
using SportsRetail.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRetail.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        /*
        public IQueryable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Mens", Description = "Products for men" },
                    new Category { CategoryName = "Womens", Description = "Products for women" },
                    new Category { CategoryName = "Kids", Description = "Products for kids" },
                    new Category { CategoryName = "accessories", Description = "all accessories" }
                };
            }
        }
        */

        public IQueryable<Category> Categories => new List<Category>
        {
            new Category { CategoryName = "Mens", Description = "Products for men" },
            new Category { CategoryName = "Womens", Description = "Products for women" },
            new Category { CategoryName = "Kids", Description = "Products for kids" },
            new Category { CategoryName = "accessories", Description = "all accessories" }

        }.AsQueryable<Category>();

    }
}
