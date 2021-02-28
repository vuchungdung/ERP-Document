using ERP_Document.Common;
using ERP_Document.Enum;
using ERP_Document.Models;
using ERP_Document.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Document.Controllers
{
    public class UserController : Controller
    {
        ERDDbContext _db = new ERDDbContext();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new UserViewModel()
            {
                Departments = CommonHelper.GetDepartments()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(UserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = new User();
                model.Name = viewModel.Name;
                model.Username = viewModel.Username;
                model.Password = CommonHelper.MD5Hash(viewModel.Password);
                model.Email = viewModel.Email;
                model.Phone = viewModel.Phone;
                model.Address = viewModel.Address;
                model.Status = UserStatus.Blocked;
                if (!String.IsNullOrEmpty(viewModel._DepartmentId))
                {
                    model.DepartmentId = Convert.ToInt32(viewModel._DepartmentId);
                }
                _db.Users.Add(model);
                _db.SaveChanges();
            }
            return RedirectToAction("Create");
        }
    }
}