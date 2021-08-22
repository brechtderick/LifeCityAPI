using LifeCityAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LifeCityAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class HulpbronController : Controller
    {
        private readonly IHulpbronRepository _hulpbronRepository;
        private readonly ICustomerRepository _customerRepository;

        public HulpbronController(IHulpbronRepository context, ICustomerRepository customerRepository)
        {
            _hulpbronRepository = context;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Hulpbron> GetHulbronnen()
        {
            return _hulpbronRepository.GetAll().OrderBy(h => h.Naam);
        }

        [HttpGet("id/{id}")]
        public ActionResult<Hulpbron> GetHulpbron(int id)
        {
            Hulpbron hulpbron = _hulpbronRepository.GetBy(id);
            if (hulpbron == null) return NotFound();
            return hulpbron;

        }

        [HttpGet("{user}")]
        public IEnumerable<Hulpbron> GetHulpbronUser(string user)
        {
            IEnumerable<Hulpbron> hulpbron = _hulpbronRepository.GetByUser(user);
            if (hulpbron == null) return (IEnumerable<Hulpbron>)NotFound();
            return hulpbron;

        }

        [HttpPost]
        public ActionResult<Talenten> PostHulpbron(Hulpbron hulpbron)
        {
            _hulpbronRepository.Add(hulpbron);
            _hulpbronRepository.SaveChanges();
            return CreatedAtAction(nameof(GetHulpbron),
                new { id = hulpbron.Id }, hulpbron);
        }

        [HttpPut("{id}")]
        public IActionResult PutHulpbron(int id, Hulpbron hulpbron)
        {
            if (id != hulpbron.Id)
            {
                return BadRequest();
            }
            if (hulpbron == null) return NotFound();
            _hulpbronRepository.Update(hulpbron);
            _hulpbronRepository.SaveChanges();
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteHulpbron(int id)
        {
            Hulpbron hulpbron = _hulpbronRepository.GetBy(id);
            if (hulpbron == null)
            {
                return NotFound();
            }
            _hulpbronRepository.Delete(hulpbron);
            _hulpbronRepository.SaveChanges();
            return NoContent();
        }
    }
}
