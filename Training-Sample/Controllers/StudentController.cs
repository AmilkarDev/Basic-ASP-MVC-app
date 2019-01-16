using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training_Sample.Models;

namespace Training_Sample.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(string search,string option)
        {
            StudentDBHandle dbhandle = new StudentDBHandle();
            ModelState.Clear();
            List<StudentModel> ll = new List<StudentModel>();
            ll = dbhandle.GetStudent();
            if (option == "Name")
            {
                List<StudentModel> ss = ll.Where(x => x.Name == search).ToList();
                return View(ss);
            }
            else if (option == "City")
            {
                return View(ll.Where(x => x.City == search).ToList());
            }
            else if (option == "Address")
            {
                return View(ll.Where(x => x.Address == search).ToList());
            }
           else
                return View(ll);
        }

        //// GET: Student/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    StudentDBHandle sdb = new StudentDBHandle();
                    if (sdb.AddStudent(smodel))
                    {
                        ViewBag.Message = "Student Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentDBHandle sdb = new StudentDBHandle();
            return View(sdb.GetStudent().Find(smodel => smodel.Id == id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentModel smodel)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();
                sdb.UpdateDetails(smodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                StudentDBHandle sdb = new StudentDBHandle();
                if (sdb.DeleteStudent(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Student/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
