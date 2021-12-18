using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Dtos
{
    public class ContactDtoCreate
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name")]
        public string LastName { get; set; }

    }
}
