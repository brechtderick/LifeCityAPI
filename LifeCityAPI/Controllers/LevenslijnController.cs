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
    public class LevenslijnController : Controller
    {
        private readonly ILevenslijnRepository _levenslijnRepository;
        private readonly ICustomerRepository _customerRepository;

        public LevenslijnController(ILevenslijnRepository context, ICustomerRepository customerRepository)
        {
            _levenslijnRepository = context;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<LevenslijnItem> GetLevenslijnItems()
        {
            return _levenslijnRepository.GetAll().OrderBy(l => l.Naam);
        }

        [HttpGet("id/{id}")]
        public ActionResult<LevenslijnItem> GetLevenslijnItem(int id)
        {
            LevenslijnItem levenslijnItem = _levenslijnRepository.GetBy(id);
            if (levenslijnItem == null) return NotFound();
            return levenslijnItem;
        }

        [HttpGet("{user}")]
        public IEnumerable<LevenslijnItem> GetLevenslijnItemUser(string user)
        {
            IEnumerable<LevenslijnItem> levenslijnItem = _levenslijnRepository.GetByUser(user);
            if (levenslijnItem == null) return (IEnumerable<LevenslijnItem>)NotFound();
            return levenslijnItem;
        }

        [HttpPost]
        public ActionResult<LevenslijnItem> PostLevenslijnItem(LevenslijnItem levenslijnItem)
        {
            _levenslijnRepository.Add(levenslijnItem);
            _levenslijnRepository.SaveChanges();
            return CreatedAtAction(nameof(GetLevenslijnItem),
                new { id = levenslijnItem.Id }, levenslijnItem);
        }

        [HttpPut("{id}")]
        public IActionResult PutLevenslijnItem(int id, LevenslijnItem levenslijnItem)
        {
            if (id != levenslijnItem.Id)
            {
                return BadRequest();
            }
            if (levenslijnItem == null) return NotFound();
            _levenslijnRepository.Update(levenslijnItem);
            _levenslijnRepository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLevenslijnItem(int id)
        {
            LevenslijnItem levenslijnItem = _levenslijnRepository.GetBy(id);
            if (levenslijnItem == null)
            {
                return NotFound();
            }
            _levenslijnRepository.Delete(levenslijnItem);
            _levenslijnRepository.SaveChanges();
            return NoContent();
        }

    }
}
