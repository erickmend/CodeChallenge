﻿using Application.Models;
using Domain.DTOs.Errors;
using Domain.DTOs.Student;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<IActionResult> Index()
        {
            var response = await _studentRepository.GetAllAsync();

            if (response.IsCompleted)
            {
                return View(response.Result);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var output = new Domain.DTOs.Student.StudentInput();
            FillViewBag();
            return View(output);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(StudentInput dto)
        {
            if (!ModelState.IsValid)
            {
                FillViewBag(dto.Gender);
                return View(dto);
            }
            var response = await _studentRepository.Add(dto);

            if (response.IsCompleted)
            {
                //change to redirect
                return View(response.Result);
            }
            FillViewBag(dto.Gender);

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _studentRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (StudentOutput)response.Result;
                FillViewBag(output.Gender);
                return View(output);
            }
            else
            {
                var output = (CodeErrorResponse)response.Result;
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id , StudentInput dto)
        {
            FillViewBag(dto.Gender);
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            var response = await _studentRepository.Update(id, dto);
            if (response.IsCompleted)
            {
                return View(response.Result);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var response = await _studentRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (StudentOutput)response.Result;
                FillViewBag(output.Gender);
                return View(output);
            }
            else
            {
                var output = (CodeErrorResponse)response.Result;
                return View();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _studentRepository.GetByIdAsync(id);
            if (response.IsCompleted)
            {
                var output = (StudentOutput)response.Result;
                FillViewBag(output.Gender);
                return View(output);
            }
            else
            {
                var output = (CodeErrorResponse)response.Result;
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var response = await _studentRepository.Delete(id);
            if (response.IsCompleted)
            {
                return View(response.Result);
            }
            return View();
        }




        void FillViewBag(Gender? gender = null)
        {
            var genders = new List<KeyValueItem>
            {
                new KeyValueItem{ Value = 1, Text = "Masculino" },
                new KeyValueItem{ Value = 2, Text = "Femenino" },
                new KeyValueItem{ Value = 3, Text = "Otro" },
            };
            ViewBag.Genders = new SelectList(genders, "Value", "Text", gender);
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
