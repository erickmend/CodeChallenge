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
    public class AddressRepository : IGenericRepository<Address>
    {
        private readonly DBContext _context;

        public AddressRepository(DBContext context)
        {
            _context = context;
        }
        public Task<int> Add(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Address>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Address entity)
        {
            throw new NotImplementedException();
        }
        public Task<int> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
