using BooksWeb.Utils;
using BooksWeb.ViewModels;
using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWeb.Controllers
{
    [ApiController]
    [Route("/api/authors")]
    //[InvalidEntityIs404]
    public class AuthorsController : Controller
    {


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            
            var author = await service.GetAuthorById(id);
            return Ok(author);

        }



       
        public async Task<IActionResult> GetById0(string id)
        {
            try
            {
                var author = await service.GetAuthorById(id);
                return Ok(author);
            }
            catch (InvalidEntityException ex)
            {
                return NotFound(new { Message = ex.Message, Id = ex.Id });
            }

        }

        [HttpDelete("{id}")]
       // [InvalidEntityIs404]
        public async Task<IActionResult> DeleteAuthor(string id)
        {
            await service.Remove(id);
            return NoContent(); //right use of 204
        }

        [HttpPut("{id}")]
      //  [InvalidEntityIs404]
        public async Task<IActionResult> UpdateAuthor(string id, Author author)
        {
            await service.Update(author);
            return Accepted(author);
        }

        [HttpGet("{id}/photo")]
    //    [InvalidEntityIs404]
        public async Task<IActionResult> GetAuthorPhoto(string id)
        {
            var author = await service.GetAuthorById(id);

            return Ok(author.Photo);

        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetBooksByAuthor(string id)
        {
            var author = await service.GetAuthorById(id);
            if (author == null)
                return NotFound();
            else
                return Ok(author.Books);
        }




        IAuthorService service;
        BookManagerRecordCreator creator;
        public AuthorsController(IAuthorService service,BookManagerRecordCreator creator)
        {
            this.service = service;
            this.creator = creator;
        }

        [HttpGet]
        public async Task<IList<Author>> GetAllAuthors()
        {
            Console.WriteLine($"{Request.Method} {Request.Path} called GetAllAuthors");
            var authors = await service.GetAllAuthors();
            return authors;
        }

        [HttpPost]

        public async Task<IActionResult> AddAuthor(NewAuthor author)
        {

            var a = new Author()
            {
                Id=author.Id,
                Name=author.Name,
                Biography=author.Biography,
                Photo=author.Photo,
                BirthDate=author.BirthDate,
                DeathDate=author.DeathDate,
                Email=author.Email
            };
            await service.AddAuthor(a);

            var url = Url.Action(nameof(GetById), new { id = author.Id });

            return Created(url, a);
            
        }

        [HttpPost("seed")]
        public  IActionResult SeedAuthors()
        {
            creator.AddWellknownAuthors();
            return Ok(service.GetAllAuthors());
        }

    }
}
