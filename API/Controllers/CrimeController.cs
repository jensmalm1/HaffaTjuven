using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{



    [Route("api/")]
    public class CrimeController : Controller
    {
        private readonly CrimeContext _context;

        public CrimeController(CrimeContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Det", "Funakr" };
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return Ok(user.Name);
        }
       
    }
}
