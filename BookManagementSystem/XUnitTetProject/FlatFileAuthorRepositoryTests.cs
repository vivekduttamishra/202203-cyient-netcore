using ConceptArchitect.BookManagement;
using ConceptArchitect.BookManagement.Repositories.FlatFileRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace XUnitTetProject
{
    public class FlatFileAuthorRepositoryTests
    {
        string path = "book-store-test.db";
        Author author1 = new Author() { Id = "id1", Name = "Name1" };
        Author author2 = new Author() { Id = "id2", Name = "Name2" };
        FlatFileAuthorRepository repository;
        int initialSize;
        private string newId="newId";
        private string newName="newName";
        BookStore store;

        public FlatFileAuthorRepositoryTests()
        {
            if (File.Exists(path))
                File.Delete(path);

            store = BookStore.Load(path);
            store.Authors[author1.Id] = author1;
            store.Authors[author2.Id] = author2;
            initialSize = store.Authors.Count;
            repository = new FlatFileAuthorRepository(store);
        }

        [Fact]
        public async void AddAuthorCanAddNewAuthorWithUniqueId()
        {
            await repository.AddAuthor(new Author() { Id = newId, Name = newName });

            Assert.Equal(initialSize + 1, store.Authors.Count);
        }

        [Fact]
        public async void GetAllAuthorsReturnsAllAuthors()
        {
            var authors = await repository.GetAll();

            Assert.Equal(initialSize, authors.Count);
        }

        [Fact]
        public async void GetAuthorByIdReturnsValidAuthorWithValidId()
        {
            var author = await repository.GetById(author1.Id);

            Assert.Equal(author1.Name, author.Name);
        }

        [Fact]
        public async void GetAuthorByIdReturnsNullForInvalidId()
        {
            var author = await repository.GetById("invalid-id");
            Assert.Null(author);
        }

        [Fact]
        public async void RemoveRemovesAuthorWithValidId()
        {
            await repository.Remove(author1.Id);

            //assert
            Assert.Equal(initialSize - 1, store.Authors.Count);

            Assert.Null(await repository.GetById(author1.Id));

        }

        [Fact]
        public async void CanSaveNonEmptyRepository()
        {
            await repository.Save();

            Assert.True(File.Exists(path));


        }

        [Fact]
        public async void CanLoadNonEmptyRepository()
        {
            await repository.Save(); //repository saved

            var store2 = BookStore.Load(path);

            Assert.Equal(initialSize, store.Authors.Count);

        }

    }
}
