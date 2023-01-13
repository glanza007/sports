using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccer.Data;
using Soccer.Data.Entities;
using Soccer.Helpers;
using Soccer.Models;

namespace Soccer.Controllers
{
    public class TeamsController : Controller
    {
        private readonly DataContext _context;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;


        public TeamsController(DataContext context, IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _context = context;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teams.
                OrderBy(t => t.Name).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            return View(team);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.LogoFile, "Teams");
                }

                var team = _converterHelper.ToTeam(model, path, true);
                _context.Add(team);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un equipo con este nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }

            return View(model);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team team = await _context.Teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            TeamViewModel model = _converterHelper.ToTeamViewModel(team);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TeamViewModel model)
        {

            if (ModelState.IsValid)
            {
                var path = model.ImageUrl;

                if (model.LogoFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.LogoFile, "Teams");
                }

                Team team = _converterHelper.ToTeam(model, path, false);
                _context.Update(team);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un equipo con este nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var team = await _context.Teams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (team == null)
            {
                return NotFound();
            }

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
