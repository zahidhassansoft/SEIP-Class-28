using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEIP_Class_28.DAL;
using SEIP_Class_28.Models;

namespace SEIP_Class_28.Controllers
{
    public class StudentsController : Controller
    {
        StudentGateway studentGateway=new StudentGateway();

        // GET: Students
        public ActionResult Index()
        {
            List<Student> students = studentGateway.Get();
            return View(students);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentGateway.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Contact")] Student student)
        {
            if (ModelState.IsValid)
            {
                int rowAffected = studentGateway.Add(student);
                if (rowAffected > 0)
                {
                    return RedirectToAction("Index");
                }
                
            }

            return View(student);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentGateway.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Contact")] Student student)
        {
            if (ModelState.IsValid)
            {
                bool isUpdate = studentGateway.Update(student);
                if (isUpdate)
                {
                    return RedirectToAction("Index");
                }              
            }
            return View(student);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentGateway.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = studentGateway.Find(id);
            bool isDelete = studentGateway.Delete(student);
            if (isDelete)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return Content("Can not delete the student");
            }
        }
    }
}