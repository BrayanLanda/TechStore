using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Models;

namespace TechStore.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryByNameAsync(string name);
    }
}