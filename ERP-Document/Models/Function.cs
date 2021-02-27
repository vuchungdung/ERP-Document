using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP_Document.Models
{
    [Table("Functions")]
    public class Function
    {
        [Key]
        public string FunctionId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string SortOrder { get; set; }
        public string ParentId { get; set; }
        public string Icon { get; set; }
    }
}