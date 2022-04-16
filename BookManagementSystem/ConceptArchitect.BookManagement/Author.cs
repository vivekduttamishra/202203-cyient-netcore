using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConceptArchitect.BookManagement
{
    public class Author
    {
        [Required]
        public string Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        [StringLength(2000,MinimumLength =10)]
        public string Biography { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DeathDate { get; set; } //optional

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
