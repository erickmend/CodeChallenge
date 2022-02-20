using Domain.DTOs.Errors;
using Domain.DTOs.Phone;
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
    public class PhoneController : ControllerBase
    {
        private readonly IGenericRepository<Phone> _phoneRepository;

        public PhoneController(IGenericRepository<Phone> phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PhoneOutput>>> GetList()
        {
            var entities = await _phoneRepository.GetAllAsync();
            var output = entities.Select(x => x.ToOutput()).ToList();
            return Ok(output);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PhoneOutput>> GetById(int id)
        {
            var entity = await _phoneRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }
            var output = entity.ToOutput();
            return Ok(output);
        }

        [HttpPost]
        public async Task<ActionResult<PhoneOutput>> Post(PhoneInput dto)
        {
            var entity = new Phone(dto);
            var response = await _phoneRepository.Add(entity);
            if (response == 0)
            {
                return BadRequest(new CodeErrorResponse(404));
            }
            var output = entity.ToOutput();

            return Ok(output);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PhoneOutput>> Put(int id, PhoneInput dto)
        {
            var entity = await _phoneRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }

            entity.Edit(dto);
            var response = await _phoneRepository.Update(entity);
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
            var response = await _phoneRepository.Delete(id);
            if (response == 0)
            {
                return BadRequest(new CodeErrorResponse(404));
            }
            return Ok();
        }
    }
}
