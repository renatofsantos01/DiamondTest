using DataBase.Context;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class RetailerRepository : IRetailerRepository
    {

        private readonly DiamondContext Context;
        public RetailerRepository(DiamondContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Retailer>> GetAllAsync()
        {
            List<Retailer> Retailers = await Context.Retailers
                   .ToListAsync();
            return (Retailers);
        }
        public async Task<Retailer> GetByIdAsync(int? id)
        {
            Retailer Retailer = await Context.Retailers.FirstOrDefaultAsync(x => x.Id == id);
            if (Retailer == null)
            {
                return null;
            }
            return Retailer;
        }
        public async Task<Retailer> CreateRetailerAsync(Retailer Retailer)
        {
            await Context.AddAsync(Retailer);
            await Context.SaveChangesAsync();
            return Retailer;
        }
        public async Task<Retailer> UpdateRetailerAsync(Retailer Retailer)
        {
            Context.Update(Retailer);
            await Context.SaveChangesAsync();
            return Retailer;
        }
        public async Task<bool> DeleteRetailerAsync(int? id)
        {
            Retailer Retailer = await Context.Retailers
                .FirstOrDefaultAsync(u => u.Id == id);
            Context.Retailers.Remove(Retailer);
            return await Context.SaveChangesAsync() > 0;
        }
    }
}