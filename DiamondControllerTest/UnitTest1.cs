using DataBase.Context;
using Domain.Interfaces;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Services.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiamondControllerTest
{
    public class Tests
    {
        private IDiamondRepository Repository;
        private DiamondContext Context;


        [SetUp]
        public void Setup()
        {
            DbContextOptions<DiamondContext> ContextOptions = new DbContextOptionsBuilder<DiamondContext>().UseInMemoryDatabase("DiamondDb").Options;
            Context = new DiamondContext(ContextOptions);
            Repository = new DiamondRepository(Context);

        }

        [Test]
        public async Task Get_GetAllDiamonds_Success()
        {
            IEnumerable<Diamond> diamonds = await Repository.GetAllAsync();
            Assert.IsNotNull(diamonds);
            Assert.IsNull(diamonds);
        }


        //[Test]
        //public async Task Get_GetDiamondById_Success(int id)
        //{
        //    #region arrange
        //    var diamond = await Repository.GetByIdAsync(id);

        //    #endregion
        //    #region act


        //    #endregion
        //    #region assert
        //    Assert.AreEqual(id, diamond.Id);
        //    #endregion
        //}
    }
}
