using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConceptArchitect.BookManagement
{
    public class User
    {
       // public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Key]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        //[Required]
        //public string ApiKey { get; set; }
    }

}
