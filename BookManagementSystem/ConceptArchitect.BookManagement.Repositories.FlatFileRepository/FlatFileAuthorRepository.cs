using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement.Repositories.FlatFileRepository
{
    public class FlatFileAuthorRepository : IAuthorRepository
    {
        BookStore store;
        public FlatFileAuthorRepository(BookStore store)
        {
            this.store = store;
        }
        public async Task AddAuthor(Author author)
        {
            await Task.Yield();

            store.Authors[author.Id] = author;
        }

        public async Task<IList<Author>> GetAll()
        {
            await Task.Yield();
            return store.Authors.Values.ToList();
        }

        public async Task<IList<Author>> GetAll(Func<Author, bool> p)
        {
            await Task.Yield();
            return store.Authors.Values.Where(p).ToList();
        }

        public async Task<Author> GetById(string id)
        {
            await Task.Yield();
            if (store.Authors.ContainsKey(id))
                return store.Authors[id];
            else
                return null;
        }

        public async Task Remove(string id)
        {
            await Task.Yield();
            if (store.Authors.ContainsKey(id))
                store.Authors.Remove(id);
        }

        public async Task Save()
        {
            await Task.Yield();
            
            store.Save();
        }

        public async Task Update(Author author, Action<Author, Author> update)
        {
            var existing = await GetById(author.Id);
            if (existing != null)
            {
                update(existing, author);
            }
        }
    }
}
