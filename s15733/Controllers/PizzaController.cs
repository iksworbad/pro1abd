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
    public class PizzaController : ControllerBase
    {
        private s15733Context _context;
        public PizzaController(s15733Context context)
        {
            _context = context;
        }

        // GET: api/Pizza
        [HttpGet]
        public IActionResult GetPizza()
        {
            return Ok(_context.Pizza.ToList());
        }

        // GET: api/Pizza/5
        [HttpGet("{id:int}")]
        public IActionResult GetOnePizza(int id)
        {
            var pizza = _context.Pizza.FirstOrDefault(e => e.Id == id);
            if (pizza == null)
            {
                return NotFound();
            }
            return Ok(pizza);
        }
    }
}
