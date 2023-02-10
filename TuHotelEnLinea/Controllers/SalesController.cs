using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class SalesController : Controller
    {
        private readonly TuHotelEnLineaContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public SalesController(TuHotelEnLineaContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index()
        {

            return View(await _unitOfWork.SalesRepository.GetAllAsync());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _unitOfWork.SalesRepository.GetByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "BookingDate");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "PaymentMethodName");
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaleId,SaleTotal,BookingId,PaymentMethodId")] Sale sale)
        {

            _unitOfWork.SalesRepository.Add(sale);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _unitOfWork.SalesRepository.GetByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Booking, "BookingId", "BookingDate", sale.BookingId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "PaymentMethodName", sale.PaymentMethodId);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaleId,SaleTotal,BookingId,PaymentMethodId")] Sale sale)
        {
            if (id != sale.SaleId)
            {
                return NotFound();
            }


            try
            {
                _unitOfWork.SalesRepository.Update(sale);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(sale.SaleId))
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

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _unitOfWork.SalesRepository.GetByIdAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sale == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.Sale'  is null.");
            }
            _unitOfWork.SalesRepository.Delete(id);

            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleExists(int id)
        {
            return  _unitOfWork.SalesRepository.GetByIdAsync(id) != null ;
        }
    }
}
