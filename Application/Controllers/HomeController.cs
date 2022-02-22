using Application.Models;
using Domain.DTOs.Student;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepositoryAPP<StudentInput> _studentRepository;

        public HomeController(ILogger<HomeController> logger, IGenericRepositoryAPP<StudentInput> studentRepository)
        {
            _logger = logger;
            _studentRepository = studentRepository;

        }

        public async Task<IActionResult> IndexAsync()
        {
            var input = new StudentInput
            {
                FirstName = "Juan",
                LastName = "Quintero",
                MiddleName = "si",
                Gender = Domain.Enums.Gender.Male
            };

            var response = await _studentRepository.Add(input);
            if (response.IsCompleted)
            {
                return Ok(response.Result);
            }
            else
            {
                return BadRequest(response.Result);
            }

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
