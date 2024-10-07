using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.Errors;
using TechStore.Errors.GenericErrors;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Services
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            var category = await _context.Set<Category>()
                .FirstOrDefaultAsync(c => c.Name == name);

            if (category == null)
            {
                throw new UserNotFoundException("category", name);
            }

            return category;
        }

        public async Task AddAsync(Category entity)
        {
            // Verificar si ya existe una categoría con el mismo nombre
            var existingCategory = await _context.Set<Category>()
                .FirstOrDefaultAsync(c => c.Name == entity.Name);
            if (existingCategory != null)
            {
                throw new UserAlreadyExistsException("Category", entity.Name);
            }

            await _context.Set<Category>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new IdNotFoundException("category", id);
            }

            _context.Set<Category>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}