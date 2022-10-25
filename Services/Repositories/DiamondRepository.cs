using DataBase.Context;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class DiamondRepository:IDiamondRepository
    {

        private readonly DiamondContext Context;
        public DiamondRepository(DiamondContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<Diamond>> GetAllAsync()
        {
            List<Diamond> diamonds = await Context.Diamonds.Include(x => x.Retailer).Include(x=>x.Images)
                   .ToListAsync();
            return (diamonds);
        }
        public async Task<Diamond> GetByIdAsync(int? id)
        {
            Diamond diamond = await Context.Diamonds.Include(e => e.Retailer).Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == id && x.RetailerId==id);
            if (diamond == null)
            {
                return null;
            }
            return diamond;
        }
        public async Task<Diamond> CreateDiamondAsync(Diamond diamond)
        {     
            await Context.AddAsync(diamond);           
            await Context.SaveChangesAsync();
            return diamond;
        }
        public async Task<Diamond> UpdateDiamondAsync(int?id,Diamond diamond)
        {

            Context.Diamonds.Update(diamond);
            Context.Entry(diamond).State = EntityState.Modified;

            await Context.SaveChangesAsync();

            return await GetByIdAsync(diamond.Id);
            //Context.Update(diamond);
            //Context.Update(diamond.Retailer);
            //foreach(var item in diamond.Images)
            //{
            //  Context.Update(item);
            //}
            //await Context.SaveChangesAsync();
            //return diamond;
        }
        public async Task<bool> DeleteDiamondAsync(int? id)
        {
            Diamond diamond = await Context.Diamonds.Include(x => x.Retailer).Include(x=>x.Images)
                .FirstOrDefaultAsync(u => u.Id == id);
            Context.Retailers.Remove(diamond.Retailer);
            foreach (var item in diamond.Images)
            {
                Context.Remove(item);
            }
            Context.Diamonds.Remove(diamond);
            return await Context.SaveChangesAsync() > 0;
        }

    }
}