using AutoMapper;
using CRMSystem.WebAPI.Core;
using CRMSystem.WebAPI.Entities.School;
using CRMSystem.WebAPI.Interfaces;
using CRMSystem.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRMSystem.WebAPI.Repositories
{
    public class StudentRepository(SchoolDbContext context, IMapper mapper)
        : IBasicRepository<Student>
    {
        public async Task<Student?> GetByIdAsync(Guid id)
        {
            var entity = await context.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
            
            return mapper.Map<Student>(entity);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var entities = await context.Students
                .AsNoTracking()
                .ToListAsync();
            
            return mapper.Map<IEnumerable<Student>>(entities);
        }

        public async Task<Student> AddAsync(Student student)
        {
            var entity = mapper.Map<StudentEntity>(student);
            await context.Students.AddAsync(entity);
            
            await context.SaveChangesAsync();
            return mapper.Map<Student>(entity);
        }

        public async Task<Student?> UpdateAsync(Guid id, Student student)
        {
            var existing = await context.Students
                .FirstOrDefaultAsync(s => s.Id == id);
            
            if (existing == null) return null;

            context.Entry(existing)
                .CurrentValues.SetValues(mapper.Map<StudentEntity>(student));
            
            await context.SaveChangesAsync();
            return mapper.Map<Student>(existing);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.Students
                .FirstOrDefaultAsync(s => s.Id == id);
            
            if (entity != null)
            {
                context.Students.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}