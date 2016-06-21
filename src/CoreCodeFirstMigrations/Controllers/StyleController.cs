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
    public class StyleController : Controller
    {
        private IStyleRepository _repo;

        public StyleController(IStyleRepository repo)
        {
            _repo = repo;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Style> Get()
        {
            return _repo.Get();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetStyle")]
        public IActionResult Get(int id)
        {
            var style = _repo.Search(b => b.ID == id).FirstOrDefault();
            if(style == null)
            {
                return NotFound();
            }
            return new ObjectResult(style);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Style style)
        {
            if (style == null)
                return BadRequest("Required object is missing...");

            _repo.Insert(style);
            return CreatedAtRoute("GetStyle", new { controller = "Style", id = style.ID }, style);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Style style)
        {
            if (style == null || style.ID != id)
            {
                return BadRequest("Invalid style data...");
            }

            var updStyle = _repo.Search(b => b.ID == id).FirstOrDefault();
            if(updStyle == null)
            {
                return NotFound();
            }
            else
            {
                updStyle.Name = style.Name;
                updStyle.Description = style.Description;

                _repo.Update(style);
                return new NoContentResult();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delStyle = _repo.Search(b => b.ID == id).FirstOrDefault();
            if(delStyle == null)
            {
                return NotFound();
            }

            _repo.Delete(delStyle);
            return new NoContentResult();
        }
    }
}
