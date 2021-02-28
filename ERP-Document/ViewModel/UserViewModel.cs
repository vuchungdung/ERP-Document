using ERP_Document.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP_Document.ViewModel
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập đầy đủ họ và tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập đầy đủ địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
        public int DepartmentId { get; set; }
        public UserStatus Status { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
        public string _DepartmentId { get; set; }
    }
}