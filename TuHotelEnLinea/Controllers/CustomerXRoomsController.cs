using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class CustomerXRoomsController : Controller
    {
        private readonly TuHotelEnLineaContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public CustomerXRoomsController(TuHotelEnLineaContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: CustomerXRooms
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.CustomerXRoomRepository.GetAllAsync());
        }

        // GET: CustomerXRooms/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.CustomerXRoom == null)
            {
                return NotFound();
            }

            var customerXRoom = await _unitOfWork.CustomerXRoomRepository.GetByIdAsync(id);
            if (customerXRoom == null)
            {
                return NotFound();
            }

            return View(customerXRoom);
        }

        // GET: CustomerXRooms/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerIdCard");
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId");
            return View();
        }

        // POST: CustomerXRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerXRoomId,CustomerId,RoomId,CustomerCreatedAt")] CustomerXRoom customerXRoom)
        {
            _unitOfWork.CustomerXRoomRepository.Add(customerXRoom);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));


        }

        // GET: CustomerXRooms/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.CustomerXRoom == null)
            {
                return NotFound();
            }

            var customerXRoom = await _unitOfWork.CustomerXRoomRepository.GetByIdAsync(id);
            if (customerXRoom == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerIdCard", customerXRoom.CustomerId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", customerXRoom.RoomId);
            return View(customerXRoom);
        }

        // POST: CustomerXRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerXRoomId,CustomerId,RoomId,CustomerCreatedAt")] CustomerXRoom customerXRoom)
        {
            if (id != customerXRoom.CustomerXRoomId)
            {
                return NotFound();
            }


            try
            {
                _unitOfWork.CustomerXRoomRepository.Update(customerXRoom);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerXRoomExists(customerXRoom.CustomerXRoomId))
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

        // GET: CustomerXRooms/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.CustomerXRoom == null)
            {
                return NotFound();
            }

            var customerXRoom = await _unitOfWork.CustomerXRoomRepository.GetByIdAsync(id);
            if (customerXRoom == null)
            {
                return NotFound();
            }

            return View(customerXRoom);
        }

        // POST: CustomerXRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomerXRoom == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.CustomerXRoom'  is null.");
            }
            _unitOfWork.CustomerXRoomRepository.Delete(id);

            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerXRoomExists(int id)
        {
            return _unitOfWork.CustomerXRoomRepository.GetByIdAsync(id)!= null;
        }
    }
}
