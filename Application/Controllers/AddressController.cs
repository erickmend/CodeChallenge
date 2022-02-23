using Application.Extensions;
using Domain.DTOs.Address;
using Domain.DTOs.Errors;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public class AddressController : Controller
    {
        private readonly ILogger<EmailController> _logger;
        private readonly IGenericRepositoryAPP<AddressInput> _addressRepository;

        public AddressController(ILogger<EmailController> logger, IGenericRepositoryAPP<AddressInput> addresslRepository)
        {
            _logger = logger;
            _addressRepository = addresslRepository;
        }

        public async Task<IActionResult> Index(int studentId)
        {
            ViewBag.StudentId = studentId;
            var response = await _addressRepository.GetAllAsync(studentId);

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
            var output = new Domain.DTOs.Address.AddressInput();
       
            return View(output);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int studentId, AddressInput dto)
        {
            ViewBag.StudentId = studentId;

      

            if (!ModelState.IsValid)
            {
                return View(dto)
                    .WithDanger("Error", "Porfavor llena los campos faltantes", "Aceptar");
            }

            var response = await _addressRepository.Add(dto, studentId);
            if (response.IsCompleted)
            {
                return RedirectToAction("Index", new { studentId = studentId })
                    .WithSuccess("Éxito", "Dirección creado", "Aceptar");
            }

            var output = (CodeErrorResponse)response.Result;
            return View(dto)
              .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int studentId, int id)
        {
            ViewBag.StudentId = studentId;

            var response = await _addressRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (AddressOutput)response.Result;
 
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
        public async Task<IActionResult> Edit(int studentId, int id, AddressInput dto)
        {
            ViewBag.StudentId = studentId;


            if (!ModelState.IsValid)
            {
                var outputError = new AddressOutput
                {
                    Id = id,
                    AddressLine = dto.AddressLine,
                    City = dto.City,
                    State = dto.State,
                    ZipPostCode = dto.ZipPostCode
                };

                return View(outputError)
                    .WithDanger("Error", "Porfavor llena los campos faltantes", "Aceptar");
            }
            var response = await _addressRepository.Update(id, dto);
            if (response.IsCompleted)
            {
                return RedirectToAction("Index", new { studentId = studentId })
                    .WithSuccess("Éxito", "Dirección editado", "Aceptar");
            }
            var output = (CodeErrorResponse)response.Result;
            return RedirectToAction("Index")
               .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int studentId, int id)
        {
            ViewBag.StudentId = studentId;

            var response = await _addressRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (AddressOutput)response.Result;

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

            var response = await _addressRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (AddressOutput)response.Result;
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

            var response = await _addressRepository.Delete(id);
            if (response.IsCompleted)
            {
                return RedirectToAction("Index", new { studentId = studentId })
                   .WithDanger("Éxito", "Dirección eliminado", "Aceptar");
            }

            var output = (CodeErrorResponse)response.Result;
            return RedirectToAction("Index")
               .WithDanger("Error", output.ErrorMessageSpanish, "Aceptar");
        }





    }
}
