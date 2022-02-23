using Domain.DTOs.Email;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class EmailController : Controller
    {
        private readonly ILogger<EmailController> _logger;
        private readonly IGenericRepositoryAPP<EmailInput> _emailRepository;

        public EmailController(ILogger<EmailController> logger, IGenericRepositoryAPP<EmailInput> emailRepository)
        {
            _logger = logger;
            _emailRepository = emailRepository;
        }

        public async Task<IActionResult> Index(int studentId)
        {
            var response = await _emailRepository.GetAllAsync();

            if (response.IsCompleted)
            {
                return View(response.Result);
            }

            return View();
        }

    }
}
