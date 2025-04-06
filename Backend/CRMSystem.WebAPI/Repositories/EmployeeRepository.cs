using AutoMapper;
using CRMSystem.WebAPI.Core;
using CRMSystem.WebAPI.Entities.School;
using CRMSystem.WebAPI.Interfaces;
using CRMSystem.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.WebAPI.Repositories
{
    public class EmployeeRepository(SchoolDbContext context, IMapper mapper)
        : IBasicRepository<Employee>
    {
        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            var entity = await context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
            
            return mapper.Map<Employee>(entity);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var entities = await context.Employees
                .AsNoTracking()
                .ToListAsync();
            
            return mapper.Map<IEnumerable<Employee>>(entities);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            var entity = mapper.Map<EmployeeEntity>(employee);
            await context.Employees.AddAsync(entity);
            
            await context.SaveChangesAsync();
            return mapper.Map<Employee>(entity);
        }

        public async Task<Employee?> UpdateAsync(Guid id, Employee employee)
        {
            var existing = await context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            
            if (existing == null)
                return null;

            context.Entry(existing)
                .CurrentValues.SetValues(mapper.Map<EmployeeEntity>(employee));
            
            await context.SaveChangesAsync();
            return mapper.Map<Employee>(existing);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.Employees
                .FirstOrDefaultAsync(e => e.Id == id);
            
            if (entity != null)
            {
                context.Employees.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}