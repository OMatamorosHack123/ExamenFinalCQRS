using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class ExtrasController : Controller
    {
        private readonly TuHotelEnLineaContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public ExtrasController(TuHotelEnLineaContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: Extras
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.ExtraRepository.GetAllAsync());
        }

        // GET: Extras/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Extra == null)
            {
                return NotFound();
            }

            var extra = await _unitOfWork.ExtraRepository.GetByIdAsync(id);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }

        // GET: Extras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Extras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExtraId,ExtraName,ExtraDescription")] Extra extra)
        {

            _unitOfWork.ExtraRepository.Add(extra);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }

        // GET: Extras/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Extra == null)
            {
                return NotFound();
            }

            var extra = await _unitOfWork.ExtraRepository.GetByIdAsync(id);
            if (extra == null)
            {
                return NotFound();
            }
            return View(extra);
        }

        // POST: Extras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExtraId,ExtraName,ExtraDescription")] Extra extra)
        {
            if (id != extra.ExtraId)
            {
                return NotFound();
            }


            try
            {
                _unitOfWork.ExtraRepository.Update(extra);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraExists(extra.ExtraId))
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

        // GET: Extras/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Extra == null)
            {
                return NotFound();
            }

            var extra = await _unitOfWork.ExtraRepository.GetByIdAsync(id);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }

        // POST: Extras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Extra == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.Extra'  is null.");
            }

            _unitOfWork.ExtraRepository.Delete(id);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtraExists(int id)
        {
            return _unitOfWork.ExtraRepository.GetByIdAsync(id) != null;
        }
    }
}
