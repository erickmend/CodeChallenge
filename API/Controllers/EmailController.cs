using Domain.DTOs.Email;
using Domain.DTOs.Errors;
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
    public class EmailController : ControllerBase
    {
        private readonly IGenericRepository<Email> _EmailRepository;
        private readonly IGenericRepository<Student> _studentRepository;

        public EmailController(IGenericRepository<Email> EmailRepository, IGenericRepository<Student> studentRepository)
        {
            _EmailRepository = EmailRepository;
            _studentRepository = studentRepository;
        }

        [HttpGet("Student/{studentId}")]
        public async Task<ActionResult<List<EmailOutput>>> GetList(int studentId)
        {
            var entities = await _EmailRepository.GetAllAsync(studentId);
            var output = entities.Select(x => x.ToOutput()).ToList();
            return Ok(output);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EmailOutput>> GetById(int id)
        {
            var entity = await _EmailRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }
            var output = entity.ToOutput();
            return Ok(output);
        }

        [HttpPost]
        public async Task<ActionResult<EmailOutput>> Post(int studentId, EmailInput dto)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }

            var entity = new Email(studentId, student ,dto);
            var response = await _EmailRepository.Add(entity);
            if (response == 0)
            {
                return BadRequest(new CodeErrorResponse(404));
            }
            var output = entity.ToOutput();

            return Ok(output);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmailOutput>> Put(int id, EmailInput dto)
        {
            var entity = await _EmailRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }

            entity.Edit(dto);
            var response = await _EmailRepository.Update(entity);
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
            var response = await _EmailRepository.Delete(id);
            if (response == 0)
            {
                return BadRequest(new CodeErrorResponse(404));
            }
            return Ok();
        }
    }
}
