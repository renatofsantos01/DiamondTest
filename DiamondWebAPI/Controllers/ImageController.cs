﻿using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Repositories;

namespace DiamondWebAPI.Controllers
{
    public class ImageController : Controller
    {

        private readonly IImageRepository Repository;
        public ImageController(IImageRepository repository)
        {
            Repository = repository;
        }

        //GET api/<DiamondController/GetALL>
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {

            IEnumerable<Image> image = await Repository.GetAllAsync();
            if (!image.Any())
            {
                return Content("Empty List");
            }
            return Ok(image);
        }

        //// GET api/<DiamondController>/id
        //[HttpGet("{id}")]
        //public async Task<ActionResult> GetById(int? id)
        //{

        //    Diamond diamond = await Repository.GetByIdAsync(id);
        //    if (diamond != null)
        //    {
        //        return Ok(diamond);
        //    }
        //    return BadRequest("diamond não encontrado");
        //}


        // POST api/<DiamondController>/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }            
           Image imagecreated = await Repository.CreateImageAsync(image);
            return Ok(imagecreated);
        }

        //// PUT api/<DiamondController>/Diamond
        //[HttpPut("Update")]
        //public async Task<IActionResult> Update(Diamond diamond)
        //{
        //    if (diamond == null)
        //    {
        //        return NotFound();
        //    }
        //    Diamond diamondupdated = await Repository.UpdateDiamondAsync(diamond);
        //    return Ok(diamondupdated);
        //}

        ////DELETE api/Controller/Delete
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest("Diamond Not Found");
        //    }
        //    await Repository.DeleteDiamondAsync(id);
        //    return Ok("Deletado com Sucesso");
        //}
    }
}
