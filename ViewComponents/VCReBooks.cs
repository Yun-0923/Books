using Homework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Homework.ViewComponents
{
    public class VCReBooks: ViewComponent
    {
        private readonly dbGuestBookContext _context;
        public VCReBooks(dbGuestBookContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(long gid) 
        {
            var rebook =await _context.ReBook.Where(m => m.GId==gid).OrderByDescending(m => m.TimeStamp).ThenByDescending(m=>m.RId).ToListAsync();
            return View(rebook);
        }
    }
}
