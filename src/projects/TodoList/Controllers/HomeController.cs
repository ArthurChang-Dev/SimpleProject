using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("home")]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Welcome to Beanstalk";
        }

        [HttpGet("ping")]
        public string Ping()
        {
            return "Pong";
        }

        [HttpGet("test")]
        public string Test()
        {
            return "This is a test.";
        }

    }
}
