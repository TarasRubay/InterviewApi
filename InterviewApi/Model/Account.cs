using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Model
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("FK_Accounts_Incidents_IncidentName")]
        public string IncidentName { get; set; }

        public Incident Incident { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }

    }
}
