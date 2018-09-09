using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace URideApp.Models
{
    public class PassengerMetaData
    {
        public int PassengerId { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name = "Full Name")]
        public string PassengerName { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Cell Number is required")]
        [Range(999999999.0, 9999999999.0,
     ErrorMessage = "Phone No.must have 12 numbers")]
        public string CellNo { get; set; }
        public string PermenantAddress { get; set; }
    }
}