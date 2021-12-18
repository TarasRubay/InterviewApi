using InterviewApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Dtos
{
    public class ContactDto
    {
       
        public int Id { get; set; }

       
        public string Email { get; set; }

        
        public string FirstName { get; set; }

       
        public string LastName { get; set; }

       
        public int? AccountId { get; set; }

        public static ContactDto FromModel(Contact it)
        {
            return new()
            {
               
                Email = it.Email,
                FirstName = it.FirstName,
                LastName = it.LastName,
                AccountId = it.AccountId
               
            };
       }
    }
}
