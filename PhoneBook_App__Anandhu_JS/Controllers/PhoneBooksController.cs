using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneBook_App__Anandhu_JS.Data;
using PhoneBook_App__Anandhu_JS.Models;

namespace PhoneBook_App__Anandhu_JS.Controllers
{
    [Authorize]
    public class PhoneBooksController : Controller
    {
        private readonly PhoneBook_App__Anandhu_JS__AuthDbContext _context;

        public PhoneBooksController(PhoneBook_App__Anandhu_JS__AuthDbContext context)
        {
            _context = context;
        }

        // GET: PhoneBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhoneBook.ToListAsync());
        }

        // GET: PhoneBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBook = await _context.PhoneBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneBook == null)
            {
                return NotFound();
            }

            return View(phoneBook);
        }

        // GET: PhoneBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PhoneNumber,Email,UserId")] PhoneBook phoneBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phoneBook);
        }


        // GET: PhoneBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBook = await _context.PhoneBook.FindAsync(id);
            if (phoneBook == null)
            {
                return NotFound();
            }
            return View(phoneBook);
        }

        // POST: PhoneBooks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber,Email,UserId")] PhoneBook phoneBook)
        {
            if (id != phoneBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneBookExists(phoneBook.Id))
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
            return View(phoneBook);
        }

        // GET: PhoneBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBook = await _context.PhoneBook
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phoneBook == null)
            {
                return NotFound();
            }

            return View(phoneBook);
        }

        // POST: PhoneBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneBook = await _context.PhoneBook.FindAsync(id);
            if (phoneBook != null)
            {
                _context.PhoneBook.Remove(phoneBook);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneBookExists(int id)
        {
            return _context.PhoneBook.Any(e => e.Id == id);
        }
    }
}
