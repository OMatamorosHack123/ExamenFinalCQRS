using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Configuration;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class CategoryRoomsController : Controller
    {
        private readonly TuHotelEnLineaContext _context;

        private readonly IUnitOfWork _unitOfWork;

        public CategoryRoomsController(TuHotelEnLineaContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        // GET: CategoryRooms
        public async Task<IActionResult> Index()
        {
            return View(await _unitOfWork.CategoryRoomRepository.GetAllAsync());
        }

        // GET: CategoryRooms/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.CategoryRoom == null)
            {
                return NotFound();
            }

            var categoryRoom = await _unitOfWork.CategoryRoomRepository.GetByIdAsync(id);
            if (categoryRoom == null)
            {
                return NotFound();
            }

            return View(categoryRoom);
        }

        // GET: CategoryRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryRoomId,CategoryRoomName,CategoryRoomDescription")] CategoryRoom categoryRoom)
        {

            _unitOfWork.CategoryRoomRepository.Add(categoryRoom);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));


        }

        // GET: CategoryRooms/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.CategoryRoom == null)
            {
                return NotFound();
            }

            var categoryRoom = await _unitOfWork.CategoryRoomRepository.GetByIdAsync(id);
            if (categoryRoom == null)
            {
                return NotFound();
            }
            return View(categoryRoom);
        }

        // POST: CategoryRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryRoomId,CategoryRoomName,CategoryRoomDescription")] CategoryRoom categoryRoom)
        {
            if (id != categoryRoom.CategoryRoomId)
            {
                return NotFound();
            }


            try
            {
                _unitOfWork.CategoryRoomRepository.Update(categoryRoom);
                _unitOfWork.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryRoomExists(categoryRoom.CategoryRoomId))
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

        // GET: CategoryRooms/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.CategoryRoom == null)
            {
                return NotFound();
            }

            var categoryRoom = await _unitOfWork.CategoryRoomRepository.GetByIdAsync(id);
            if (categoryRoom == null)
            {
                return NotFound();
            }

            return View(categoryRoom);
        }

        // POST: CategoryRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CategoryRoom == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.CategoryRoom'  is null.");
            }
            _unitOfWork.CategoryRoomRepository.Delete(id);
            _unitOfWork.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryRoomExists(int id)
        {
            return _unitOfWork.CategoryRoomRepository.GetByIdAsync(id) != null;
        }
    }
}
