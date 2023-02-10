using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Commands;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.DTOs;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class CustomersController : Controller
    {
        private readonly TuHotelEnLineaContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICommandHandler<CustomerDTO> _customerCommandHandler;
        private readonly ICommandHandler<Customer> _updateCommandHandler;
        private readonly ICommandHandler<RemoveByIdCommand> _removeCommandHandler;
        private readonly IQueryHandler<Customer, QueryByIdCommand> _customerQueryHandler;



        public CustomersController(
            TuHotelEnLineaContext context,
            IQueryHandler<Customer, QueryByIdCommand> customerQueryHandler,
            ICommandHandler<RemoveByIdCommand> removeCommandHandler,
            ICommandHandler<CustomerDTO> customerCommandHandler,
            ICommandHandler<Customer> updateCommandHandler
            )

        {

            _context = context;
            _customerQueryHandler = customerQueryHandler;
            _customerCommandHandler = customerCommandHandler;
            _removeCommandHandler = removeCommandHandler;
            _updateCommandHandler = updateCommandHandler;
        }

        // GET: Customers
        public async Task<ActionResult<IEnumerable<Customer>>> Index()
        {
            return View(await _customerQueryHandler.GetAll());
        }

        // GET: Customers/Details/5
        public async Task<ActionResult<Customer>> Details(int id)
        {

            var customer = await _customerQueryHandler.GetOne(new QueryByIdCommand()
            {
                Id = id
            });

            if (customer == null)
            {
                return NotFound();
            }


            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerName,CustomerLastName,CustomerIdCard,CustomerPhone")] CustomerDTO customer)
        {

            _customerCommandHandler.Execute(customer);
            return RedirectToAction(nameof(Index));

        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerQueryHandler.GetOne(new QueryByIdCommand()
            {
                Id = id
            });
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerName,CustomerLastName,CustomerIdCard,CustomerPhone")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            try
            {
                _updateCommandHandler.Execute(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.CustomerId))
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

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _customerQueryHandler.GetOne(new QueryByIdCommand()
            {
                Id = id
            });
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.Customer'  is null.");
            }
            _removeCommandHandler.Execute(new RemoveByIdCommand()
            {
                Id = id
            });

            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _customerQueryHandler.GetOne(new QueryByIdCommand()
            {
                Id = id
            }) != null;
        }
    }
}
