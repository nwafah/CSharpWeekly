using DependencyInjectionLifetimes.Scoped.Contracts;
using DependencyInjectionLifetimes.ServiceLifetimes.GeneralServices;
using DependencyInjectionLifetimes.Singleton.Contracts;
using DependencyInjectionLifetimes.Transient.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionLifetimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("Scoped")]
        public IActionResult GetScoped(IScopedOperation operation1,IMyScopedService myService)
        {
            myService.CallOperation();
            Console.WriteLine("Operation Scoped ID: " + operation1.Id);
            return Ok();
        }
        [HttpGet("Transient")]
        public IActionResult GetTransient(ITransientOperation operation1, IMyTransientService myService)
        {
            myService.CallOperation();
            Console.WriteLine("Operation Transient ID: " + operation1.Id);
            return Ok();
        }
        [HttpGet("Singleton")]
        public IActionResult GetSingleton(ISingletonOperation operation1, IMySingletonService myService)
        {
            myService.CallOperation();
            Console.WriteLine("Operation Singleton ID: " + operation1.Id);
            return Ok();
        }
    }
}
