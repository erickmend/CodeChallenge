using Domain.DTOs.Errors;
using Domain.DTOs.Student;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IGenericRepository<Student> _StudentRepository;

        public StudentController(IGenericRepository<Student> StudentRepository)
        {
            _StudentRepository = StudentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentOutput>>> GetList()
        {
            var entities = await _StudentRepository.GetAllAsync();
            var output = entities.Select(x => x.ToOutput()).ToList();
            return Ok(output);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<StudentOutput>> GetById(int id)
        {
            var entity = await _StudentRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }
            var output = entity.ToOutput();
            return Ok(output);
        }

        [HttpPost]

        public async Task<ActionResult<StudentOutput>> Post(StudentInput dto)
        {
            var entity = new Student(dto);
            var response = await _StudentRepository.Add(entity);
            if (response == 0)
            {
                return BadRequest(new CodeErrorResponse(404));
            }
            var output = entity.ToOutput();

            return Ok(output);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentOutput>> Put(int id, StudentInput dto)
        {
            var entity = await _StudentRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }

            entity.Edit(dto);
            var response = await _StudentRepository.Update(entity);
            if (response == 0)
            {
                return BadRequest(new CodeErrorResponse(404));
            }
            var output = entity.ToOutput();

            return Ok(output);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var response = await _StudentRepository.Delete(id);
            if (response == 0)
            {
                return BadRequest(new CodeErrorResponse(404));
            }
            return Ok();
        }
    }
}
