using Application.Extensions;
using Domain.DTOs.Email;
using Domain.DTOs.Errors;
using Domain.DTOs.Student;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.StudentId = studentId;
            var response = await _emailRepository.GetAllAsync(studentId);

            if (response.IsCompleted)
            {
                return View(response.Result);
            }

            return View();
        }



        [HttpGet]
        public IActionResult Create(int studentId)
        {
            ViewBag.StudentId = studentId;
            var output = new Domain.DTOs.Email.EmailInput();
            FillViewBag();
            return View(output);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int studentId, EmailInput dto)
        {
            ViewBag.StudentId = studentId;

            FillViewBag(dto.EmailType);

            if (!ModelState.IsValid)
            {
                return View(dto)
                .WithDanger("Error", "Porfavor llena los campos faltantes", "Aceptar");
            }

            var response = await _emailRepository.Add(dto, studentId);
            if (response.IsCompleted)
            {
                return RedirectToAction("Index", new { studentId = studentId })
                    .WithSuccess("Éxito", "Correo creado", "Aceptar");
            }

            var output = (CodeErrorResponse)response.Result;
            return View(dto)
              .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int studentId, int id)
        {
            ViewBag.StudentId = studentId;

            var response = await _emailRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (EmailOutput)response.Result;
                FillViewBag(output.EmailType);
                return View(output);
            }
            else
            {
                var output = (CodeErrorResponse)response.Result;
                return RedirectToAction("Index", new { studentId = studentId })
                   .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int studentId, int id, EmailInput dto)
        {
            ViewBag.StudentId = studentId;

            FillViewBag(dto.EmailType);
            if (!ModelState.IsValid)
            {
                var outputError = new EmailOutput
                {
                    EmailType = dto.EmailType,
                    email = dto.email,
                    Id = id
                };

                return View(outputError)
                    .WithDanger("Error", "Porfavor llena los campos faltantes", "Aceptar");
            }
            var response = await _emailRepository.Update(id, dto);
            if (response.IsCompleted)
            {
                return RedirectToAction("Index", new { studentId = studentId })
                    .WithSuccess("Éxito", "Correo editado", "Aceptar");
            }
            var output = (CodeErrorResponse)response.Result;
            return RedirectToAction("Index")
               .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int studentId, int id)
        {
            ViewBag.StudentId = studentId;

            var response = await _emailRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (EmailOutput)response.Result;
                FillViewBag(output.EmailType);
                return View(output);
            }
            else
            {
                var output = (CodeErrorResponse)response.Result;
                return RedirectToAction("Index", new { studentId = studentId })
                   .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int studentId, int id)
        {
            ViewBag.StudentId = studentId;

            var response = await _emailRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (EmailOutput)response.Result;
                FillViewBag(output.EmailType);
                return View(output);
            }
            else
            {
                var output = (CodeErrorResponse)response.Result;
                return RedirectToAction("Index", new { studentId = studentId })
                   .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
            }

        }
        [HttpPost]
        public async Task<IActionResult> DeleteItem(int studentId, int id)
        {
            ViewBag.StudentId = studentId;

            var response = await _emailRepository.Delete(id);
            if (response.IsCompleted)
            {
                return RedirectToAction("Index", new { studentId = studentId })
                   .WithDanger("Éxito", "Correo eliminado", "Aceptar");
            }

            var output = (CodeErrorResponse)response.Result;
            return RedirectToAction("Index")
               .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
        }




        void FillViewBag(EmailType? type = null)
        {
            var emailTypes = new List<KeyValueItem>
            {
                new KeyValueItem{ Value = 1, Text = "Personal" },
                new KeyValueItem{ Value = 2, Text = "Work" },
                new KeyValueItem{ Value = 3, Text = "Professional" },
                new KeyValueItem{ Value = 4, Text = "Parent" },
            };
            ViewBag.EmailTypes = new SelectList(emailTypes, "Value", "Text", type);
        }
    }
}
