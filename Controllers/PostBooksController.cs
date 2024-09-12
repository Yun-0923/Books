using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Homework.Models;

namespace Homework.Controllers
{
    public class PostBooksController : Controller
    {
        private readonly dbGuestBookContext _context;

        public PostBooksController(dbGuestBookContext context)
        {
            _context = context;
        }

        // GET: PostBooks
        public async Task<IActionResult> Index()
        {
            var result = _context.Book.OrderByDescending(b => b.TimeStamp).ThenByDescending(b => b.GId);
            return View(await result.ToListAsync());
        }

        // GET: PostBooks/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.GId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: PostBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book, IFormFile? uploadPhoto)
        {
            if (uploadPhoto != null) 
            {
                if (uploadPhoto.ContentType != "image/jpeg" && uploadPhoto.ContentType != "image/png") 
                {
                    ViewData["ErrorMessage"] = "請上傳jpg或png格式的檔案";
                    return View(book);
                }

                var mem = new MemoryStream();
                uploadPhoto.CopyTo(mem);

                book.Photo = mem.ToArray();
                book.ImageType = uploadPhoto.ContentType;
            }

            book.TimeStamp = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
               

        private bool BookExists(long id)
        {
            return _context.Book.Any(e => e.GId == id);
        }
    }
}
