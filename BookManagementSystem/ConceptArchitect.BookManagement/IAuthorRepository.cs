using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public interface IAuthorRepository
    {
        Task AddAuthor(Author author);
        Task<Author> GetById(string id);
        Task Remove(string id);
        Task<IList<Author>> GetAll();
        Task<IList<Author>> GetAll(Func<Author, bool> p);
        Task Update(Author author, Action<Author, Author> p);
        Task Save();
    }
}