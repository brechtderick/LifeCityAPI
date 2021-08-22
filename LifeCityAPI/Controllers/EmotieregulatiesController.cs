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
    public class EmotieregulatiesController : ControllerBase
    {
        private readonly IEmotieregulatieRepository _emotieregulatieRepository;
        private readonly ICustomerRepository _customerRepository;

        public EmotieregulatiesController(IEmotieregulatieRepository context, ICustomerRepository customerRepository)
        {
            _emotieregulatieRepository = context;
            _customerRepository = customerRepository;
        }

        //GET: api/Emoties
        [HttpGet]
        public IEnumerable<Emotieregulatie> GetEmotieregulaties()
        {
            return _emotieregulatieRepository.GetAll().OrderBy(e => e.DateAdded);
        }

        [HttpGet("{id}")]
        public ActionResult<Emotieregulatie> GetEmotieregulatie(int id)
        {
            Emotieregulatie emotieregulatie = _emotieregulatieRepository.GetBy(id);
            if (emotieregulatie == null) return NotFound();
            return emotieregulatie;

        }

        [HttpPost] 
        public ActionResult<Emotieregulatie> PostEmotieregulatie(Emotieregulatie emotieregulatie) 
        {
            _emotieregulatieRepository.Add(emotieregulatie);
            _emotieregulatieRepository.SaveChanges(); 
            return CreatedAtAction(nameof(GetEmotieregulatie), 
                new { id = emotieregulatie.Id }, emotieregulatie); 
        }

        [HttpPut("{id}")] 
        public IActionResult PutEmotieregulatie(int id, Emotieregulatie emotieregulatie) 
        { 
            if (id != emotieregulatie.Id) 
            { 
                return BadRequest(); 
            }
            if (emotieregulatie == null) return NotFound();
            _emotieregulatieRepository.Update(emotieregulatie);
            _emotieregulatieRepository.SaveChanges(); 
            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmotieregulatie(int id) 
        {
            Emotieregulatie emotieregulatie = _emotieregulatieRepository.GetBy(id); 
            if (emotieregulatie == null) 
            { 
                return NotFound(); 
            }
            _emotieregulatieRepository.Delete(emotieregulatie);
            _emotieregulatieRepository.SaveChanges(); 
            return NoContent(); 
        }

    }
}
