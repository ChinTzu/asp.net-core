using SportsRetail.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsRetail.Data.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get; }
    }
}
