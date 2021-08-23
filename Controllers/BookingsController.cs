using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvcTheBigEat.Data;
using mvcTheBigEat.Models;



namespace mvcTheBigEat.Controllers
{
    /*
    *  Controller built from the Bookings model, this was built using scaffolding.
    */
    public class BookingsController : Controller
    {
        private readonly TheBigEatContext _context;


        public BookingsController(TheBigEatContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var theBigEatContext = _context.Bookings.Include(b => b.Course).Include(b => b.User);
            return View(await theBigEatContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Course)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingID == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name");
            // On create the select list fetches the users email and displays that rather than the ID to help identify which user is to make a booking.
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingID,CourseID,UserID,Slots")] Booking booking)
        {
            // get course with matching PK - fetches through booking foreign key child.
            Course course = _context.Courses.First(c => c.CourseID == booking.CourseID);

            //assuming the model form is okay to submit - when 'creating' a booking: remove booking.Slots value from the AvailableSlots.
            if (ModelState.IsValid)
            {
                course.AvailableSlots -= booking.Slots; //remove slots from class.
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", booking.CourseID);
            //select list presents the users email rather than displaying ID to help identify which user is to make a booking.
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", booking.UserID);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", booking.CourseID);
            //select list presents the users email rather than displaying ID to help identify which user is to make a booking.
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", booking.UserID);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingID,CourseID,UserID,Slots")] Booking booking)
        {
            if (id != booking.BookingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.BookingID))
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
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Name", booking.CourseID);
            ViewData["UserID"] = new SelectList(_context.Users, "ID", "Email", booking.UserID);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Course)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingID == id);
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
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingID == id);
        }


        
    }
}
