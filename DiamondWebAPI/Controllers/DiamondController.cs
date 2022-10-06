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
    public class DiamondController : ControllerBase
    {
        private readonly IDiamondRepository Repository;

        public DiamondController(IDiamondRepository repository)
        {
            Repository = repository;
        }

        //GET api/<DiamondController/GetAllDiamonds
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            IEnumerable<Diamond> diamonds = await Repository.GetAllAsync();
            if (!diamonds.Any())
            {
                return Content("Empty List");
            }
            return Ok(diamonds);
        }

        // GET api/<DiamondController>/id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int? id)
        {
            Diamond diamond = await Repository.GetByIdAsync(id);
            if (diamond != null)
            {
                return Ok(diamond);
            }
            return BadRequest("diamond not found");
        }

        // POST api/<DiamondController>/Create
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Diamond diamond)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Diamond diamondcreated = await Repository.CreateDiamondAsync(diamond);
            return Ok(diamondcreated);
        }

        // PUT api/<DiamondController>/UpdateDiamond
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Diamond diamond)
        {
            if (diamond == null)
            {
                return NotFound();
            }
            Diamond diamondupdated = await Repository.UpdateDiamondAsync(diamond);
            return Ok(diamondupdated);
        }

        //DELETE api/Controller/DeleteDiamond
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Diamond Not Found");
            }
            await Repository.DeleteDiamondAsync(id);
            return Ok("Deleted");
        }
    }
}