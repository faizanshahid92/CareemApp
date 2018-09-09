using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace URideApp.Models
{
    public class CarMetaData
    {

        public int CarId { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Car Model is required")]
        public Nullable<int> Model { get; set; }
        
        public string Company { get; set; }
        [Required(ErrorMessage = "Registration No. is required")]
        public string RegNo { get; set; }
    }
}