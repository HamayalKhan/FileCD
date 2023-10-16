using FileCD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FileCD.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment root;

        public HomeController(MyDbContext context, IWebHostEnvironment _root)
        {
            this._context = context;
            this.root = _root;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            if(ModelState.IsValid) { 
            var folder = Path.Combine(root.WebRootPath, "Pictures");
            Directory.CreateDirectory(folder);

            var filepath = Path.Combine(folder,file.FileName);

            using (var stream = new FileStream(filepath,FileMode.Create)) {
                file.CopyTo(stream);
                var pictures = new FileItems
                {
                    FileName = file.FileName
                };
                _context.fileItems.Add(pictures);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
            }
            return View();
        }
    }
}
