using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Robson.WebApplication.Models;
using Robson.WebApplication.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Robson.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPessoaService _pessoaService;
        private readonly ICarreiraService _carreiraService;

        public HomeController(ILogger<HomeController> logger, IPessoaService pessoaService, ICarreiraService carreiraService)
        {
            _logger = logger;
            _pessoaService = pessoaService;
            _carreiraService = carreiraService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var pessoa = await _pessoaService.GetPessoa(1);
                var carreiras = await _carreiraService.GetCarreiras();

                if (pessoa == null || carreiras == null)
                    return NoContent();

                ViewBag.pessoa = pessoa;
                ViewBag.carreiras = carreiras.OrderByDescending(o => o.DataInicio).ToList();
                return View();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
