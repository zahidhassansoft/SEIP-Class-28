using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEIP_Class_28.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15,ErrorMessage = "Name can't be greater than 5 character")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Address can't be greater than 5 character")]
        public string Address { get; set; }
        [Required]
        [Phone]
        [StringLength(11, ErrorMessage = "Contact can't be greater than 11 character")]
        public string Contact { get; set; }
    }
}