using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksWeb.Controllers
{
    public class AuthorController : Controller
    {
        IAuthorService service;
        public AuthorController(IAuthorService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await service.GetAllAuthors();
            return View(authors);
        }

        public async Task<IList<Author>> List()
        {
            return await service.GetAllAuthors();
        }


        public async Task<IActionResult> Details(string id)
        {
            var author = await service.GetAuthorById(id);
            return View(author);
        }

        [HttpGet]
        public  IActionResult Create()
        {
            return View(new Author());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            var existing = await service.GetAuthorById(author.Id);
            if (existing != null)
                ModelState.AddModelError("Id", "Duplicate Id");

            if(ModelState.IsValid)
            {
                await service.AddAuthor(author);
                return RedirectToAction("Details", new { Id = author.Id });
            }
            else
            {
                return View(); //return back to the form for necessary correction
            }            
        }



        public async Task<IActionResult> Delete(string id)
        {
            await Task.Yield();
            return Content($"Author with id {id} deleted");

        }

        public async Task<IActionResult> Edit(string id)
        {
            await Task.Yield();
            return Content($"Author with id {id} edited");

        }
    }
}


