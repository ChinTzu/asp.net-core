using SportsRetail.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRetail.Data.Interfaces
{
    public interface IProductRepository
    {
        //get all products. Will shown on front page
        IQueryable<Product> Products { get; }

        //get Preferred products. Will shown on front page
        IQueryable<Product> PreferredProducts { get; }

        Product GetProductById(int productId);
    }
}
