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
    public class RePostBooksController : Controller
    {
        private readonly dbGuestBookContext _context;

        public RePostBooksController(dbGuestBookContext context)
        {
            _context = context;
        }

        
        // GET: RePostBooks/Create
        public IActionResult Create(long GId)
        {
            ViewData["GId"] = GId;
            return View();
        }

        // POST: RePostBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReBook reBook)
        {
            reBook.TimeStamp = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(reBook);
                await _context.SaveChangesAsync();
                //return RedirectToAction("Details","PostBooks", new {id = reBook.GId});
                return Json(reBook);
            }
            ViewData["GId"] = new SelectList(_context.Book, "GId", "Author", reBook.GId);
            //return View(reBook);
            return Json(reBook);
        }

        public IActionResult GetReBooksByVC(long? id) 
        {
            return ViewComponent("VCReBooks", new {gid = id});
        }


       
        private bool ReBookExists(long id)
        {
            return _context.ReBook.Any(e => e.RId == id);
        }
    }
}
