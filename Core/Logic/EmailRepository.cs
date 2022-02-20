using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
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
        public Task<int> Add(Email entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Email>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Email> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Email entity)
        {
            throw new NotImplementedException();
        }
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
