using AutoMapper;
using InterviewApi.DataContex;
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
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository _repository;
       
        
        public AccountController(AccountRepository accountrepository)
        {
            _repository = accountrepository;

        }
       
       
        [HttpGet]
        public ActionResult<IEnumerable<AccountDto>> Get()
        {
            var models = _repository.GetAll().Select(p => AccountDto.FromModel(p));
            if (!models.Any()) return NotFound("list of Account is empty.");
            
            return Ok(models);
        }

        
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public ActionResult<AccountDto> Get(int id)
        {
            var model = _repository.GetById(id);
            if (model is null) return NotFound($"No found account id = {id}");
            return Ok(AccountDto.FromModel(model));
        }

        
        [HttpPost]
        public ActionResult<AccountDto> Post([FromBody] AccountDtoCreate accountDtoCreate)
        {
            var model = _repository.Create(new Account
            {
                Name = accountDtoCreate.Name,
                Contacts = accountDtoCreate.Contacts.Select(it => new Contact()
                {  
                    Email = it.Email,
                    FirstName = it.FirstName,
                    LastName = it.LastName,
                }).ToList()
            });

            var mod = _repository.GetAll().Where(p => p.Name == model.Name).FirstOrDefault();
            if (model is null) return NotFound($"no saved account");
            return Ok(AccountDto.FromModel(model));
        }

      
    }
}
