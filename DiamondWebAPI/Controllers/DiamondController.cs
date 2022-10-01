using Domain.Interfaces;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        //GET api/<DiamondController/GetALL>
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            IEnumerable<Diamond> diamonds = await Repository.GetAllDiamondAsync();
            return Ok(diamonds);
        }

        // GET api/<DiamondController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            Diamond diamond = await Repository.GetByIdAsync(id);
            if (diamond == null)
            {
                return BadRequest("livro não encontrado");
            }
            return Ok(diamond);
        }

        // POST api/<DiamondController>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Diamond diamond)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            Diamond diamondcreated = await Repository.CreateLivroAsync(diamond);
            return Ok(diamondcreated);
        }

        // PUT api/<DiamondController>/Diamond
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Diamond diamond)
        {
            Diamond diamondatualizado = await Repository.UpdateDiamondAsync(diamond);
            if (diamondatualizado == null)
            {
                return NotFound();
            }
            return Ok(diamond);
        }

        //DELETE api/Controller/delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Repository.DeleteDiamondAsync(id);
            return Ok("Deletado com Sucesso");
        }
    }
}
