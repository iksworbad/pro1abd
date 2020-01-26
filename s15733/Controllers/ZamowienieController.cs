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
    public class ZamowienieController : ControllerBase
    {
        private s15733Context _context;
        public ZamowienieController(s15733Context context)
        {
            _context = context;
        }

        // GET: api/Zamowienie
        [HttpGet]
        public IActionResult GetZamowienie()
        {
            return Ok(_context.Zamowienie.ToList());
        }

        // GET: api/Zamowienie/5
        [HttpGet("{id:int}")]
        public IActionResult GetOneZamowienie(int id)
        {
            var zamowienie = _context.Zamowienie.FirstOrDefault(e => e.Id == id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            return Ok(zamowienie);
        }
    }
}