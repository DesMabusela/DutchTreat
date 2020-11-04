using DutchTreat.Data;
using DutchTreat.Services;
using DutchTreat.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Mail;

namespace DutchTreat.Controllers
{
    public class AppController : Controller
    {

        private readonly IMailService _mailService;
        private readonly IDutchRepository _repository;
        public AppController(IMailService mailSerivce, IDutchRepository repository)
        {
            _mailService = mailSerivce;
            _repository = repository;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet("contact")]

        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Us";
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                _mailService.SendMessage("Desree@gmail.com", model.Subject, $"From:{model.Name}-{model.Email}, Message:{model.Mesg}");
                ViewBag.UserMessage = "Mail sent";
                ModelState.Clear();
            }

            else
            {
               
            }

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About us";
            return View();

        }

        public IActionResult Shop()
            {
            var results = _repository.GetAllProducts();
               
               return View(results);

            }

    }
}
