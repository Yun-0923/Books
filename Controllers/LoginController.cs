using Homework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Homework.Controllers
{
    public class LoginController : Controller
    {
        private readonly dbGuestBookContext _context;

        public LoginController(dbGuestBookContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (login == null)
            {
                return View();
            }
            //如果帳密正確，導置後台留言板頁面
            //否則回到首頁，並告知帳密錯誤

            var result = await _context.Login.Where(m => m.Account==login.Account && m.Password==login.Password).FirstOrDefaultAsync();

            if (result==null)
            {
                ViewData["Error"] = "帳號或密碼輸入錯誤";
                return View();
            }
            else 
            {
                HttpContext.Session.SetString("Manager", JsonConvert.SerializeObject(login));
                return RedirectToAction("Index", "Books");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Manager");
            return RedirectToAction("Index", "Home");
        }

    }
}
