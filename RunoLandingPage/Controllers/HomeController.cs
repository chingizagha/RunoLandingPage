using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunoLandingPage.Models;
using System.Data;
using System.Diagnostics;

namespace RunoLandingPage.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGenericRepository<Request> _genericRepository;
        private readonly AppDbContext _appDbContext;


        public HomeController(ILogger <HomeController> logger, IGenericRepository<Request> genericRepository, AppDbContext appDbContext)
        {
            _logger = logger;
            _genericRepository = genericRepository;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add([Bind(include: "Name, Surname, Company, Email")] Request request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _genericRepository.Add(request);
                    await _appDbContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError($"{ex}", "Unable to save changes. Try again, and if the problem persists see your system administrator."); ;
            }
            return View(request);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}