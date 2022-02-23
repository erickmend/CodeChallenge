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
    public class PhoneRepository : IGenericRepository<Phone>
    {
        private readonly DBContext _context;

        public PhoneRepository(DBContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Phone entity)
        {
            if (_context.Phones.Any(x => x.phone == entity.phone))
                return 501;

            _context.Phones.Add(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(Phone entity)
        {
            _context.Phones.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Phone>> GetAllAsync(int? studentId = null)
        {
            return await _context.Phones
                .Where(x=> x.StudentId.Equals(studentId))
               .ToListAsync();
        }

        public async Task<Phone> GetByIdAsync(int id)
        {
            return await _context.Phones
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }


        public async Task<int> Delete(int id)
        {
            var entity = await _context.Phones.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity == null)
                return 0;

            _context.Phones.Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
