using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDiamondRepository
    {
        Task<Diamond> CreateLivroAsync(Diamond diamond);
        Task<bool> DeleteDiamondAsync(int id);
        Task<IEnumerable<Diamond>> GetAllDiamondAsync();
        Task<Diamond> GetByIdAsync(int id);
        Task<Diamond> UpdateDiamondAsync(Diamond diamond);
    }
}
