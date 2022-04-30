using System;
using System.ComponentModel.DataAnnotations;

namespace ConceptArchitect.BookManagement
{
    [Serializable]
    public class Book
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }

        public Author Author { get; set; }

        [Required]
        [Range(0,5000)]
        public int Price { get; set; }

        [Required]
        [Range(1,5)]
        public double Rating { get; set; }
        [Required]
        [StringLength(2000,MinimumLength=10)]
        public string Description { get; set; }

        [Required]
        public string Cover { get; set; }
        public string Tags { get; set; }
    }
}