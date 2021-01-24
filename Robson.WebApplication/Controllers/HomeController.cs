using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Robson.WebApplication.Models;
using Robson.WebApplication.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Robson.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPessoaService _pessoaService;

        public HomeController(ILogger<HomeController> logger, IPessoaService pessoaService)
        {
            _logger = logger;
            _pessoaService = pessoaService;
        }

        public async Task<IActionResult> Index()
        {
            var pessoas = await _pessoaService.GetPessoas();
            if (pessoas == null)
                return NoContent();

            ViewBag.pessoas = pessoas;
            return View();
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
