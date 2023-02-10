using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class PackagesController : Controller
    {
        private readonly TuHotelEnLineaContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public PackagesController(TuHotelEnLineaContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: Packages
        public async Task<IActionResult> Index()
        {
            
            return View(await _unitOfWork.PackageRepository.GetAllAsync());
        }

        // GET: Packages/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Package == null)
            {
                return NotFound();
            }

            var package = await _unitOfWork.PackageRepository.GetByIdAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // GET: Packages/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId");
            return View();
        }

        // POST: Packages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackageId,RoomId,PackageName,PackagePrice,PackageQdays")] Package package)
        {

            _unitOfWork.PackageRepository.Add(package);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }

        // GET: Packages/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Package == null)
            {
                return NotFound();
            }

            var package = await _unitOfWork.PackageRepository.GetByIdAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", package.RoomId);
            return View(package);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackageId,RoomId,PackageName,PackagePrice,PackageQdays")] Package package)
        {
            if (id != package.PackageId)
            {
                return NotFound();
            }

            try
            {
                _unitOfWork.PackageRepository.Update(package);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(package.PackageId))
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

        // GET: Packages/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Package == null)
            {
                return NotFound();
            }

            var package = await _unitOfWork.PackageRepository.GetByIdAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Package == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.Package'  is null.");
            }
            _unitOfWork.PackageRepository.Delete(id);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageExists(int id)
        {
            return _unitOfWork.PackageRepository.GetByIdAsync(id)!=null;
        }
    }
}
