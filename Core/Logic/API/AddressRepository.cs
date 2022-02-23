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
    public class AddressRepository : IGenericRepository<Address>
    {
        private readonly DBContext _context;

        public AddressRepository(DBContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Address entity)
        {
            _context.Addresses.Add(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(Address entity)
        {
            _context.Addresses.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Address>> GetAllAsync(int? studentId = null)
        {
            return await _context.Addresses
                .Where(x=> x.StudentId.Equals(studentId))
               .ToListAsync();
        }

        public async Task<Address> GetByIdAsync(int id)
        {
            return await _context.Addresses
                 .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _context.Addresses.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity == null)
                return 0;

            _context.Addresses.Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
