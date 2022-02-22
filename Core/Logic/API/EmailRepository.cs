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
    public class EmailRepository : IGenericRepository<Email>
    {
        private readonly DBContext _context;

        public EmailRepository(DBContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Email entity)
        {
            _context.Emails.Add(entity);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> Update(Email entity)
        {
            _context.Emails.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<Email>> GetAllAsync()
        {
            return await _context.Emails
               .ToListAsync();
        }

        public async Task<Email> GetByIdAsync(int id)
        {
            return await _context.Emails
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }


        public async Task<int> Delete(int id)
        {
            var entity = await _context.Emails.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (entity == null)
                return 0;

            _context.Emails.Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
