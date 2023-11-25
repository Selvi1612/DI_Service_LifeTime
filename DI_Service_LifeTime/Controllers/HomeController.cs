using DI_Service_LifeTime.Models;
using DI_Service_LifeTime.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;

namespace DI_Service_LifeTime.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScoopedGuidService _scoped1;
        private readonly IScoopedGuidService _scoped2;

        private readonly ISingletonGuidService _singleton1;
        private readonly ISingletonGuidService _singleton2;

        private readonly ITransientGuidService _Transient1; 
        private readonly ITransientGuidService _Transient2;

        public HomeController(IScoopedGuidService scop1, IScoopedGuidService scop2, ISingletonGuidService sin1, ISingletonGuidService sin2, ITransientGuidService tran1, ITransientGuidService tran2 )
        {
            _scoped1 = scop1;
            _scoped2 = scop2;
            _singleton1 = sin1;
            _singleton2 = sin2;
            _Transient1 = tran1;    
            _Transient2 = tran2; 
        }

        public IActionResult Index()
        {
            StringBuilder messages = new StringBuilder();
            messages.Append($"Transient 1: {_Transient1.GetGuid()}\n");
            messages.Append($"Transient 2: {_Transient2.GetGuid()}\n\n\n");
            messages.Append($"Scoped 1: {_scoped1.GetGuid()}\n");
            messages.Append($"Scoped 2: {_scoped2.GetGuid()}\n\n\n");
            messages.Append($"SingleTon 1: {_singleton1.GetGuid()}\n");
            messages.Append($"SingleTon 2: {_singleton2.GetGuid()}\n\n\n");
            return Ok(messages.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
