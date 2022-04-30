using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConceptArchitect.BookManagement.EFRepository
{
    public  class BMSContext:DbContext
    {
        public BMSContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
