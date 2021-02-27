using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Document.ViewModel
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập thông tin tên phòng ban!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thông tin mô tả chi tiết phòng ban!")]
        public string Description { get; set; }
    }
}