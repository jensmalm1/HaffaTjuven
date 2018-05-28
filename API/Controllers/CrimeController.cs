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
            return Ok(_context.Users.Include(i => i.Informations).ToList());
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok($"Användare {user.UserName} tillagd med ID {user.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("CheckIfUserExists")]
        public IActionResult LoggInUser(string userInput)
        {

            var user = new User
            {
                UserName = userInput
            };

            var listOfUsers = new List<string>();
            try
            {
                listOfUsers = _context.Users.Select(n => n.UserName).ToList();


                //if (listOfUsers.Contains(u => u, user.UserName))
                {

                    return Ok("funkar");
                }

                return Ok("Funkar ej");

            }
            catch (Exception e)
            {
                return Ok(e);

            }




            //User getUser;
            //getUser = _context.Users.Single(u => u.UserName == user.UserName);
            //return Ok(getUser);
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
                return BadRequest(e);
            }
        }


    }
}
