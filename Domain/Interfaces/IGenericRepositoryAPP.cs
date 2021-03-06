using Domain.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGenericRepositoryAPP<T>
    {
        Task<ApiResponse> GetByIdAsync(int id);
        Task<ApiResponse> GetAllAsync(int? studentId = null);
        Task<ApiResponse> Add(T entity, int? studentId = null);
        Task<ApiResponse> Update(int id,T dto);
        Task<ApiResponse> Delete(int id);
    }
}
