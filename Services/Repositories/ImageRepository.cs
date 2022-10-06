using DataBase.Context;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class ImageRepository : IImageRepository
    {

        private readonly DiamondContext Context;
        public ImageRepository(DiamondContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            List<Image> images = await Context.Images
                   .ToListAsync();
            return (images);
        }
        public async Task<Image> GetByIdAsync(int? id)
        {
            Image image = await Context.Images.FirstOrDefaultAsync(x => x.Id == id);
            if (image == null)
            {
                return null;
            }
            return image;
        }
        public async Task<Image> CreateImageAsync(Image image)
        {
            await Context.AddAsync(image);
            await Context.SaveChangesAsync();
            return image;
        }
        public async Task<Image> UpdateImageAsync(Image Image)
        {
            Context.Update(Image);
            await Context.SaveChangesAsync();
            return Image;
        }
        public async Task<bool> DeleteImageAsync(int? id)
        {
            Image Image = await Context.Images
                .FirstOrDefaultAsync(u => u.Id == id);
            Context.Images.Remove(Image);
            return await Context.SaveChangesAsync() > 0;
        }
    }
}