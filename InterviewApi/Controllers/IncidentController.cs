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
    public class IncidentController : ControllerBase
    {
        private readonly IncidentRepository _repository;


        public IncidentController(IncidentRepository incidentrepository)
        {
            _repository = incidentrepository;

        }

        
        [HttpGet]
        public ActionResult<IEnumerable<IncidentDto>> Get()
        {
            var models = _repository.GetAll().Select(p => IncidentDto.FromModel(p));
            if (models is null) return NoContent();
            return Ok(models);
        }

        
        [HttpGet("{name}")]
        public ActionResult<IncidentDto> Get(string name)
        {
            var model = _repository.GetByName(name);
            if (model is null) return NotFound($"No found incedent name = {name}");
            return Ok(IncidentDto.FromModel(model));
        }

       
        [HttpPost]
        public ActionResult<IncidentDto> Post([FromBody] IncidentDtoCreate incidentDtoCreate)
        {
            var model = _repository.Create(new Incident()
            {
                Description = incidentDtoCreate.Description
               
            }
            );

            return CreatedAtRoute(nameof(Get), new { model.Name }, IncidentDto.FromModel(model)); ;
        }

    }
}
