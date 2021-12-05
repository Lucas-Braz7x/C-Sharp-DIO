using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Recode_exercicio.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Recode_exercicio.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public static IList<Curso> cursos = new List<Curso>()
        {
            new Curso()
            {
                Id = 1,
                Descricao = "HTML",
                CargaHoraria =15,
            },
            new Curso()
            {
                Id = 2,
                Descricao = "CSS",
                CargaHoraria =12,
            },
            new Curso()
            {
                Id = 3,
                Descricao = "JavaScript",
                CargaHoraria =30,
            }
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cursos()
        {
            return View(cursos);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
