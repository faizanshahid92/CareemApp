using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace URideApp.Models.Profiles
{
    public class DriverMetaData
    {

        public int DriverId { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Full Name")]
        public string DriverName { get; set; }
        
        [Required]
        [Display(Name = "Hire Date")]
        public Nullable<System.DateTime> DriverHireDate { get; set; }
        [Required(ErrorMessage = "BirthDate is required")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "HomeAddress is required")]
        public string HomeAddress { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [Range(999999999.0, 9999999999.0,
             ErrorMessage = "Phone No.must have 12 numbers")]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [Range(9999999999.0, 99999999999.0,
           ErrorMessage = "Phone No.must have 13 numbers")]
        public string LicenseNo { get; set; }
    }
}