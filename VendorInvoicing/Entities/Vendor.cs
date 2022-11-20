using System.ComponentModel.DataAnnotations;

namespace VendorInvoicing.Entities
{
    public class Vendor
    {
        public int VendorId { get; set; }

        [Required(ErrorMessage = "Please enter a Vendor name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Please enter an address")]
        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        [Required(ErrorMessage = "Please enter a city")]
        public string? City { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a province or state")]
        public string? ProvinceOrState { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a zip or postal code")]
        public string? ZipOrPostalCode { get; set; } = null!;

        [Required(ErrorMessage = "Please enter a phone number")]
        public string? VendorPhone { get; set; }

        [Required(ErrorMessage = "Please enter a last name")]
        public string? VendorContactLastName { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        public string? VendorContactFirstName { get; set; }

        public string? VendorContactEmail { get; set; }

        public bool IsDeleted { get; set; } = false;

        public ICollection<Invoice>? Invoices { get; set; }
    }
}
