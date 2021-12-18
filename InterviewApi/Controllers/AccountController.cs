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
       
        // GET: api/<AccountController>
        [HttpGet]
        public ActionResult<IEnumerable<AccountDto>> Get()
        {
            var models = _repository.GetAll().Select(p => AccountDto.FromModel(p));
            return Ok(models);
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
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
            
            return Ok();
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
