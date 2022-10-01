using Domain.Data;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class DiamondRepository:IDiamondRepository
    {

        private readonly DiamondContext Context;
        public DiamondRepository(DiamondContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Diamond>> GetAllDiamondAsync()
        {
            List<Diamond> diamonds = await Context.Diamonds.Include(x => x.Retailer).Include(x=>x.Images)
                   .ToListAsync();
            return (diamonds);
        }
        public async Task<Diamond> GetByIdAsync(int id)
        {
            Diamond livro = await Context.Diamonds.Include(e => e.Retailer).Include(x => x.Images).FirstOrDefaultAsync(x => x.Id == id && x.RetailerId==id);
            if (livro == null)
            {
                return null;
            }
            return livro;
        }

        public async Task<Diamond> CreateLivroAsync(Diamond diamond)
        {
            await Context.AddAsync(diamond);
            await Context.SaveChangesAsync();
            return diamond;
        }

        public async Task<Diamond> UpdateDiamondAsync(Diamond diamond)
        {
            Context.Update(diamond);
            Context.Update(diamond.Retailer);
            foreach(var item in diamond.Images)
            {
              Context.Update(item);
            }
            await Context.SaveChangesAsync();
            return diamond;
        }

        public async Task<bool> DeleteDiamondAsync(int id)
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
