using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Covid_19_Tracker.Entites;
using Covid_19_Tracker.Persistence;

namespace Covid_19_Tracker.Web.Controllers
{
    public class CasSuivisController : Controller
    {
        private readonly AppDbContext _context;

        public CasSuivisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CasSuivis
        public async Task<IActionResult> Index()
        {
            return View(await _context.CasSuivis.ToListAsync());
        }

        // GET: CasSuivis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casSuivi = await _context.CasSuivis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casSuivi == null)
            {
                return NotFound();
            }

            return View(casSuivi);
        }

        // GET: CasSuivis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasSuivis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lien,DateDernierCreation,NiveauRisque,DateFin,NombreJours,Actif,Id,Nom,Prenom,CIN,Sexe,NumeroTel")] CasSuivi casSuivi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casSuivi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casSuivi);
        }

        // GET: CasSuivis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casSuivi = await _context.CasSuivis.FindAsync(id);
            if (casSuivi == null)
            {
                return NotFound();
            }
            return View(casSuivi);
        }

        // POST: CasSuivis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lien,DateDernierCreation,NiveauRisque,DateFin,NombreJours,Actif,Id,Nom,Prenom,CIN,Sexe,NumeroTel")] CasSuivi casSuivi)
        {
            if (id != casSuivi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casSuivi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasSuiviExists(casSuivi.Id))
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
            return View(casSuivi);
        }

        // GET: CasSuivis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casSuivi = await _context.CasSuivis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casSuivi == null)
            {
                return NotFound();
            }

            return View(casSuivi);
        }

        // POST: CasSuivis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casSuivi = await _context.CasSuivis.FindAsync(id);
            _context.CasSuivis.Remove(casSuivi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasSuiviExists(int id)
        {
            return _context.CasSuivis.Any(e => e.Id == id);
        }
    }
}
