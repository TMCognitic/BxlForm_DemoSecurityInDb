using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSecurityInDb.Mvc.Models.Forms
{
    public class EditContactForm
    {
        [HiddenInput]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(384)]
        public string Email { get; set; }
    }
}
