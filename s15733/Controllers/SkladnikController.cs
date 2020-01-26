using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using s15733.Models;

namespace s15733.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkladnikController : ControllerBase
    {
        private s15733Context _context;
        public SkladnikController(s15733Context context)
        {
            _context = context;
        }

        // GET: api/Skladnik
        [HttpGet]
        public IActionResult GetSkladnik()
        {
            return Ok(_context.Skladnik.ToList());
        }

        // GET: api/Skladnik/5
        [HttpGet("{id:int}")]
        public IActionResult GetOneSkladnik(int id)
        {
            var skladnik = _context.Skladnik.FirstOrDefault(e => e.Id == id);
            if (skladnik == null)
            {
                return NotFound();
            }
            return Ok(skladnik);
        }
    }
}
