using Domain.DTOs.Address;
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
    public class AddressController : ControllerBase
    {
        private readonly IGenericRepository<Address> _AddressRepository;
        private readonly IGenericRepository<Student> _studentRepository;

        public AddressController(IGenericRepository<Address> AddressRepository, IGenericRepository<Student> studentRepository)
        {
            _AddressRepository = AddressRepository;
            _studentRepository = studentRepository;
        }

        [HttpGet("Student/{studentId}")]
        public async Task<ActionResult<List<AddressOutput>>> GetList(int studentId)
        {
            var entities = await _AddressRepository.GetAllAsync(studentId);
            var output = entities.Select(x => x.ToOutput()).ToList();
            return Ok(output);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AddressOutput>> GetById(int id)
        {
            var entity = await _AddressRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }
            var output = entity.ToOutput();
            return Ok(output);
        }

        [HttpPost]
        public async Task<ActionResult<AddressOutput>> Post(int studentId, AddressInput dto)
        {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }
            var entity = new Address(studentId,student,dto);
            var response = await _AddressRepository.Add(entity);
            if (response == 0)
            {
                return BadRequest(new CodeErrorResponse(404));
            }
            var output = entity.ToOutput();

            return Ok(output);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AddressOutput>> Put(int id, AddressInput dto)
        {
            var entity = await _AddressRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }

            entity.Edit(dto);
            var response = await _AddressRepository.Update(entity);
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
            var response = await _AddressRepository.Delete(id);
            if (response == 0)
            {
                return BadRequest(new CodeErrorResponse(404));
            }
            return Ok();
        }
    }
}
