using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.EFRepository
{
    public class EFAuthorRepository : IAuthorRepository
    {
        BMSContext context;

        public EFAuthorRepository(BMSContext context)
        {
            this.context = context;
        }


        public async Task AddAuthor(Author author)
        {
            context.Authors.Add(author);
            await Task.CompletedTask;
        }

        public async Task<IList<Author>> GetAll()
        {
            await Task.Yield();
            return context.Authors.ToList();
        }

        public Task<IList<Author>> GetAll(Func<Author, bool> p)
        {
            throw new NotImplementedException();
        }

        public async Task<Author> GetById(string id)
        {
            await Task.Yield();
            return context.Authors.Where(a => a.Id == id).FirstOrDefault();
        }

        public async Task Remove(string id)
        {
            var author = await GetById(id);
            context.Authors.Remove(author);
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public Task Update(Author author, Action<Author, Author> p)
        {
            throw new NotImplementedException();
        }
    }
}
