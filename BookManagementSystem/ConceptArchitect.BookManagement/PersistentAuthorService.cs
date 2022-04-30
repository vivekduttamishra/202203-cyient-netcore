using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class PersistentAuthorService: IAuthorService
    {
        IAuthorRepository repository;
        public PersistentAuthorService(IAuthorRepository repository)
        {
            this.repository = repository;
        }

        public async Task AddAuthor(Author author)
        {
            await repository.AddAuthor(author);
            await repository.Save();
        }

        public async Task<IList<Author>> GetAllAuthors()
        {
            return await repository.GetAll();
        }

        public async Task<Author> GetAuthorById(string id)
        {
            var author= await repository.GetById(id);
            if (author == null)
                throw new InvalidEntityException("No Such Author", id);
            else
                return author;
        }

        public async Task Remove(string id)
        {
            var author = await GetAuthorById(id);
            await repository.Remove(id);
            await repository.Save();
            
        }

        public  async Task<IList<Author>> Search(string term)
        {
            term = term.ToLower();
            return await repository.GetAll((Author a) => a.Name.ToLower().Contains(term) ||
                                           a.Biography.ToLower().Contains(term));
        }

        public async Task Update(Author author)
        {
            var a = await GetAuthorById(author.Id);
            await repository.Update(author, (Author oldAuthor,Author newAuthor) =>
             {
                 oldAuthor.Name = newAuthor.Name;
                 oldAuthor.Email = newAuthor.Email;
                 oldAuthor.Biography = newAuthor.Biography;
                 oldAuthor.BirthDate = newAuthor.BirthDate;
                 oldAuthor.DeathDate = newAuthor.DeathDate;
                 oldAuthor.Photo = newAuthor.Photo;
             });
            await repository.Save();

        }
    }
}
