using LifeCityAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeCityAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class DoelController : Controller
    {
        private readonly IDoelRepository _doelRepository;
        private readonly ICustomerRepository _customerRepository;

        public DoelController(IDoelRepository context, ICustomerRepository customerRepository)
        {
            _doelRepository = context;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Doel> GetDoel()
        {
            return _doelRepository.GetAll().OrderBy(l => l.Naam);
        }

        [HttpGet("id/{id}")]
        public ActionResult<Doel> GetDoel(int id)
        {
            Doel doel = _doelRepository.GetBy(id);
            if (doel == null) return NotFound();
            return doel;
        }

        [HttpGet("{user}")]
        public IEnumerable<Doel> GetDoelUser(string user)
        {
            IEnumerable<Doel> doel = _doelRepository.GetByUser(user);
            if (doel == null) return (IEnumerable<Doel>)NotFound();
            return doel;
        }

        [HttpPost]
        public ActionResult<Doel> PostDoel(Doel doel)
        {
            _doelRepository.Add(doel);
            _doelRepository.SaveChanges();
            return CreatedAtAction(nameof(GetDoel),
                new { id = doel.Id }, doel);
        }

        [HttpPut("{id}")]
        public IActionResult PutDoel(int id, Doel doel)
        {
            if (id != doel.Id)
            {
                return BadRequest();
            }
            if (doel == null) return NotFound();
            _doelRepository.Update(doel);
            _doelRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoel(int id)
        {
            Doel doel = _doelRepository.GetBy(id);
            if (doel == null)
            {
                return NotFound();
            }
            _doelRepository.Delete(doel);
            _doelRepository.SaveChanges();
            return NoContent();
        }
    }
}
