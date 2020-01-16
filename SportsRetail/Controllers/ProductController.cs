using Microsoft.AspNetCore.Mvc;
using SportsRetail.Data.Interfaces;
using SportsRetail.Data.Models;
using SportsRetail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRetail.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public int PageSize = 8;
        
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category, int productPage = 1)
        {
            ProductsListViewModel productListViewModel = new ProductsListViewModel();
            productListViewModel.Products = _productRepository.Products
                                            .Where(p => category == null || p.Category.CategoryName == category)
                                            .OrderBy(p => p.ProductId)
                                            .Skip((productPage - 1) * PageSize)
                                            .Take(PageSize);

            productListViewModel.PagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = category == null ? _productRepository.Products.Count() : _productRepository.Products
                .Where(e => e.Category.CategoryName == category).Count()
            };

            productListViewModel.CurrentCategory = category;

            return View(productListViewModel);
        }

        public ViewResult Details(int productId)
        {
            var product = _productRepository.Products.FirstOrDefault(d => d.ProductId == productId);
            if (product == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(product);
        }

        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IQueryable<Product> products;
            string currentCategory = string.Empty;
            
            if (string.IsNullOrEmpty(_searchString))
            {
                products = _productRepository.Products.OrderBy(p => p.ProductId);
            }
            else
            {
                products = _productRepository.Products.Where(p => p.Name.ToLower().Contains(_searchString.ToLower()));
            }

            return View("~/Views/Product/List.cshtml",
                new ProductsListViewModel
                {
                    Products = products,
                    CurrentCategory = null,

                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = 1,
                        ItemsPerPage = 50, 
                        TotalItems  = _productRepository.Products.Count()
                    }

                });
        }
    }
}
