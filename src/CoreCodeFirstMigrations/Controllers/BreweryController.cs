using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoreCodeFirstMigrations.Models;
using CoreCodeFirstMigrations.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreCodeFirstMigrations.Controllers
{
    [Route("api/[controller]")]
    public class BreweryController : Controller
    {
        private IBreweryRepository _repo;

        public BreweryController(IBreweryRepository repo)
        {
            _repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Brewery> Get()
        {
            return _repo.Get();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetBrewery")]
        public IActionResult Get(int id)
        {
            var brewery = _repo.Search(b => b.ID == id).FirstOrDefault();
            if(brewery == null)
            {
                return NotFound();
            }
            return new ObjectResult(brewery);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Brewery brewery)
        {
            if (brewery == null)
                return BadRequest("Required object is missing...");

            _repo.Insert(brewery);
            return CreatedAtRoute("GetBrewery", new { controller = "Brewery", id = brewery.ID }, brewery);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Brewery brewery)
        {
            if (brewery == null || brewery.ID != id)
            {
                return BadRequest("Invalid Brewery data...");
            }

            var updBrewery = _repo.Search(b => b.ID == id).FirstOrDefault();
            if(updBrewery == null)
            {
                return NotFound();
            }
            else
            {
                updBrewery.Name = brewery.Name;
                updBrewery.Description = brewery.Description;

                _repo.Update(updBrewery);
                return new NoContentResult();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delBrewery = _repo.Search(b => b.ID == id).FirstOrDefault();
            if(delBrewery == null)
            {
                return NotFound();
            }

            _repo.Delete(delBrewery);
            return new NoContentResult();
        }
    }
}
