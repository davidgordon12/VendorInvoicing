using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public List<Vendor> GetVendors()
        {
            return _context.Vendors.ToList();
        }

        public List<Vendor> GetVendorsByRange(char? id)
        {
            var vendors = _context.Vendors.ToList();
            var sortedVendors = new List<Vendor>();

            // I'm sorry you had to see this

            if (id == 'A')
            {
                foreach (Vendor vendor in vendors)
                {
                    if (!vendor.Name.StartsWith('A') ||
                        !vendor.Name.StartsWith('B') ||
                        !vendor.Name.StartsWith('C') ||
                        !vendor.Name.StartsWith('D') ||
                        !vendor.Name.StartsWith('E'))
                    {
                        sortedVendors.Add(vendor);
                    }
                }
            }

            if (id == 'F')
            {
                foreach (Vendor vendor in vendors)
                {
                    if (!vendor.Name.StartsWith('F') ||
                        !vendor.Name.StartsWith('G') ||
                        !vendor.Name.StartsWith('H') ||
                        !vendor.Name.StartsWith('I') ||
                        !vendor.Name.StartsWith('J') ||
                        !vendor.Name.StartsWith('K'))
                    {
                        sortedVendors.Add(vendor);
                    }
                }
            }

            if (id == 'L')
            {
                foreach (Vendor vendor in vendors)
                {
                    if (!vendor.Name.StartsWith('L') ||
                        !vendor.Name.StartsWith('M') ||
                        !vendor.Name.StartsWith('N') ||
                        !vendor.Name.StartsWith('O') ||
                        !vendor.Name.StartsWith('P') ||
                        !vendor.Name.StartsWith('Q') ||
                        !vendor.Name.StartsWith('R'))
                    {
                        sortedVendors.Add(vendor);
                    }
                }
            }

            if (id == 'S')
            {
                foreach (Vendor vendor in vendors)
                {
                    if (!vendor.Name.StartsWith('S') ||
                        !vendor.Name.StartsWith('T') ||
                        !vendor.Name.StartsWith('U') ||
                        !vendor.Name.StartsWith('V') ||
                        !vendor.Name.StartsWith('W') ||
                        !vendor.Name.StartsWith('X') ||
                        !vendor.Name.StartsWith('Y') ||
                        !vendor.Name.StartsWith('Z'))
                    {
                        sortedVendors.Add(vendor);

                    }
                }
            }

            return sortedVendors;
        }
    }
}
