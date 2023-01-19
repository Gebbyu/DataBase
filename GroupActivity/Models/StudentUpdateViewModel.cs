using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroupAct.Models;
using System.Web.Mvc;

namespace GroupAct.Models
{
    public class StudentUpdateViewModel
    {
        public Guid StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public IEnumerable<SelectListItem> SectionList { get; set; }
        public string SelectedSection { get; set; }
    }
}