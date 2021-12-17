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
        public AccountController(AccountRepository accountRepository)
        {
            _repository = accountRepository;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<AccountDto> Get()
        {
            return Ok(_repository.GetAccounts().Select(p => AccountDto.FromModel(p))) as IEnumerable<AccountDto>;
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
