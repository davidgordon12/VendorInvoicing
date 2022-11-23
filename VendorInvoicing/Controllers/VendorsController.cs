using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using VendorInvoicing.Data;
using VendorInvoicing.Entities;
using VendorInvoicing.Models;
using VendorInvoicing.Services;

namespace VendorInvoicing.Controllers
{
    public class VendorsController : Controller
    {
        private readonly VendorService _vendorService;

        public VendorsController(VendorService vendorService) => 
            _vendorService = vendorService;

        public IActionResult Index(char? id)
        {
            ViewBag.Deleted = DeletedService.GetLastDeleted();

            if (id is null)
                return View(_vendorService.GetVendors());

            return View(_vendorService.GetVendorsByRange(id));
        }

        public IActionResult Invoices(int? id, int? invoiceId)
        {
            if (id is null)
                return RedirectToAction("Index");

            // initial page load
            if (invoiceId is null)
                return View(new VendorInvoices
                {
                    Vendor = _vendorService.GetVendor(id),
                    InvoiceLineItems = Enumerable.Empty<InvoiceLineItem>().ToList(),
                });
                
            // if an invoice was passed, it will show all the invoices
            // along with it's InvoiceLineItems 
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
                return RedirectToAction();

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
                return RedirectToAction("Index");

            _vendorService.RemoveVendor(id);
            return RedirectToAction("Index");
        }

        public IActionResult Undo(int id)
        {
            _vendorService.ReinstateVendor(id);
            return RedirectToAction("Index");
        }
    }
}
