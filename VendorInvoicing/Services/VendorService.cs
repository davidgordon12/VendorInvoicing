using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Net;
using VendorInvoicing.Data;
using VendorInvoicing.Entities;

namespace VendorInvoicing.Services
{
    public class VendorService
    {
        private readonly VendorDataContext _context;

        public VendorService(VendorDataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets a Vendor by id
        /// </summary>
        /// <param name="id">The wanted Vendor's id</param>
        /// <returns>A Vendor with the matching id</returns>
        public Vendor GetVendor(int? id)
        {
            return _context.Vendors.Where(v => v.VendorId == id).FirstOrDefault();
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
            var sortedVendors = new List<Vendor>();

            // I'm sorry you had to see this

            if (id == 'A')
            {
                foreach (Vendor vendor in vendors)
                {
                    if (vendor.Name.StartsWith('A') ||
                        vendor.Name.StartsWith('B') ||
                        vendor.Name.StartsWith('C') ||
                        vendor.Name.StartsWith('D') ||
                        vendor.Name.StartsWith('E'))
                    {
                        sortedVendors.Add(vendor);
                    }
                }
            }

            if (id == 'F')
            {
                foreach (Vendor vendor in vendors)
                {
                    if (vendor.Name.StartsWith('F') ||
                        vendor.Name.StartsWith('G') ||
                        vendor.Name.StartsWith('H') ||
                        vendor.Name.StartsWith('I') ||
                        vendor.Name.StartsWith('J') ||
                        vendor.Name.StartsWith('K'))
                    {
                        sortedVendors.Add(vendor);
                    }
                }
            }

            if (id == 'L')
            {
                foreach (Vendor vendor in vendors)
                {
                    if (vendor.Name.StartsWith('L') ||
                        vendor.Name.StartsWith('M') ||
                        vendor.Name.StartsWith('N') ||
                        vendor.Name.StartsWith('O') ||
                        vendor.Name.StartsWith('P') ||
                        vendor.Name.StartsWith('Q') ||
                        vendor.Name.StartsWith('R'))
                    {
                        sortedVendors.Add(vendor);
                    }
                }
            }

            if (id == 'S')
            {
                foreach (Vendor vendor in vendors)
                {
                    if (vendor.Name.StartsWith('S') ||
                        vendor.Name.StartsWith('T') ||
                        vendor.Name.StartsWith('U') ||
                        vendor.Name.StartsWith('V') ||
                        vendor.Name.StartsWith('W') ||
                        vendor.Name.StartsWith('X') ||
                        vendor.Name.StartsWith('Y') ||
                        vendor.Name.StartsWith('Z'))
                    {
                        sortedVendors.Add(vendor);

                    }
                }
            }

            return sortedVendors;
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
            catch(Exception)
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
        /// Removes the Vendor from the database
        /// </summary>
        /// <param name="vendor">The vendor to remove</param>
        /// <returns>True if successful</returns>
        public bool RemoveVendor(int? id)
        {
            try
            {
                _context.Remove(_context.Vendors.Where(v=>v.VendorId == id).FirstOrDefault());
                _context.SaveChanges();
                return true;
            }
            catch(Exception) { return false; }
        }
    }
}
