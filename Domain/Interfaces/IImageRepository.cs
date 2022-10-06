using Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> CreateImageAsync(Image Image);
        Task<bool> DeleteImageAsync(int? id);
        Task<IEnumerable<Image>> GetAllAsync();
        Task<Image> GetByIdAsync(int? id);
        Task<Image> UpdateImageAsync(Image Image);
    }
}