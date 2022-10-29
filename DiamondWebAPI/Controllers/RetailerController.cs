using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiamondWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RetailerController : Controller
    {

        private readonly IRetailerRepository Repository;
        public RetailerController(IRetailerRepository repository)
        {
            Repository = repository;
        }

        //GET api/<RetailerController/GetAllRetailers
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            IEnumerable<Retailer> Retailer = await Repository.GetAllAsync();
            if (!Retailer.Any())
            {
                return Content("Empty List");
            }
            return Ok(Retailer);
        }

        //// GET api/<RetailerController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int? id)
        {
            Retailer Retailer = await Repository.GetByIdAsync(id);
            if (Retailer != null)
            {
                return Ok(Retailer);
            }
            return BadRequest("Retailer not found");
        }

        // POST api/<RetailerController>/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody]Retailer Retailer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Retailer Retailercreated = await Repository.CreateRetailerAsync(Retailer);
            return Ok(Retailercreated);
        }

        //// PUT api/<RetailerController>/UpdateRetailer
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Retailer Retailer)
        {
            if (Retailer == null)
            {
                return NotFound();
            }
            Retailer Retailerupdated = await Repository.UpdateRetailerAsync(Retailer);
            return Ok(Retailerupdated);
        }

        ////DELETE api/RetailerController/Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Diamond Not Found");
            }
            await Repository.DeleteRetailerAsync(id);
            return Ok("Deletado com Sucesso");
        }
    }
}