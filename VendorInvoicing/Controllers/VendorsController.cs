using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendorInvoicing.Data;
using VendorInvoicing.Entities;
using VendorInvoicing.Services;

namespace VendorInvoicing.Controllers
{
    public class VendorsController : Controller
    {
        private readonly VendorService _vendorService;

        public VendorsController(VendorDataContext context, VendorService vendorService)
        {
            _vendorService = vendorService;
        }

        // GET: Vendors
        public IActionResult Index(char? id)
        {
            if (id is null)
                return View(_vendorService.GetVendors());

            return View(_vendorService.GetVendorsByRange(id));
        }

        //// GET: Vendors/Details/5
        //public IActionResult Details(int? id)
        //{
        //    if (id == null || _context.Vendors == null)
        //    {
        //        return NotFound();
        //    }

        //    var vendor = _context.Vendors
        //        .FirstOrDefault(m => m.VendorId == id);
        //    if (vendor == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(vendor);
        //}

        //// GET: Vendors/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Vendors/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Vendor vendor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(vendor);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(vendor);
        //}

        //// GET: Vendors/Edit/5
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || _context.Vendors == null)
        //    {
        //        return NotFound();
        //    }

        //    var vendor = _context.Vendors.Find(id);
        //    if (vendor == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(vendor);
        //}

        //// POST: Vendors/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int id, Vendor vendor)
        //{
        //    if (id != vendor.VendorId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(vendor);
        //            _context.SaveChanges();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!VendorExists(vendor.VendorId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(vendor);
        //}

        //// GET: Vendors/Delete/5
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || _context.Vendors == null)
        //    {
        //        return NotFound();
        //    }

        //    var vendor = _context.Vendors
        //        .FirstOrDefault(m => m.VendorId == id);
        //    if (vendor == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(vendor);
        //}

        //// POST: Vendors/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    if (_context.Vendors == null)
        //    {
        //        return Problem("Entity set 'VendorDataContext.Vendors'  is null.");
        //    }
        //    var vendor = _context.Vendors.Find(id);
        //    if (vendor != null)
        //    {
        //        _context.Vendors.Remove(vendor);
        //    }

        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool VendorExists(int id)
        //{
        //    return _context.Vendors.Any(e => e.VendorId == id);
        //}
    }
}
