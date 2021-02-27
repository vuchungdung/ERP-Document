using ERP_Document.Models;
using ERP_Document.ViewModel;
using PagedList;
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

        public ActionResult Index(string keyWord, int page = 1, int pageSize = 10)
        {
            IPagedList<DepartmentViewModel> list = null;
            var models = _db.Departments.ToList();
            if (!String.IsNullOrEmpty(keyWord))
            {
                models = models.Where(x => x.Name.ToUpper().Contains(keyWord.ToUpper())).ToList();
            }
            list = models.Select(x => new DepartmentViewModel()
            {
                DepartmentId = x.DepartmentId,
                Name = x.Name,
                Description = x.Description

            }).OrderByDescending(x=>x.DepartmentId).ToPagedList(page, pageSize);
            ViewBag.SearchString = keyWord;
            ViewBag.Count = models.Count();
            return View(list);
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
                    ModelState.Clear();
                    ModelState.AddModelError("", "Thêm phòng ban thành công");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm phòng ban không thành công");
                }
            }
            return View("Create");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = _db.Departments.Find(id);
            DepartmentViewModel viewModel = new DepartmentViewModel();
            viewModel.Name = model.Name;
            viewModel.Description = model.Description;
            viewModel.DepartmentId = model.DepartmentId;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Update(DepartmentViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _db.Departments.Find(viewModel.DepartmentId);
                model.Name = viewModel.Name;
                model.Description = viewModel.Description;
                if (_db.SaveChanges() > 0)
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "Cập nhật phòng ban thành công");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật phòng ban không thành công");
                }
                return View("Update");
            }
            return View("Update");
        }
        public JsonResult Delete(int id)
        {
            try
            {
                var model = _db.Departments.Find(id);
                _db.Departments.Remove(model);
                _db.SaveChanges();               
                return Json(model.Name, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}