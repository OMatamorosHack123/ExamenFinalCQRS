using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class PackageExtrasController : Controller
    {
        private readonly TuHotelEnLineaContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public PackageExtrasController(TuHotelEnLineaContext context, IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork; 
            _context = context;
        }

        // GET: PackageExtras
        public async Task<IActionResult> Index()
        {

            return View(await _unitOfWork.PackageExtraRepository.GetAllAsync());
        }

        // GET: PackageExtras/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.PackageExtra == null)
            {
                return NotFound();
            }

            var packageExtra = await _unitOfWork.PackageExtraRepository.GetByIdAsync(id);
            if (packageExtra == null)
            {
                return NotFound();
            }

            return View(packageExtra);
        }

        // GET: PackageExtras/Create
        public IActionResult Create()
        {
            ViewData["ExtraId"] = new SelectList(_context.Extra, "ExtraId", "ExtraDescription");
            ViewData["PackageId"] = new SelectList(_context.Package, "PackageId", "PackageName");
            return View();
        }

        // POST: PackageExtras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackageExtraId,PackageId,ExtraId")] PackageExtra packageExtra)
        {

            _unitOfWork.PackageExtraRepository.Add(packageExtra);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));


        }

        // GET: PackageExtras/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.PackageExtra == null)
            {
                return NotFound();
            }

            var packageExtra = await _unitOfWork.PackageExtraRepository.GetByIdAsync(id);
            if (packageExtra == null)
            {
                return NotFound();
            }
            ViewData["ExtraId"] = new SelectList(_context.Extra, "ExtraId", "ExtraDescription", packageExtra.ExtraId);
            ViewData["PackageId"] = new SelectList(_context.Package, "PackageId", "PackageName", packageExtra.PackageId);
            return View(packageExtra);
        }

        // POST: PackageExtras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackageExtraId,PackageId,ExtraId")] PackageExtra packageExtra)
        {
            if (id != packageExtra.PackageExtraId)
            {
                return NotFound();
            }


            try
            {
                _unitOfWork.PackageExtraRepository.Update(packageExtra);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExtraExists(packageExtra.PackageExtraId))
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

        // GET: PackageExtras/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.PackageExtra == null)
            {
                return NotFound();
            }

            var packageExtra = await _unitOfWork.PackageExtraRepository.GetByIdAsync(id);
            if (packageExtra == null)
            {
                return NotFound();
            }

            return View(packageExtra);
        }

        // POST: PackageExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PackageExtra == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.PackageExtra'  is null.");
            }
            _unitOfWork.PackageExtraRepository.Delete(id);

            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageExtraExists(int id)
        {
            return _unitOfWork.PackageExtraRepository.GetByIdAsync(id) != null;
        }
    }
}
