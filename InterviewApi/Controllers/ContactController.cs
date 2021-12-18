using InterviewApi.Dtos;
using InterviewApi.Model;
using InterviewApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactRepository _repository;


        public ContactController(ContactRepository contactrepository)
        {
            _repository = contactrepository;

        }

      
        [HttpGet]
        public ActionResult<IEnumerable<ContactDto>> Get()
        {
            var models = _repository.GetAll().Select(p => ContactDto.FromModel(p));
            if (models is null) return NoContent();
            return Ok(models);
        }

        
        [HttpGet("{id}")]
        public ActionResult<ContactDto> Get(int id)
        {
            var model = _repository.GetById(id);
            if (model is null) return NotFound($"No found contact id = {id}");
            return Ok(ContactDto.FromModel(model));
        }

        
        [HttpPost]
        public ActionResult<ContactDto> Post([FromBody] ContactDtoCreate contactDtoCreate)
        {
            var model = _repository.Create(new Contact()
            {
                Email = contactDtoCreate.Email,
                FirstName = contactDtoCreate.FirstName,
                LastName = contactDtoCreate.LastName
            }
            );

            return CreatedAtRoute(nameof(Get), new { model.Id }, ContactDto.FromModel(model)); ;
        }

    }
}
