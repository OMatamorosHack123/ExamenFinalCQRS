using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class PaymentMethodsController : Controller
    {
        private readonly TuHotelEnLineaContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentMethodsController(TuHotelEnLineaContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: PaymentMethods
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.PaymentMethodRepository.GetAllAsync());
        }

        // GET: PaymentMethods/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.PaymentMethod == null)
            {
                return NotFound();
            }

            var paymentMethod = await _unitOfWork.PaymentMethodRepository.GetByIdAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return View(paymentMethod);
        }

        // GET: PaymentMethods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentMethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentMethodId,PaymentMethodName")] PaymentMethod paymentMethod)
        {

            _unitOfWork.PaymentMethodRepository.Add(paymentMethod);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }

        // GET: PaymentMethods/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.PaymentMethod == null)
            {
                return NotFound();
            }

            var paymentMethod = await _unitOfWork.PaymentMethodRepository.GetByIdAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }
            return View(paymentMethod);
        }

        // POST: PaymentMethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentMethodId,PaymentMethodName")] PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.PaymentMethodId)
            {
                return NotFound();
            }


            try
            {
                _unitOfWork.PaymentMethodRepository.Update(paymentMethod);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentMethodExists(paymentMethod.PaymentMethodId))
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

        // GET: PaymentMethods/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.PaymentMethod == null)
            {
                return NotFound();
            }

            var paymentMethod = await _unitOfWork.PaymentMethodRepository.GetByIdAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return View(paymentMethod);
        }

        // POST: PaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaymentMethod == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.PaymentMethod'  is null.");
            }
            _unitOfWork.PaymentMethodRepository.Delete(id);

            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentMethodExists(int id)
        {
            return _unitOfWork.PaymentMethodRepository.GetByIdAsync(id)!=null;
        }
    }
}
