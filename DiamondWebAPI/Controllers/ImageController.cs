using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondWebAPI.Controllers
{
    public class ImageController : Controller
    {

        private readonly IImageRepository Repository;
        public ImageController(IImageRepository repository)
        {
            Repository = repository;
        }

        //GET api/<ImageController/GetAllImages
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

        //// GET api/<ImageController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int? id)
        {
            Image image = await Repository.GetByIdAsync(id);
            if (image != null)
            {
                return Ok(image);
            }
            return BadRequest("image not found");
        }

        // POST api/<ImageController>/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Image imagecreated = await Repository.CreateImageAsync(image);
            return Ok(imagecreated);
        }

        //// PUT api/<ImageController>/UpdateImage
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Image image)
        {
            if (image == null)
            {
                return NotFound();
            }
            Image imageupdated = await Repository.UpdateImageAsync(image);
            return Ok(imageupdated);
        }

        ////DELETE api/ImageController/Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Diamond Not Found");
            }
            await Repository.DeleteImageAsync(id);
            return Ok("Deletado com Sucesso");
        }
    }
}