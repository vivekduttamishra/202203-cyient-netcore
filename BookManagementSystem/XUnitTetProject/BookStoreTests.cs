using ConceptArchitect.BookManagement;
using ConceptArchitect.BookManagement.Repositories.FlatFileRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace XUnitTetProject
{
    public class BookStoreTests
    {
        BookStore store;
        string path = @"book-store-test.db";
        string authorId1 = "id1";
        string authorName1 = "name1";
        private string bookId1="book-1";
        private string bookTitle1="Book Title 1";

        public BookStoreTests()
        {
            //intialize the values here
            if (File.Exists(path))
                File.Delete(path); 

            //now every test will start from point 0
            //where file doesn't exist

            store = BookStore.Load(path);
        }

        [Fact]
        public void LoadCanLoadFromNonExistentRepostiory()
        {
            var store = BookStore.Load(path);            
            Assert.IsType<BookStore>(store);
        }

        [Fact]
        public void LoadedRepositoryRemembersItsPath()
        {
            Assert.Equal(path, store.Path);
        }

        [Fact]
        public void CanSaveEmptyRepository()
        {
            store.Save();
            //how do I know it is saved?

            Assert.True(File.Exists(path));
        }

        [Fact]
        public void CanLoadEmptyRepository()
        {
            Assert.Empty(store.Authors);
        }


        [Fact]
        public void CanSaveNonEmptyRepository()
        {
            SaveDummyData();
            Assert.True(File.Exists(path));
        }

        private void SaveDummyData()
        {
            store.Authors[authorId1] = new Author() { Id = authorId1, Name = authorName1 };
            store.Books[bookId1] = new Book() { Id = bookId1, Title = bookTitle1 };
            store.Save();
        }

        [Fact]
        public void CanLoadNonEmptyRepository()
        {
            SaveDummyData();
            var store2 = BookStore.Load(path);

            Assert.Single(store.Authors);
            Assert.Equal(authorName1, store.Authors[authorId1].Name);


        }

    }
}
