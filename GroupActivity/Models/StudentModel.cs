using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroupAct.Models;

namespace GroupAct.Models
{
    public class StudentModel
    {
       public Guid StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public Section SectionName { get; set; }
    }
}