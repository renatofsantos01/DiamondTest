using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRetailerRepository
    {
        Task<Retailer> CreateRetailerAsync(Retailer retailer);
        Task<bool> DeleteRetailerAsync(int? id);
        Task<IEnumerable<Retailer>> GetAllAsync();
        Task<Retailer> GetByIdAsync(int? id);
        Task<Retailer> UpdateRetailerAsync(Retailer Image);
    }
}