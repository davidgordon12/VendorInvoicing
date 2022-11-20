using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VendorInvoicing.Data;
using VendorInvoicing.Entities;
using VendorInvoicing.Models;
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

        public IActionResult Index(char? id)
        {
            if (id is null)
                return View(_vendorService.GetVendors());

            return View(_vendorService.GetVendorsByRange(id));
        }

        public IActionResult Invoices(int? id, int? invoiceId)
        {
            if (id is null)
                return View("Index", _vendorService.GetVendors());

            if (invoiceId is null)
                return View(new VendorInvoices
                {
                    Vendor = _vendorService.GetVendor(id),
                    InvoiceLineItems = Enumerable.Empty<InvoiceLineItem>().ToList(),
                });
                
            VendorInvoices vendorInvoices = _vendorService.GetVendorInvoices(id, invoiceId);
            return View(vendorInvoices);

            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                if(_vendorService.AddVendor(vendor)) // returns true if the vendor was added successfully
                    return RedirectToAction("Index");
            }
            return View(vendor);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Vendor vendor = _vendorService.GetVendor(id);
            return View(vendor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                if(_vendorService.UpdateVendorInformation(vendor))
                    return RedirectToAction("Index");
            }
            return View(vendor);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return View("Index");

            _vendorService.RemoveVendor(id);
            return View();
        }

    }
}
