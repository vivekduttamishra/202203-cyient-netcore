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
    [Route("/api/v1/authors")]
    public class AuthorsControllerV1 : Controller
    {

      



        IAuthorService service;
        public AuthorsControllerV1(IAuthorService service)
        {
            this.service = service;
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var author = await service.GetAuthorById(id);
            if (author != null)
                return Ok(author);  //status 200
            else
                return NotFound(new { Message = "No Such Author", Id = id }); //status 404
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(string id)
        {
            await service.Remove(id);
            return NoContent(); //right use of 204
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(string id, Author author)
        {
            await service.Update(author);
            return Accepted(author);
        }

        [HttpGet("{id}/photo")]
        public async Task<IActionResult> GetAuthorPhoto(string id)
        {
            var author = await service.GetAuthorById(id);
            if (author != null)
                return Ok(author.Photo);
            else
                return NotFound(new { Message = "No Such Author", Id = id });

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


    }
}
