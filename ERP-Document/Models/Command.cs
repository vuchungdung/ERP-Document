using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP_Document.Models
{
    [Table("Commands")]
    public class Command
    {
        [Key]
        public string CommandId { get; set; }
        public string Name { get; set; }
    }
}