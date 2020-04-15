using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pdb014App.Models.PDB.PoleModels;
using Pdb014App.Repository;
namespace Pdb014App.Controllers.PoleControllers
{
    public class TblPolePicturesController : Controller
    {
        private readonly PdbDbContext _context;

        public TblPolePicturesController(PdbDbContext context)
        {
            _context = context;
        }

        // GET: TblPolePictures
        public async Task<IActionResult> Index()
        {
            var pdbDbContext = _context.TblPolePicture.Include(t => t.PolePictureToPole);
            return View(await pdbDbContext.ToListAsync());
        }

        // GET: TblPolePictures/Details/5
        public async Task<IActionResult> Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var tblPolePicture = await _context.TblPolePicture
                .Include(t => t.PolePictureToPole)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPolePicture == null)
            {
                return NotFound();
            }

            return View(tblPolePicture);
        }

        // GET: TblPolePictures/Create
        public IActionResult Create()
        {
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId");
            return View();
        }

        // POST: TblPolePictures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("PolePictureId,PictureName,PictureLocation,PoleId")] TblPolePicture tblPolePicture)
        {


            string fileName = "";
            try
            {


                if (file.Length > 0)
                {
                    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                    fileName = Guid.NewGuid().ToString() + "_" + tblPolePicture.PictureName + extension; //Create a new Name 
                    //for the file due to security reasons.
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\PolePictures", fileName);

                    using (var bits = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(bits);
                    }
                }

            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                //return View();
            }

            if (ModelState.IsValid)
            {
                tblPolePicture.PictureName = fileName;
                _context.Add(tblPolePicture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPolePicture.PoleId);
            return View(tblPolePicture);
        }
        //public async Task<IActionResult> Create([Bind("PolePictureId,PictureName,PictureLocation,PoleId")] TblPolePicture tblPolePicture)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tblPolePicture);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPolePicture.PoleId);
        //    return View(tblPolePicture);
        //}

        // GET: TblPolePictures/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPolePicture = await _context.TblPolePicture.FindAsync(id);
            if (tblPolePicture == null)
            {
                return NotFound();
            }
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPolePicture.PoleId);
            return View(tblPolePicture);
        }

        // POST: TblPolePictures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PolePictureId,PictureName,PictureLocation,PoleId")] TblPolePicture tblPolePicture)
        {
            if (id != tblPolePicture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPolePicture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPolePictureExists(tblPolePicture.Id))
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
            ViewData["PoleId"] = new SelectList(_context.TblPole, "PoleId", "PoleId", tblPolePicture.PoleId);
            return View(tblPolePicture);
        }

        // GET: TblPolePictures/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var tblPolePicture = await _context.TblPolePicture
                .Include(t => t.PolePictureToPole)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblPolePicture == null)
            {
                return NotFound();
            }

            return View(tblPolePicture);
        }

        // POST: TblPolePictures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tblPolePicture = await _context.TblPolePicture.FindAsync(id);
            _context.TblPolePicture.Remove(tblPolePicture);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPolePictureExists(int id)
        {
            return _context.TblPolePicture.Any(e => e.Id == id);
        }
    }
}
