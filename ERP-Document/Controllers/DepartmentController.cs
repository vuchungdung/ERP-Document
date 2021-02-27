using ERP_Document.Models;
using ERP_Document.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Document.Controllers
{
    public class DepartmentController : Controller
    {

        ERDDbContext _db = new ERDDbContext();

        public ActionResult Index()
        {
            var models = _db.Departments.Select(x => new DepartmentViewModel()
            {

                DepartmentId = x.DepartmentId,
                Name = x.Name,
                Description = x.Description

            }).ToList();
            return View(models);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new Department();
                model.Name = viewModel.Name;
                model.Description = viewModel.Description;
                _db.Departments.Add(model);
                if (_db.SaveChanges() > 0)
                {
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm phòng ban không thành công");
                }
            }
            return View("Create");
        }
    }
}