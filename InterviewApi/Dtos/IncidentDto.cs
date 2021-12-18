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

       
        public static IncidentDto FromModel(Incident incident)
        {
            return new()
            {
                Name = incident.Name,
                Description = incident.Description 
            };
        }
    }
}
