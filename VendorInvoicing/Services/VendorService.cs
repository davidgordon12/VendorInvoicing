using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.RegularExpressions;
using VendorInvoicing.Data;
using VendorInvoicing.Entities;
using VendorInvoicing.Models;

namespace VendorInvoicing.Services
{
    public class VendorService
    {
#pragma warning disable CS8603 // this one is really annoying :p
#pragma warning disable CS8602 // this one too
        private readonly VendorDataContext _context;
        private Dictionary<string, int> deleted = new Dictionary<string, int>();

        public VendorService(VendorDataContext context) => _context = context;

        /// <summary>
        /// Gets a Vendor by id
        /// </summary>
        /// <param name="id">The wanted Vendor's id</param>
        /// <returns>A Vendor with the matching id</returns>
        public Vendor GetVendor(int? id)
        {
            return _context.Vendors.Where(v => v.VendorId == id)
                .Include(v => v.Invoices)
                .FirstOrDefault();
        }

        /// <summary>
        /// Creates a VendorInvoices ViewModel 
        /// </summary>
        /// <param name="id">The Vendor id</param>
        /// <param name="invoiceId">The Invoice id to load the InvoiceLineItems for</param>
        /// <returns></returns>
        public VendorInvoices GetVendorInvoices(int? id, int? invoiceId)
        {
            VendorInvoices vendorInvoices = new();

            vendorInvoices.Vendor = _context.Vendors
                .Where(v => v.VendorId == id)
                .Include(i => i.Invoices)
                .FirstOrDefault();

            vendorInvoices.InvoiceLineItems = _context.InvoiceItems.Where(
                v => v.InvoiceId == invoiceId).ToList();

            return vendorInvoices;
        }

        /// <summary>
        /// Gets a list of all Vendors in the database
        /// </summary>
        /// <returns>A list of type Vendor</returns>
        public List<Vendor> GetVendors()
        {
            return _context.Vendors.ToList();
        }

        /// <summary>
        /// Returns a list of Vendor's within a specific alphabetical range
        /// </summary>
        /// <param name="id">The id of the range query</param>
        /// <returns>A sorted list of type Vendor</returns>
        public List<Vendor> GetVendorsByRange(char? id)
        {
            var vendors = _context.Vendors.ToList();

            if (id == 'A')
            {
                var range = new Regex("^[A-E]", RegexOptions.IgnoreCase);
                List<Vendor> sortedVendors = vendors.Where(v => range.IsMatch(v.Name)).ToList();
                return sortedVendors;
            }

            if (id == 'F')
            {
                var range = new Regex("^[F-K]", RegexOptions.IgnoreCase);
                List<Vendor> sortedVendors = vendors.Where(v => range.IsMatch(v.Name)).ToList();
                return sortedVendors;
            }

            if (id == 'L')
            {
                var range = new Regex("^[L-R]", RegexOptions.IgnoreCase);
                List<Vendor> sortedVendors = vendors.Where(v => range.IsMatch(v.Name)).ToList();
                return sortedVendors;
            }

            if (id == 'S')
            {
                var range = new Regex("^[S-Z]", RegexOptions.IgnoreCase);
                List<Vendor> sortedVendors = vendors.Where(v => range.IsMatch(v.Name)).ToList();
                return sortedVendors;
            }

            return vendors;
        }

        /// <summary>
        /// Creates a Vendor in the database
        /// </summary>
        /// <param name="vendor">The Vendor to create</param>
        /// <returns>True if successful</returns>
        public bool AddVendor(Vendor vendor)
        {
            try
            {
                _context.Add(vendor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the Vendor in the database
        /// </summary>
        /// <param name="vendor">The Vendor to update</param>
        /// <returns>True if successful</returns>
        public bool UpdateVendorInformation(Vendor vendor)
        {
            try
            {
                _context.Update(vendor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// Soft deletes the Vendor by filtering them out from any queries
        /// </summary>
        /// <param name="vendor">The vendor to remove</param>
        /// <returns>True if successful</returns>
        public bool RemoveVendor(int? id)
        {
            try
            {
                var vendor = _context.Vendors.Where(v => v.VendorId == id).FirstOrDefault();
                vendor.IsDeleted = true;
                _context.Vendors.Update(vendor);
                _context.SaveChanges();

                DeletedService.AddLastDeleted(vendor.VendorId);

                return true;
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// Adds the Vendor back to the list of queryable Vendors
        /// </summary>
        /// <param name="id">The vendor to add</param>
        /// <returns>True if successful</returns>
        public bool ReinstateVendor(int id)
        {
            try
            {
                var vendor = _context.Vendors.Where(v => v.VendorId == id).IgnoreQueryFilters().FirstOrDefault();
                vendor.IsDeleted = false;
                _context.Vendors.Update(vendor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        /// Gets the id of the last deleted vendor
        /// </summary>
        /// <returns>The id of the last deleted vendor, if not null</returns>
        public int GetLastDeletedVendor()
        {
            if (deleted.ContainsKey("lastDeleted"))
                return deleted["lastDeleted"];
            else
                return 0;
        }
    }
#pragma warning restore CS8603 // this one is really annoying :p
#pragma warning restore CS8602 // this one too
}
