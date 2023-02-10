using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class RoomsController : Controller
    {
        private readonly TuHotelEnLineaContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public RoomsController(TuHotelEnLineaContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {

            return View(await _unitOfWork.RoomRepository.GetAllAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _unitOfWork.RoomRepository.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            ViewData["CategoryRoomId"] = new SelectList(_context.CategoryRoom, "CategoryRoomId", "CategoryRoomDescription");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,CategoryRoomId,RoomNum,RoomFloor,RoomQuota")] Room room)
        {

            _unitOfWork.RoomRepository.Add(room);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));

        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _unitOfWork.RoomRepository.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["CategoryRoomId"] = new SelectList(_context.CategoryRoom, "CategoryRoomId", "CategoryRoomDescription", room.CategoryRoomId);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,CategoryRoomId,RoomNum,RoomFloor,RoomQuota")] Room room)
        {
            if (id != room.RoomId)
            {
                return NotFound();
            }


            try
            {
                _unitOfWork.RoomRepository.Update(room);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(room.RoomId))
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

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Room == null)
            {
                return NotFound();
            }

            var room = await _unitOfWork.RoomRepository.GetByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Room == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.Room'  is null.");
            }
            _unitOfWork.RoomRepository.Delete(id);

            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _unitOfWork.RoomRepository.GetByIdAsync(id) != null;
        }
    }
}
