using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HistoriaClinica.Models;
using HistoriaClinica.Servicios;

namespace HistoriaClinica.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioPaciente repositorioPaciente;
        

        public HomeController(IRepositorioPaciente repositorioPaciente)
        {
            this.repositorioPaciente = repositorioPaciente;
            
        }

       

        public IActionResult Index()
        {
            ViewBag.Nombre = "Juan Luis";
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistroPaciente()
        {
            return View();
        }

        public async Task<IActionResult> ListadoPaciente()
        {
            var pacientes = await repositorioPaciente.Obtener();
            return View(pacientes);
        }

        [HttpPost]
        public async Task<IActionResult> RegistroPaciente(RegistroPaciente registroPaciente)
        {

            if (ModelState.IsValid) {
                await repositorioPaciente.RegistrarPaciente(registroPaciente);
                registroPaciente.username = "";
                registroPaciente.email = "";
                return View();
            }
            else
            {
                return View(registroPaciente);
            }


        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
