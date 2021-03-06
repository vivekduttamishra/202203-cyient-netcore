using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class InMemoryAuthorService : IAuthorService
    {
        Dictionary<string, Author> authors = new Dictionary<string, Author>();

        public  InMemoryAuthorService()
        {
            AddSampleAuthors().Wait();
        }

        private async Task AddSampleAuthors()
        {
            Author[] _authors =
            {
                new Author()
                {
                    Name="Vivek Dutta Mishra",
                    Photo="https://avatars.githubusercontent.com/u/9464908?v=4",
                    Biography="Author of Amazon #1 Best seller The Accursed God",
                    Email="vivek@thelostepic.com",
                    BirthDate=DateTime.Parse("1977/07/09")
                },

                new Author()
                {
                    Name="Alexandre Dumas",
                    Photo="https://biographygist.com/wp-content/uploads/2021/05/Alexandre-Dumas1.jpg",
                    Biography="One of the altime greatest author of English and French",
                    BirthDate=DateTime.Parse("1803/01/01"),
                    DeathDate=DateTime.Parse("1878/01/01"),
                },
                new Author()
                {
                    Name="Conan Doyle",
                    Photo="https://cdn.vocab.com/units/fsyoq26b/author.jpg?width=400&v=16d64ff4cf4",
                    Biography="The creator of famous Sherlock Holmes",
                    BirthDate=DateTime.Parse("1860/01/01"),
                    DeathDate=DateTime.Parse("1918/01/01"),

                },
                new Author()
                {
                    Name="Jeffrey Archer",
                    Photo="https://pbs.twimg.com/media/FIgReE4WUAEw9cL.jpg",
                    Biography ="One of the contemporary best seller author in English Fiction",
                    Email="jeffrey.archer@gmail.com",
                    BirthDate=DateTime.Parse("1946/01/01")
                    
                },

                new Author()
                {
                    Name="John Grisham",
                    Photo="https://res.cloudinary.com/bookbub/image/upload/w_400,h_400,c_fill,g_face/v1580317832/john-grisham.jpg",
                    Biography="Best seller author Legal Fiction",
                    Email="john@grisham.com",
                    BirthDate=DateTime.Parse("1957/01/01")
                }

            };

            foreach (var author in _authors)
            {
                author.Id = author.Name.ToLower().Replace(" ", "-");
                await AddAuthor(author);
            }
                
            
        }

        public async Task AddAuthor(Author author)
        {
            await Task.Yield();
            authors[author.Id.ToLower()] = author;
        }

        public async Task<IList<Author>> GetAllAuthors()
        {
            await Task.Yield();
            return authors.Values.ToList();
        }

        public async Task<Author> GetAuthorById(string id)
        {
            await Task.Yield();
            if (authors.ContainsKey(id))
                return authors[id];
            else
                return null;
        }

        public async Task<IList<Author>> Search(string term)
        {
            term = term.ToLower();
            await Task.Yield();
            return authors.Values.Where(a => a.Name.ToLower().Contains(term) || a.Biography.ToLower().Contains(term)).ToList(); //dummy logic
        }


        public async Task Update(Author author)
        {
            await Task.Yield();
        }


        public async Task Remove(string id)
        {
            await Task.Yield();
        }



    }
}
