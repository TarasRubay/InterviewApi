using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewApi.Model
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "'Email' is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "'FirstName' is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "'LastName' is required")]
        public string LastName { get; set; }

        [ForeignKey("FK_Contacts_Accounts_AccountId")]
        public int? AccountId { get; set; }

        public Account Account { get; set; }
    }
}
