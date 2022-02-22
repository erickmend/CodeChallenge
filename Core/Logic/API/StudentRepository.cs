using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logic
{
    public class StudentRepository : IGenericRepository<Student>
    {
        private readonly DBContext _context;

        public StudentRepository(DBContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Student entity)
        {
            _context.Students.Add(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(Student entity)
        {
            _context.Students.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Student>> GetAllAsync()
        {
            return await _context.Students
                .Include(x=> x.Addresses)
                .Include(x=> x.Emails)
                .Include(x=> x.Phones)
                .ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _context.Students
                .Include(x => x.Addresses)
                .Include(x => x.Emails)
                .Include(x => x.Phones)
                .FirstOrDefaultAsync(x=> x.Id.Equals(id));
        }


        public async Task<int> Delete(int id)
        {

            var entity = await _context.Students.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity == null)
                return 0;

            _context.Students.Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
