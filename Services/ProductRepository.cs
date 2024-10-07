using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Errors;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Services
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task AddAsync(Product entity)
        {
            // Verificar si la categoría existe
            var category = await _context.Categories.FindAsync(entity.CategoryId);
            if (category == null)
            {
                throw new IdNotFoundException("Category", entity.CategoryId);
            }

            await _context.Set<Product>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}