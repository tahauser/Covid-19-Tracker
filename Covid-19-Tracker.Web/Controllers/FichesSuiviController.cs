using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Covid_19_Tracker.Entites;
using Covid_19_Tracker.Persistence;

namespace Covid_19_Tracker.Web.Controllers
{
    public class FichesSuiviController : Controller
    {
        private readonly AppDbContext _context;

        public FichesSuiviController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FicheSuivis
        public async Task<IActionResult> Index()
        {
            return View(await _context.FichesSuivi.ToListAsync());
        }

        // GET: FicheSuivis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ficheSuivi = await _context.FichesSuivi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ficheSuivi == null)
            {
                return NotFound();
            }

            return View(ficheSuivi);
        }

        // GET: FicheSuivis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FicheSuivis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Temp_M,Temp_S,Toux_M,Toux_S")] FicheSuivi ficheSuivi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ficheSuivi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ficheSuivi);
        }

        // GET: FicheSuivis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ficheSuivi = await _context.FichesSuivi.FindAsync(id);
            if (ficheSuivi == null)
            {
                return NotFound();
            }
            return View(ficheSuivi);
        }

        // POST: FicheSuivis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Temp_M,Temp_S,Toux_M,Toux_S")] FicheSuivi ficheSuivi)
        {
            if (id != ficheSuivi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ficheSuivi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FicheSuiviExists(ficheSuivi.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ficheSuivi);
        }

        // GET: FicheSuivis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ficheSuivi = await _context.FichesSuivi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ficheSuivi == null)
            {
                return NotFound();
            }

            return View(ficheSuivi);
        }

        // POST: FicheSuivis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ficheSuivi = await _context.FichesSuivi.FindAsync(id);
            _context.FichesSuivi.Remove(ficheSuivi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FicheSuiviExists(int id)
        {
            return _context.FichesSuivi.Any(e => e.Id == id);
        }
    }
}
