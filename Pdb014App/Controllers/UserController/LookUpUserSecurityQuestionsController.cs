using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.UserManage;
using Pdb014App.Repository;

namespace Pdb014App.Controllers.UserController
{
    public class LookUpUserSecurityQuestionsController : Controller
    {
        private readonly UserDbContext _context;

        public LookUpUserSecurityQuestionsController(UserDbContext context)
        {
            _context = context;
        }

        // GET: LookUpUserSecurityQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserSecurityQuestion.ToListAsync());
        }

        // GET: LookUpUserSecurityQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserSecurityQuestion = await _context.UserSecurityQuestion
                .FirstOrDefaultAsync(m => m.UserSecurityQuestionId == id);
            if (lookUpUserSecurityQuestion == null)
            {
                return NotFound();
            }

            return View(lookUpUserSecurityQuestion);
        }

        // GET: LookUpUserSecurityQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LookUpUserSecurityQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserSecurityQuestionId,UserSecurityQuestion")] LookUpUserSecurityQuestion lookUpUserSecurityQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lookUpUserSecurityQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lookUpUserSecurityQuestion);
        }

        // GET: LookUpUserSecurityQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserSecurityQuestion = await _context.UserSecurityQuestion.FindAsync(id);
            if (lookUpUserSecurityQuestion == null)
            {
                return NotFound();
            }
            return View(lookUpUserSecurityQuestion);
        }

        // POST: LookUpUserSecurityQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserSecurityQuestionId,UserSecurityQuestion")] LookUpUserSecurityQuestion lookUpUserSecurityQuestion)
        {
            if (id != lookUpUserSecurityQuestion.UserSecurityQuestionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lookUpUserSecurityQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LookUpUserSecurityQuestionExists(lookUpUserSecurityQuestion.UserSecurityQuestionId))
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
            return View(lookUpUserSecurityQuestion);
        }

        // GET: LookUpUserSecurityQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lookUpUserSecurityQuestion = await _context.UserSecurityQuestion
                .FirstOrDefaultAsync(m => m.UserSecurityQuestionId == id);
            if (lookUpUserSecurityQuestion == null)
            {
                return NotFound();
            }

            return View(lookUpUserSecurityQuestion);
        }

        // POST: LookUpUserSecurityQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lookUpUserSecurityQuestion = await _context.UserSecurityQuestion.FindAsync(id);
            _context.UserSecurityQuestion.Remove(lookUpUserSecurityQuestion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LookUpUserSecurityQuestionExists(int id)
        {
            return _context.UserSecurityQuestion.Any(e => e.UserSecurityQuestionId == id);
        }
    }
}
