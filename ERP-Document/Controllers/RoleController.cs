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
    public class RoleController : Controller
    {
        ERDDbContext _db = new ERDDbContext();

        public ActionResult Index(string keyWord, int page = 1, int pageSize = 10)
        {
            IPagedList<RoleViewModel> list = null;
            var models = _db.Roles.ToList();
            if (!String.IsNullOrEmpty(keyWord))
            {
                models = models.Where(x => x.Name.ToUpper().Contains(keyWord.ToUpper())).ToList();
            }
            list = models.Select(x => new RoleViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description

            }).OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
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
        public ActionResult Create(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new Role();
                model.Name = viewModel.Name;
                model.Description = viewModel.Description;
                _db.Roles.Add(model);
                if (_db.SaveChanges() > 0)
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "Thêm nhóm quyền thành công");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm nhóm quyền không thành công");
                }
            }
            return View("Create");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = _db.Roles.Find(id);
            RoleViewModel viewModel = new RoleViewModel();
            viewModel.Name = model.Name;
            viewModel.Description = model.Description;
            viewModel.Id = model.Id;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Update(RoleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _db.Roles.Find(viewModel.Id);
                model.Name = viewModel.Name;
                model.Description = viewModel.Description;
                if (_db.SaveChanges() > 0)
                {
                    ModelState.Clear();
                    ModelState.AddModelError("", "Cập nhật nhóm quyền thành công");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật nhóm quyền không thành công");
                }
                return View("Update");
            }
            return View("Update");
        }
        public JsonResult Delete(int id)
        {
            try
            {
                var model = _db.Roles.Find(id);
                _db.Roles.Remove(model);
                _db.SaveChanges();
                return Json(model.Name, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}