using BlogProject.Data;
using BlogProject.Models;
using BlogProject.Services;
using BlogProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace BlogProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlogEmailSender _emailSender;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IBlogEmailSender emailSender, ApplicationDbContext context)
        {
            _logger = logger;
            _emailSender = emailSender;
            _context = context;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 5;
            var blogs = _context.Blogs
                      .Include(b => b.BlogUser)
                     .OrderByDescending(b => b.Created)
                     .ToPagedListAsync(pageNumber, pageSize);

          
            return View(await blogs);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            var customError = new CustomError();

            customError.code = code;

            if (code == 404)
            {
                customError.message = "The page you are looking for might have been removed had its name changed or is temporarily unavailable. If the issue persists please contact the developer.";
            }
            else if (code == 500)
            {
                customError.message = "Internal Service Error";
            }
            else
            {
                customError.message = "Something Went Wrong";
            }

            return View("~/Views/Shared/CustomError.cshtml", customError);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactMe model)
        {
            // Location Is Where We Will Be Emailing
            //model.Message = $"{model.Message} <hr/> Phone: {model.PhoneNumber}";
            //await _emailSender.SendContactEmailAsync(model.Email, model.Name, model.Subject, model.Message);
            try
            {
                model.Message = $"{model.Message} <hr/> Phone: {model.PhoneNumber}";
                await _emailSender.SendContactEmailAsync(model.Email, model.Name, model.Subject, model.Message);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
                throw;
            }
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
