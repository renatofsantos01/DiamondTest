using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDiamondRepository
    {
        Task<Diamond> CreateDiamondAsync(Diamond diamond);
        Task<bool> DeleteDiamondAsync(int? id);
        Task<IEnumerable<Diamond>> GetAllAsync();
        Task<Diamond> GetByIdAsync(int? id);
        Task<Diamond> UpdateDiamondAsync(Diamond diamond);
    }
}