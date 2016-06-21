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
    public class BeerController : Controller
    {
        private IBeerRepository _repo;

        public BeerController(IBeerRepository repo)
        {
            _repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Beer> Get()
        {
            return _repo.Get();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetBeer")]
        public IActionResult Get(int id)
        {
            var beer = _repo.Search(b => b.ID == id).FirstOrDefault();
            if(beer == null)
            {
                return NotFound();
            }
            return new ObjectResult(beer);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Beer beer)
        {
            if (beer == null)
                return BadRequest("Required object is missing...");

            _repo.Insert(beer);
            return CreatedAtRoute("GetBeer", new { controller = "Beer", id = beer.ID }, beer);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Beer beer)
        {
            if (beer == null || beer.ID != id)
            {
                return BadRequest("Invalid beer data...");
            }

            var updBeer = _repo.Search(b => b.ID == id).FirstOrDefault();
            if(updBeer == null)
            {
                return NotFound();
            }
            else
            {
                updBeer.Name = beer.Name;
                updBeer.BreweryId = beer.BreweryId;
                updBeer.StyleId = beer.StyleId;

                _repo.Update(updBeer);
                return new NoContentResult();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delBeer = _repo.Search(b => b.ID == id).FirstOrDefault();
            if(delBeer == null)
            {
                return NotFound();
            }

            _repo.Delete(delBeer);
            return new NoContentResult();
        }
    }
}
