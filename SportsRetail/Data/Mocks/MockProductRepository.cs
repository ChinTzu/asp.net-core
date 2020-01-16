using SportsRetail.Data.Interfaces;
using SportsRetail.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRetail.Data.Mocks
{
    public class MockProductRepository : IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IQueryable<Product> Products => new List<Product> {
            new Product
            {
                Name = "Water bottle",
                Price = 7.95M,
                ShortDescription = "hold water container",
                LongDescription = "LifeStraw Go Water Filter Bottle with 2-Stage Integrated Filter Straw for Travel, Hiking, Camping & Emergency Preparedness." +
                                  "LifeStraw® Go 2-Stage incorporates the award-winning LifeStraw® technology as well as a carbon capsule into a durable water bottle," + 
                                  "and makes it perfect for outdoor adventures or as your daily hydration partner.",
                Category = _categoryRepository.Categories.First(),
                ImageUrl = "https://i.ibb.co/jwSHzmh/a-bottle-l.jpg",
                InStock = true,
                IsPreferredProduct = true,
                ImageThumbnailUrl = "https://i.ibb.co/myGBqnx/a-bottle-s.jpg"
            },

            new Product
            {
                Name = "Kick Scooter",
                Price = 159M,
                ShortDescription = "a human-powered street vehicle with a handlebar, deck, and wheels",
                LongDescription = "Have fun with the No Fear Scooter featuring a lightweight alloy frame and quick release folding mechanism, " +
                                  "making it easy to fold down flat for transport or storage, complete with the colourful components such as foam handlebar grips, " +
                                  "PVC wheels, a rear foot brake and a printed No Fear grip tape which provides a great look that also offers instant brand recognition!",
                Category = _categoryRepository.Categories.First(),
                ImageUrl = "https://i.ibb.co/6tcWP7r/k-scooter-l.jpg",
                InStock = true,
                IsPreferredProduct = true,
                ImageThumbnailUrl = "https://i.ibb.co/rHJyy39/k-scooter-s.jpg"
            },

            new Product
            {
                Name = "Cap",
                Price = 23.9M,
                ShortDescription = "fits snugly on your head",
                LongDescription = "The Mens Under Armour Shadow 4.0 Cap has a lightweight design with mesh ventilation channels " +
                                  "across the body to help increase breathability while reflective detail to the front and back helps " +
                                  "to increase your visbility, completed with the Under Armour branding.",
                Category = _categoryRepository.Categories.First(),
                ImageUrl = "https://i.ibb.co/bgY8qLp/m-cap-l.jpg",
                InStock = true,
                IsPreferredProduct = true,
                ImageThumbnailUrl = "https://i.ibb.co/276bTbK/m-cap-s.jpg"
            },

            new Product
            {  
                Name = "Bra",
                Price = 88.5M,
                ShortDescription = "provides support to women's breasts during physical exercise",
                LongDescription = "The USA Pro Padded Crop Top features a total seamless construction for unrestricted movement, " +
                                  "coupled with the wicking and breathable PRO-dry construction so you can keep cool and comfortable",
                Category = _categoryRepository.Categories.First(),
                ImageUrl = "https://i.ibb.co/4461gMp/w-bra-l.jpg",
                InStock = true,
                IsPreferredProduct = true,
                ImageThumbnailUrl = "https://i.ibb.co/GdVsBpd/w-bra-s.jpg"
            }
        }.AsQueryable<Product>();

        public IQueryable<Product> PreferredProducts { get; }
        public Product GetProductById(int productId)
        {
            throw new NotImplementedException();
        }

    }
}
