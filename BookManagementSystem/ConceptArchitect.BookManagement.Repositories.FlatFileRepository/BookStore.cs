using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConceptArchitect.BookManagement.Repositories.FlatFileRepository
{
    
    [Serializable]
    public class BookStore
    {
        public Dictionary<string, Author> Authors { get; set; } = new Dictionary<string, Author>();
        public Dictionary<string, Book> Books { get; set; } = new Dictionary<string, Book>();
        public string Path { get; set; }

        public void Save()
        {
            using(var stream= new StreamWriter(Path))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream.BaseStream, this);
            }
        }

        public static BookStore Load(string path)
        {
            BookStore store = null;
            try
            {
                using(var stream=new StreamReader(path))
                {
                    var serializer = new BinaryFormatter();
                    store = (BookStore)serializer.Deserialize(stream.BaseStream);
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                store = new BookStore(); //if store doesn't exist till now. create it
            }

            store.Path = path;
            return store;
        }


    }
}
