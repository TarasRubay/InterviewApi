using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Dtos
{
    public class AccountDtoCreate
    {
        [Required(ErrorMessage = "'Name' is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "'Contact' is required")]
        public IEnumerable<ContactDtoCreate> Contacts { get; set; }
       
    }
}
