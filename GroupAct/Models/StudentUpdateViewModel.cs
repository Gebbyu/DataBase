using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupAct.Models;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GroupAct.Models
{
    public class StudentUpdateViewModel
    {
        public Guid StudentID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        

        [Required(ErrorMessage = "Section is required")]
        public string SelectedSection { get; set; }

        
        public IEnumerable<SelectListItem> SectionList { get; set; }
    }
}