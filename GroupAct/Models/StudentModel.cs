using GroupAct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace GroupAct.Models
{
    public class StudentModel
    {
       public Guid StudentID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public Section SectionName { get; set; }
    }
}