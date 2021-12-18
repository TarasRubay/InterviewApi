using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Dtos
{
    public class IncidentDtoCreate
    {
        [Required(ErrorMessage = "'Description' is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "'Account' is required")]
        public IEnumerable<AccountDtoCreate> Accounts { get; set; }
    }
}
