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
            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            //_context.Database.Migrate();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Det Funakr");
        }

        [HttpGet("ShowUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.Include(i=>i.Informations).ToList());
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user.Name);
        }

        [HttpPost("AddInformation")]
        public IActionResult AddInformation(Information information)
        {


            try
            {
               // var user = _context.Users.First();
                //x => x.Id == information.UserId
                _context.Informations.Add(information);
                _context.SaveChanges();

                return Ok(information.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest( e);
            }
        }


    }
}
