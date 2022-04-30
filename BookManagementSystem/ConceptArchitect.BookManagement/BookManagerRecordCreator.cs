using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.BookManagement
{
    public class BookManagerRecordCreator
    {
        public  IBookService bookService { get; set; }
        public  IAuthorService authorService { get; set; }

        public BookManagerRecordCreator(IAuthorService authorService)
        {            
            this.authorService = authorService;
        }
 
        public async  void AddWellknownAuthors()
        {
            List<Author> authors = new List<Author>()
            {
                new Author(){ Name="Vivek Dutta Mishra", BirthDate=new DateTime(1977,07,09),  Biography="Best-selling author of Amazon #1 best seller, The Accursed God, the book of The Lost Epic series",Photo="https://avatars.githubusercontent.com/u/9464908?v=4"},
                new Author(){ Name="Alexandre Dumas", BirthDate=new DateTime(1802,07,24), DeathDate=new DateTime(1870,10,05), Biography="One of the all time greatest story teller",Photo="https://cdn.vocab.com/units/h3ekjthk/author.jpg?width=400&v=176fc5c134d"},
                new Author(){ Name="Jeffrey Archer", BirthDate=new DateTime(1940,04,15), DeathDate=null, Biography="Contemporary Author of largest number of best seller",Email="jarcher@booksweb.org",Photo="https://pbs.twimg.com/media/FIgReE4WUAEw9cL.jpg"},
                new Author(){ Name="Charles Dickens", BirthDate=new DateTime(1812,02,07), DeathDate=new DateTime(1870,06,09), Biography="One of most famous classic author",Photo= "https://cdn.vocab.com/units/4o42qceu/author.jpg?width=400&v=16c913c23d6"},
                new Author(){ Name="John Grisham", BirthDate=new DateTime(1955,2,8), DeathDate=null, Biography="Leading author of Legal Fiction",Email="john@grisham.net",Photo="https://bloximages.newyork1.vip.townnews.com/djournal.com/content/tncms/assets/v3/editorial/2/75/275514ff-8984-5d76-a624-debb6e3ce788/5ef6431eae7ee.image.jpg?crop=746%2C746%2C330%2C6&resize=400%2C400&order=crop%2Cresize"},
                new Author(){ Name="JK Rowlings", BirthDate=new DateTime(1965,7,31), DeathDate=null, Biography="Author of Best selling Harry Potter Series",Email="jkr@hogwards.net",Photo="https://m.timesofindia.com/thumb/msid-75024873/75024873.jpg?resizemode=4&width=400"},
                new Author(){ Name="Munshi Premchand", BirthDate=new DateTime(1880,7,31), DeathDate=new DateTime(1936,10,08), Biography="Known as magician with Pen",Photo="https://i2.wp.com/www.hakara.in/wp-content/uploads/2021/11/Premchand-sonakshi-s.jpeg?fit=400%2C400&ssl=1"},
                new Author(){ Name="Ramdhari Singh Dinkar", BirthDate=new DateTime(1908,9,23), DeathDate=new DateTime(1974,4,24), Biography="National Poet of India who wrote immemorable poetries on Indian freedom movement and ancient Indian epics", Photo="https://gumlet.assettype.com/Prabhatkhabar%2F2021-03%2F9f28febc-0bdf-4bc2-bb45-591f3f23f58c%2Framdhari_singh.jpg?rect=0%2C0%2C400%2C400&format=auto"},
                new Author(){ Name="Conan Doyle", BirthDate=new DateTime(1859,5,22), DeathDate=new DateTime(1930,7,7), Biography="Author of the greatest detective Sherlock Holmes",Photo="https://cdn.vocab.com/units/fsyoq26b/author.jpg?width=400&v=16d64ff4cf4"}
            };
            
            foreach (var author in authors)
            {
                author.Id = IdTool.Normalize(author.Name);
                await authorService.AddAuthor(author);
            }
            
        }

        public async void AddWellKnownBooks()
        {
            List<Book> books = new List<Book>()
            {
                 await  CreateBook("The Accursed God","Vivek Dutta Mishra","An Amazon #1 best seller based on Mahabharata. Book #1 of the The Lost Epic Series", "epic, fiction, mahabahratahistory, action",399,4.5,"https://m.media-amazon.com/images/I/41-KqB1-cqL.jpg"),
                 await  CreateBook("The Count of Monte Cristo","Alexandre Dumas","One of the all time greatest classic", "history,fiction,adventure,love,revenge",300,4.7,"https://images-na.ssl-images-amazon.com/images/I/81vrDQmPMKL.jpg"),
                 await  CreateBook("Sons of Fortune","Jeffrey Archer","Story of two brothers separated at Birth", "chronology,politics",230,4.2,"https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1347962096l/78985.jpg"),
                 await  CreateBook("A Study In Scarlet","Conan Doyle","First Novel of Sherlock Holmes", "Sherlock Holmes,crime,detectie",125,4.1,"https://images-na.ssl-images-amazon.com/images/I/51BFkrfSuwL._SX319_BO1,204,203,200_.jpg"),
                 await  CreateBook("Kane and Able","Jeffrey Archer","Signature book of Jeffrey Archer", "chronology,best seller",325,4.4,"https://images-na.ssl-images-amazon.com/images/I/514+znG-5DL._SX279_BO1,204,203,200_.jpg"),
                 await  CreateBook("The Appeal","John Grisham","Father summons sons and dies before they arrive", "suspense,thriller",275,3.8,"https://images-na.ssl-images-amazon.com/images/I/81DtO57B5-L.jpg"),
                 await  CreateBook("Rashmirathi","Ramdhari Singh Dinkar","Poetic tale of Karna of Mahabharata. A seven chapter tale of Karna", "mahabharata, poetry",125,4.2,"https://rukminim1.flixcart.com/image/832/832/k6nxrbk0/book/6/2/2/rashmi-rathi-original-imafp2p8fs8nggca.jpeg?q=70"),
                 await  CreateBook("Only Time Will Tell","Jeffrey Archer","First of the 5 part clifton chronicle", "chronical,best seller",190,3.9,"https://images-na.ssl-images-amazon.com/images/I/51d7ZcojuWL._SX322_BO1,204,203,200_.jpg"),
                 await  CreateBook("Return of Sherlock Holmes","Conan Doyle","Collection of Sherlock Holmes short stories", "sherlock holmes, detective,crime",300,4.2,"https://kbimages1-a.akamaihd.net/02ca66da-145f-410d-8559-9294ad5b6a11/353/569/90/False/the-return-of-sherlock-holmes-153.jpg"),
                 await  CreateBook("Harry Potter and Deathly Hollows","JK Rowlings","The final book of Harry Potter Series as Harry Potter finally faces He who should not be named.", "harry potter,wizard,best seller",300,4.3,"https://m.media-amazon.com/images/I/511DhzIj4cL.jpg"),
                 await  CreateBook("Harry Potter and Philospher's stone","JK Rowlings","The first book of Harry Potter Series as we dive into the magical world of harry potter", "harry potter,wizard,best seller",300,4.3,"https://m.media-amazon.com/images/M/MV5BNjQ3NWNlNmQtMTE5ZS00MDdmLTlkZjUtZTBlM2UxMGFiMTU3XkEyXkFqcGdeQXVyNjUwNzk3NDc@._V1_FMjpg_UX1000_.jpg")
            };
            
            foreach (var book in books)
            {
                await bookService.AddBook(book);
            }
            
        }

        public async Task<Book> CreateBook(string title, string author, string description, string tags, int price,double rating=4,string cover=null)
        {
            var book = new Book()
            {
                Id = IdTool.Normalize(title),
                Title = title,
                Description = description,
                Tags = tags,
                Price = price,
                Cover=cover

            };
            //Author a = BookManager.GetAuthorByName(author);
            //Author a = AuthorManager.SearchAuthors(author).FirstOrDefault();
            Author a = await authorService.GetAuthorById(IdTool.Normalize(author));
            if (a == null)
            {
                throw new Exception(author + " not found");
            }
            book.Author = a;

            return book;
        }

        public  void AddRandomAuthor(int count)
        {
            string[] fNames = { "Ketan", "Suresh", "Chetan", "Monish" ,"Ramdhari","John","Yenn","Amol","Ved","Bimal","Shiva","Vishnu","Alvin","Vinita","Kavita","Yana", "Shivani", "Smita" };
            string[] mNames = { "", "", "Narayan", "Kumar", "", "Soni", "kant", "dutta", "", "", "", "shiv", "", "", "" };
            string[] lNames = { "Mehta", "Panth", "Bhagat", "Sahni", "Thakur" ,"Mishra","Pathak","Palak","Chowdhary","Thomas","Pillai","Tripathi","Singh",
                              "Aryan","Gomes","Kher","Kumar"};
            string[] prefix = { "welknown", "one of the best", "aclaimed", "popular", "controversial","best seller" };
            string[] suffix ={"classic","suspense","thriller","detective","fiction","non-fiction",
                                    "history","legal","medical","motivation","finance","fantasy" };
            int j = 0;
            DateTime now = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                var fName = I(fNames);
                var gender = "men";
                if (IndexOf(fNames, fName) > 12)
                    gender = "women";



                string name = string.Format("{0} {2} {1}", fName, I(lNames),I(mNames));

                

                //if (AuthorManager.SearchAuthors(name).FirstOrDefault() != null)
                //if(AuthorManager.GetAuthorByName(name)!=null)
                if(authorService.GetAuthorById(IdTool.Normalize(name))!=null)
                {
                    i--;    //try again
                    j++;    // retry count
                    if (j == 5) // after 5 retry skip
                    {
                        i++;
                        j = 0;
                    }
                    continue;
                }

                string biography = string.Format("{0} author of {1}", I(prefix), I(suffix));
                int baseYear = r.Next(1, 100) < 30 ? 1800 : 1920;

                int yy=r.Next(baseYear, 1990);
                int mm=r.Next(1,13);
                int dd=r.Next(1,29);
                DateTime dob = new DateTime(yy,mm,dd);

                DateTime? dod = null;

                

                int ageOnDate =(DateTime.Now-dob).Days/365 ;
                bool isAlive=false;

                if (ageOnDate < 90)
                {
                    //int chance = 130 - ageOnDate;
                    isAlive = r.Next(100) <= 60;

                }
                
                if(!isAlive)
                {
                    if(ageOnDate>100)
                        ageOnDate=100;

                    int min = 30;
                    if (ageOnDate < 30)
                        min = 10;

                    dod = dob.AddYears(r.Next(min, ageOnDate));
                }


                Author author = new Author()
                {
                    Name = name,
                    Biography = biography,
                    BirthDate = dob,
                    DeathDate = dod
                    //Picture = name.Replace(" ", "_") + ".jpg"
                  //  , Photograph = string.Format("https://randomuser.me/api/portraits/{0}/{1}.jpg", gender, r.Next(100))
                };

                if (author.DeathDate==null && r.Next(100)>10)
                {
                    author.Email = RandomEmail(author.Name.Split(' '));
                }

                authorService.AddAuthor(author);
                

                

            }

           // AuthorManager.Save();



        }

        private int IndexOf(string[] fNames, string fName)
        {
            for (int i = 0; i < fNames.Length; i++)
                if (fNames[i] == fName)
                    return i;

            return -1;
        }

        //public  void AddRandomBook(int count)
        //{
        //    IBookService bm = bookService;      //CatalogManager.Single<IBookManager>();
        //    //var authors = AuthorManager.ListAllAuthors().ToArray();
        //    //var authors = AuthorManager.ListAllAuthors().ToArray();
        //    var authors = authorService.GetAllAuthors().ToArray();
        //    Random random = new Random();

        //    string[] part1 = { "The", "A", "One", "Let", "Seven", "Around", "Night", "Dark", "the", "a", "the", "a", "one", "the", "a" };
        //    string[] part2 = { "Mystry", "Dark", "Night", "Sun", "Case", "Story", "Love", "Horror" };
        //    string[] part3 = { "of", "within", "", "cloud", "in", "at", "in", "at", "of", "a", "of", "at", "in" };
        //    string[] part4 = { "cloud", "style", "agent", "hotel", "india", "phantom", "story", "series", "system" };

        //    string[] fNames = { "Ketan", "Suresh", "Chetan", "Monish", "Smita" };
        //    string[] lNames = { "Mehta", "Panth", "Bhagat", "Sahni", "Thakur" };

        //    string[] tags = { "suspense", "crime", "love", "history", "action", "detective", "nonfiction", "chronology", "classic","legal","medical" };

        //    string[] descriptions = { "just superb", "must read", "spell bound", "time pass", "horrible", "read if you have nothing to do" };
        //    for (int i = 0; i < count; i++)
        //    {
        //        string title = string.Format("{0} {1} {2} {3}", I(part1), I(part2), I(part3), I(part4));
                
                

        //        Book b = new Book()
        //        {
        //            Title = title,
        //            Author = I(authors),
        //            Price = random.Next(20, 600),
        //            Tags = string.Format("{0},{1},{2}", I(tags), I(tags), I(tags)),
        //            Description = I(descriptions)
        //        };


        //        bm.AddBook(b);


        //    }

        //    bm.Save();
        //}

        Random r = new Random();

        T I<T>(T[] value)
        {

            //if (r.Next(1, 100) > 60)
            //    return default(T);
            //else
            return value[r.Next(value.Length)];

        }

        string RandomEmail(params string[] nameParts)
        {
            string[] domains = { "hotmail.com", "yahoo.com", "gmail.com", "yahoo.co.in", "conceptarchitect.in", "indiatimes.com", "rediff.com" };
            return Email(I(domains), nameParts);
        }


        string Email(string domain, params string [] nameParts)
        {
            string n = "";
            foreach (var name in nameParts)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (!string.IsNullOrEmpty(n))
                        n += ".";
                    n +=  name;
                }
            }

            return n + "@" + domain;
        }

        public  void BuildNewDB()
        {
            AddWellknownAuthors();
            AddWellKnownBooks();
            //AddRandomAuthor(20);
            //AddRandomBook(50);
        }

        public  void RefillDB()
        {
            AddRandomAuthor(20);
            //AddRandomBook(50);
            // AddRandomUsers(20);
           // AddRandomReviews(20);

        }

        


    }
}
