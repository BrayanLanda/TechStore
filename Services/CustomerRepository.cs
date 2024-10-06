using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechStore.Data;
using TechStore.DTOs.CustomerDtos;
using TechStore.Errors;
using TechStore.Errors.GenericErrors;
using TechStore.Interfaces;
using TechStore.Models;

namespace TechStore.Services
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            var customer = await _context.Set<Customer>()
                .FirstOrDefaultAsync(c => c.Email == email);

            if (customer == null)
            {
                throw new UserNotFoundException("customer", email);
            }

            return customer;
        }

        public async Task AddAsync(Customer entity)
        {
            // Verificar si ya existe un cliente con el mismo correo
            var existingCustomer = await GetCustomerByEmailAsync(entity.Email);
            if (existingCustomer != null)
            {
                throw new UserAlreadyExistsException("Customer", entity.Email);
            }

            await _context.Set<Customer>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
    }
}