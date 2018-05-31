using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("heartbeat")]
    public class HeartbeatController : Controller
    {
        private readonly CrimeContext _context;

        public HeartbeatController(CrimeContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public IActionResult SiteIsRuning()
        {
            return Ok("Site is up");
        }

        [HttpGet("database")]
        public IActionResult DatabaseIsRunning()
        {

            try
            {
                _context.Database.OpenConnection();
                _context.Database.CloseConnection();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok("Database is running");


        }
    }
}
