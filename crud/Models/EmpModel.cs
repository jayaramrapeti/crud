using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace crud.Models
{
    public class EmpModel
    {
        [Display(Name = "Id")]
        public int Empid { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address Required")]
        public string Address { get; set; }
    } 
}