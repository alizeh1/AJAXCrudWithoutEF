using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAJAXCrudWithoutEF.Models;

namespace MVCAJAXCrudWithoutEF.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDB db = new EmployeeDB();
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult List()  //you can use Actionresult
        {
            return Json(db.ListAll(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(Employee emp)
        {
            return Json(db.Add(emp), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetbyID(int ID)
        {
            var GetID = db.ListAll().Find(x=>x.EmployeeID.Equals(ID));
            //return Json(GetID);
            return Json(GetID, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateEmp(Employee emp)
        {
            return Json(db.Update(emp),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteEmp(int ID)
        {
            return Json(db.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}