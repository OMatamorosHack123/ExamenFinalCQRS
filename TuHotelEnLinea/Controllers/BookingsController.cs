using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class BookingsController : Controller
    {
        private readonly TuHotelEnLineaContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public BookingsController(TuHotelEnLineaContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
          
            return View(await _unitOfWork.BookingRepository.GetAllAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _unitOfWork.BookingRepository.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerIdCard");
            ViewData["PackageId"] = new SelectList(_context.Package, "PackageId", "PackageName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,CustomerId,PackageId,BookingDate")] Booking booking)
        {

            _unitOfWork.BookingRepository.Add(booking);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _unitOfWork.BookingRepository.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerIdCard", booking.CustomerId);
            ViewData["PackageId"] = new SelectList(_context.Package, "PackageId", "PackageName", booking.PackageId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,CustomerId,PackageId,BookingDate")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }


            try
            {
                _unitOfWork.BookingRepository.Update(booking);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(booking.BookingId))
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

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Booking == null)
            {
                return NotFound();
            }

            var booking = await _unitOfWork.BookingRepository.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Booking == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.Booking'  is null.");
            }
            _unitOfWork.BookingRepository.Delete(id);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _unitOfWork.BookingRepository.GetByIdAsync(id) != null;
        }
    }
}
