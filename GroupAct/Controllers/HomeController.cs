using GroupAct.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GroupAct.Controllers
{

    public class HomeController : Controller
    {
        readonly dboStudentEntities db = new dboStudentEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var studentList = db.Students.ToList();

            return View(MapFields(studentList));
        }

        [HttpPost]
        public ActionResult Index(string SearchBox)
        {
            //LAMBDA
            var studentList = db.Students.Where(student => student.Address.Contains(SearchBox) || SearchBox == "" || student.StudentID.ToString().Equals(SearchBox) || SearchBox == "").ToList();
            return View(MapFields(studentList));
        }
       
        [HttpGet]
        public ActionResult Add()
        {
            var studentEditVM = new StudentEditViewModel() { 
                SectionList = GetSections()
            };
            return View(studentEditVM);
        }
        [HttpPost]
        public ActionResult Add(StudentEditViewModel model)
        {
            var student = new Student()
            {
                StudentID = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                SectionID = int.Parse(model.SelectedSection)
            };
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Update(Guid studentID)
        {
            var data = db.Students.Where(students => students.StudentID == studentID).SingleOrDefault();
           
            var studentEditVM = new StudentUpdateViewModel()
            {
                SectionList = GetSections()
            };
            studentEditVM.FirstName = data.FirstName;
            studentEditVM.LastName = data.LastName;
            studentEditVM.Address = data.Address;
            studentEditVM.SelectedSection = data.SectionID.ToString();
            return View(studentEditVM);
        }
        
        [HttpPost]
        
        public ActionResult Update(Guid studentID, StudentUpdateViewModel model)
        {
                var data = db.Students.FirstOrDefault(student => student.StudentID == studentID);
                if (data != null)
                {
                    data.FirstName = model.FirstName;
                    data.LastName = model.LastName;
                    data.Address = model.Address;
                    data.SectionID = int.Parse(model.SelectedSection);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                } 
        }
       
     
        public ActionResult Delete(Guid studentID)
        {
                var data = db.Students.FirstOrDefault(student => student.StudentID == studentID);
                if (data != null)
                {
                    db.Students.Remove(data);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                    return RedirectToAction("Index");
        }
        public List<StudentModel> MapFields(List<Student> studentList)
        {
            var studentListVM = new List<StudentModel>();

            foreach (var student in studentList)
            {
                var studentVM = new StudentModel();

                studentVM.StudentID = student.StudentID;
                studentVM.FirstName = student.FirstName;
                studentVM.LastName = student.LastName;
                studentVM.Address = student.Address;
                studentVM.SectionName = student.Section;

                studentListVM.Add(studentVM);
            }

            return studentListVM;
        }
        public IEnumerable<SelectListItem> GetSections()
        {
            var section = db.Sections.Select(s => new SelectListItem
            {
                Value = s.SectionID.ToString(),
                Text = s.SectionName    
            }).ToList();
         

            var placeHolder = new SelectListItem()
            {
                Value = null,
                Text = "Select Section...."
            };
            section.Insert(0, placeHolder);
            return new SelectList(section, "Value", "Text");
        }
        [HttpGet]
        public ActionResult StudentLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult StudentLogin(string button)
        {
           return RedirectToAction("Index");
        }
    }
}