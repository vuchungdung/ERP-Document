using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ERP_Document.ViewModel
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập đầy đủ tên nhóm quyền!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập đầy đủ mô tả nhóm quyền!")]
        [MaxLength(250)]
        public string Description { get; set; }
    }
}