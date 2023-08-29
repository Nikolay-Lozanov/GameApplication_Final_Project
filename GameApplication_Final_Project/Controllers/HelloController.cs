using GameApplication_Final_Project.Services.Hellodemo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GameApplication_Final_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HelloController : Controller
    {
        private readonly IDateService service;
        public HelloController(IDateService service)
        { 
            this.service = service;
        }
        

        // GET: HelloController
        public IActionResult Hello()
        {
            return this.StatusCode(StatusCodes.Status200OK, $"Hello to Game Application, the time is: {service.GetTime()}");
        }

        public IActionResult Greet()
        {
            return this.StatusCode(StatusCodes.Status200OK, $"Hello to Game Application");
        }


    }
}
