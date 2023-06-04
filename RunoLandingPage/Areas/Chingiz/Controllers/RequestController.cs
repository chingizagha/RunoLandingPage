using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using RunoLandingPage.Models;
using RunoLandingPage.ViewModels;
using System.Data;

namespace RunoLandingPage.Areas.Chingiz.Controllers
{
    [Area("Chingiz")]
    [Authorize]
    public class RequestController : Controller
    {
        private readonly IGenericRepository<Request> _genericRepository;
        private readonly AppDbContext _appDbContext;

        public RequestController(IGenericRepository<Request> genericRepository, AppDbContext appDbContext)
        {
            _genericRepository = genericRepository;
            _appDbContext = appDbContext;
        }

        public IActionResult List()
        {
            var homeViewModel = new HomeViewModel()
            {
                Requests = _genericRepository.GetAll
            };

            return View(homeViewModel);
        }

        public IActionResult Detail(int id)
        {
            var item = _genericRepository.GetById(id);
            if (item == null)
                return RedirectToAction(nameof(List));
            return View(item);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            _genericRepository.Remove(id);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

    }
}
