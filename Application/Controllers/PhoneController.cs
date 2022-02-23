using Application.Extensions;
using Domain.DTOs.Errors;
using Domain.DTOs.Phone;
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
    public class PhoneController : Controller
    {
        private readonly ILogger<PhoneController> _logger;
        private readonly IGenericRepositoryAPP<PhoneInput> _PhoneRepository;

        public PhoneController(ILogger<PhoneController> logger, IGenericRepositoryAPP<PhoneInput> PhoneRepository)
        {
            _logger = logger;
            _PhoneRepository = PhoneRepository;
        }

        public async Task<IActionResult> Index(int studentId)
        {
            ViewBag.StudentId = studentId;
            var response = await _PhoneRepository.GetAllAsync(studentId);

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
            var output = new Domain.DTOs.Phone.PhoneInput();
            FillViewBag();
            return View(output);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int studentId, PhoneInput dto)
        {
            ViewBag.StudentId = studentId;

            FillViewBag(dto.PhoneType);

            if (!ModelState.IsValid)
            {
                return View(dto)
                    .WithDanger("Error", "Porfavor llena los campos faltantes", "Aceptar");
            }

            var response = await _PhoneRepository.Add(dto, studentId);
            if (response.IsCompleted)
            {
                return RedirectToAction("Index", new { studentId = studentId })
                    .WithSuccess("Éxito", "Teléfono creado", "Aceptar");
            }

            var output = (CodeErrorResponse)response.Result;
            return View(dto)
              .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int studentId, int id)
        {
            ViewBag.StudentId = studentId;

            var response = await _PhoneRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (PhoneOutput)response.Result;
                FillViewBag(output.PhoneType);
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
        public async Task<IActionResult> Edit(int studentId, int id, PhoneInput dto)
        {
            ViewBag.StudentId = studentId;

            FillViewBag(dto.PhoneType);
            if (!ModelState.IsValid)
            {
                var outputError = new PhoneOutput
                {
                    PhoneType = dto.PhoneType,
                    phone = dto.phone,
                    AreaCode = dto.AreaCode,
                    CountryCode = dto.CountryCode,
                    Id = id
                };

                return View(outputError)
                    .WithDanger("Error", "Porfavor llena los campos faltantes", "Aceptar");
            }
            var response = await _PhoneRepository.Update(id, dto);
            if (response.IsCompleted)
            {
                return RedirectToAction("Index", new { studentId = studentId })
                    .WithSuccess("Éxito", "Teléfono editado", "Aceptar");
            }
            var output = (CodeErrorResponse)response.Result;
            return RedirectToAction("Index")
               .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int studentId, int id)
        {
            ViewBag.StudentId = studentId;

            var response = await _PhoneRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (PhoneOutput)response.Result;
                FillViewBag(output.PhoneType);
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

            var response = await _PhoneRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (PhoneOutput)response.Result;
                FillViewBag(output.PhoneType);
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

            var response = await _PhoneRepository.Delete(id);
            if (response.IsCompleted)
            {
                return RedirectToAction("Index", new { studentId = studentId })
                   .WithDanger("Éxito", "Teléfono eliminado", "Aceptar");
            }

            var output = (CodeErrorResponse)response.Result;
            return RedirectToAction("Index")
               .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
        }




        void FillViewBag(PhoneType? type = null)
        {
            var PhoneTypes = new List<KeyValueItem>
            {
                new KeyValueItem{ Value = 1, Text = "Personal" },
                new KeyValueItem{ Value = 2, Text = "Work" },
                new KeyValueItem{ Value = 3, Text = "Professional" },
                new KeyValueItem{ Value = 4, Text = "Parent" },
            };
            ViewBag.PhoneTypes = new SelectList(PhoneTypes, "Value", "Text", type);
        }
    }
}
