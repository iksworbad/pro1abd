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
    public class KlientController : ControllerBase
    {
        private s15733Context _context;
        public KlientController(s15733Context context)
        {
            _context = context;
        }

        // GET: api/Klient
        [HttpGet]
        public IActionResult GetKlient()
        {
            return Ok(_context.Klient.ToList());
        }

        // GET: api/Klient/5
        [HttpGet("{id:int}")]
        public IActionResult GetOneKlient(int id)
        {
            var klient = _context.Klient.FirstOrDefault(e => e.Id == id);
            if (klient == null)
            {
                return NotFound();
            }
            return Ok(klient);
        }
    }
}
