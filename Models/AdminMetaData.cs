using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace URideApp.Models
{
    public class AdminMetaData
    {

        public int AdminId { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [Range(999999999.0, 9999999999.0,
            ErrorMessage = "Phone No.must have 12 numbers")]
        public string PhoneNo { get; set; }
        public string HomeAddress { get; set; }
        public string Email { get; set; }
    }
}