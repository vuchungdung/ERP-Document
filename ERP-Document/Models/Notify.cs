using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP_Document.Models
{
    [Table("Notifies")]
    public class Notify
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotifyId { get; set; }
        public int UserId { get; set; }
        public bool IsSeen { get; set; }
        public int FileId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime SendTime { get; set; }
        public bool IsRecovery { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime RecoveryDate { get; set; }
    }
}