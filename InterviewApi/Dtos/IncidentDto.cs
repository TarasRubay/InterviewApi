using InterviewApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Dtos
{
    public class IncidentDto
    {
       
        public string Name { get; set; }

       
        public string Description { get; set; }

        public IEnumerable<Account> Accounts { get; set; }

        public Incident ToModel() {
            return new()
            {
                Name = Name,
                Description = Description,
                Accounts = Accounts.Select(m => AccountDto.FromModel(m)) as IEnumerable<Account>
            };
        }
        public static IncidentDto FromModel(Incident incident)
        {
            return new()
            {
                Name = incident.Name,
                Description = incident.Description,
                Accounts = incident.Accounts.Select(d => new AccountDto()
                {
                    Id = d.Id,
                    Name = d.Name,
                    IncidentName = d.IncidentName,
                    Incident = d.Incident,
                    Contacts = d.Contacts.Select(it => new Contact()
                    {
                        Id = it.Id,
                        Email = it.Email,
                        FirstName = it.FirstName,
                        LastName = it.LastName,
                        AccountId = it.AccountId,
                        Account = it.Account
                    }).ToList()
                }) as IEnumerable<Account>
            };
        }
    }
}
