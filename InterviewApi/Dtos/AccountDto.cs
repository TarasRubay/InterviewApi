using InterviewApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Dtos
{
    public class AccountDto
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

      
        public string IncidentName { get; set; }

        public Incident Incident { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }
        public Account ToModel()
        {
            return new()
            {
                Id = Id,
                Name = Name,
                IncidentName = IncidentName,
                Incident = Incident,
                Contacts = Contacts.Select(it => new Contact()
                {
                    Id = it.Id,
                    Email = it.Email,
                    FirstName = it.FirstName,
                    LastName = it.LastName,
                    AccountId = it.AccountId,
                    Account = it.Account
                }).ToList()
            };
        }
        public static AccountDto FromModel(Account account)
        {
            return new()
            {
                Id = account.Id,
                Name = account.Name,
                IncidentName = account.IncidentName,
                Incident = account.Incident,
                Contacts = account.Contacts.Select(it => new ContactDto()
                {
                    Id = it.Id,
                    Email = it.Email,
                    FirstName = it.FirstName,
                    LastName = it.LastName,
                    AccountId = it.AccountId,
                    Account = it.Account
                }
                ).ToList() as IEnumerable<Contact>
            };
        }
    }
}
