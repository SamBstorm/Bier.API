using Bier.Models;
using Bier.Services.Bases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkRepository repository;

        public DrinksController(IDrinkRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/<DrinksController>
        [HttpGet]
        public ActionResult<IEnumerable<Drink>> Get()
        {
            try
            {
                return Ok(repository.Get());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { 
                    Method = "Get",
                    Message= ex.Message 
                });
            }
        }

        // GET api/<DrinksController>/5
        [HttpGet("{id:int}")]
        public ActionResult<Drink> Get(int id)
        {
            try
            {
                Drink result = repository.Get(id);
                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "Get",
                    Message = ex.Message
                });
            }
        }

        // POST api/<DrinksController>
        [HttpPost]
        public ActionResult<Drink> Post([FromBody] Drink drink)
        {
            try
            {
                if (drink is null) return BadRequest();
                Drink result = repository.Insert(drink);
                return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "Post",
                    Message = ex.Message
                });
            }
        }

        // PUT api/<DrinksController>/5
        [HttpPut("{id:int}")]
        public ActionResult<Drink> Put(int id, [FromBody] Drink drink)
        {
            try
            {
                if (drink is null) return BadRequest();
                if (id != drink.Id) return BadRequest();
                Drink result = repository.Update(drink);
                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = "Put",
                    Message = ex.Message
                });
            }
        }

        // DELETE api/<DrinksController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                Drink deletedDrink = repository.Delete(id);
                if (deletedDrink is null) return NotFound();                
                return Ok($"La {deletedDrink.Name} (id : {deletedDrink.Id}) a bien été supprimé.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = nameof(Delete),
                    Message = ex.Message
                });
            }
        }
    }
}
