using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

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

        [HttpPost("AddUser")]
        public IActionResult AddUser(User user)
        {
            if (user.UserName == null || user.Password == null)
            {
                return BadRequest("Måste ange användarnamn och lösenord");
            }

            var listOfUserNames = _context.Users.Select(n => n.UserName).ToList();
            if (listOfUserNames.Contains(user.UserName))
            {
                return BadRequest("Användarnamnet finns redan");
            }
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


        [HttpGet("GetProfile")]

        public IActionResult GetProfile(User user)
        {

            var getUser = _context.Users.Single(u => u.UserName == user.UserName);
            return Ok(getUser);

        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var removeUser = _context.Users.SingleOrDefault(u => u.Id == id);

                if (removeUser == null)
                    return NotFound();

                _context.Users.Remove(removeUser);
                _context.SaveChanges();
                return Ok("Användaren är borttagen");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        public string SessionUserName = "username";
        
     

        [HttpPost("SetSession")]
        public IActionResult SetSession(string userName, string password)
        {

                
            var listOfUserNames = _context.Users.Select(n => n.UserName).ToList();
            var listOfUsers = _context.Users.Where(n => n.UserName == userName).ToList();
            var correctPass = listOfUsers.FirstOrDefault(x => x.UserName == userName).Password;

            if (!listOfUserNames.Any(x => x.Contains(userName)))
            {
                return Ok("Username  is incorrect");
            }

            if (password!=correctPass)
            {
                return Ok("Password incorrect");
            }

            
               HttpContext.Session.SetString(SessionUserName, userName);
                return Ok($"Session {SessionUserName}={userName}");

        }

        [HttpGet("GetSessionUser")]
        public IActionResult GetSessionUser()
        {

            var userName = HttpContext.Session.GetString(SessionUserName);
                return Ok(userName);

        }

        [HttpGet("GetSessionInformation")]
        public IActionResult GetSessionInformation()
        {
            var userName = HttpContext.Session.GetString(SessionUserName);
            var information = _context.Users.Where(i => i.UserName == userName).SelectMany(i => i.Informations).ToList();


            
            var listOfInformation = new List<string>();
            foreach (var info in information)
            {

                listOfInformation.Add($"<tr><td>{info.Content}</td></tr>");

            }
            return Ok(listOfInformation);

        }
        [HttpPost("EndSession")]
        public IActionResult EndSession()
        {
            HttpContext.Session.Clear();
            return Ok($"Session ended");

        }

        //[HttpGet("GetSessionUserName")]
        //public IActionResult GetSession()
        //{

        //    var userName = HttpContext.Session.GetString(SessionUserName);
        //    return Ok($"Got Session name {userName}");
        //}

        //public IActionResult EndSession()
        //{

        //    HttpContext.Session.Contents.Remove(SessionUserName);
        //    return Ok("Session Ended");
        //}


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
                return BadRequest( e);
            }
        }


    }
}
