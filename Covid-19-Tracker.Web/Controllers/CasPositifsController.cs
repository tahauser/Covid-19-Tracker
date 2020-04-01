using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Covid_19_Tracker.Entites;
using Covid_19_Tracker.Persistence;

namespace Covid_19_Tracker.Web.Controllers
{
    public class CasPositifsController : Controller
    {
        private readonly AppDbContext _context;

        public CasPositifsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CasPositifs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CasPositifs.ToListAsync());
        }

        // GET: CasPositifs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casPositif = await _context.CasPositifs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casPositif == null)
            {
                return NotFound();
            }

            return View(casPositif);
        }

        // GET: CasPositifs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasPositifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,Date_Declaration,Date_Dernier_Contact,Nombre_Contacts,Id,Nom,Prenom,CIN,Sexe,NumeroTel")] CasPositif casPositif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casPositif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casPositif);
        }

        // GET: CasPositifs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casPositif = await _context.CasPositifs.FindAsync(id);
            if (casPositif == null)
            {
                return NotFound();
            }
            return View(casPositif);
        }

        // POST: CasPositifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Type,Date_Declaration,Date_Dernier_Contact,Nombre_Contacts,Id,Nom,Prenom,CIN,Sexe,NumeroTel")] CasPositif casPositif)
        {
            if (id != casPositif.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casPositif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasPositifExists(casPositif.Id))
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
            return View(casPositif);
        }

        // GET: CasPositifs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casPositif = await _context.CasPositifs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casPositif == null)
            {
                return NotFound();
            }

            return View(casPositif);
        }

        // POST: CasPositifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casPositif = await _context.CasPositifs.FindAsync(id);
            _context.CasPositifs.Remove(casPositif);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasPositifExists(int id)
        {
            return _context.CasPositifs.Any(e => e.Id == id);
        }
    }
}
