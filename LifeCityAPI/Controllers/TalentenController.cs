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
    public class TalentenController : ControllerBase
    {
        private readonly ITalentenRepository _talentenRepository;
        private readonly ICustomerRepository _customerRepository;

        public TalentenController(ITalentenRepository context, ICustomerRepository customerRepository)
        {
            _talentenRepository = context;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Talenten> GetTalenten()
        {
            return _talentenRepository.GetAll().OrderBy(t => t.User);
        }

        [HttpGet("id/{id}")]
        public ActionResult<Talenten> GetTalent(int id)
        {
            Talenten talenten = _talentenRepository.GetBy(id);
            if (talenten == null) return NotFound();
            return talenten;

        }

        [HttpGet("{user}")]
        public IEnumerable<Talenten> GetTalentenUser(string user)
        {
            IEnumerable<Talenten> talenten = _talentenRepository.GetByUser(user);
            if (talenten == null) return (IEnumerable<Talenten>)NotFound();
            return talenten;

        }

        [HttpPost]
        public ActionResult<Talenten> PostTalent(Talenten talenten)
        {
            _talentenRepository.Add(talenten);
            _talentenRepository.SaveChanges();
            return CreatedAtAction(nameof(GetTalent),
                new { id = talenten.Id }, talenten);
        }

        [HttpPut("{id}")]
        public IActionResult PutTalent(int id, Talenten talenten)
        {
            if (id != talenten.Id)
            {
                return BadRequest();
            }
            if (talenten == null) return NotFound();
            _talentenRepository.Update(talenten);
            _talentenRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTalent(int id)
        {
            Talenten talenten = _talentenRepository.GetBy(id);
            if (talenten == null)
            {
                return NotFound();
            }
            _talentenRepository.Delete(talenten);
            _talentenRepository.SaveChanges();
            return NoContent();
        }
    }
}
