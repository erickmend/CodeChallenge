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
    public class PhoneRepository : IGenericRepository<Phone>
    {
        private readonly DBContext _context;

        public PhoneRepository(DBContext context)
        {
            _context = context;
        }
        public Task<int> Add(Phone entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Phone>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Phone> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Phone entity)
        {
            throw new NotImplementedException();
        }
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
