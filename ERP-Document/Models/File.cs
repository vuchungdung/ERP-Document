using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP_Document.Models
{
    [Table("Files")]
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string FileSize { get; set; }
        [Required]
        public string FileType { get; set; }
        [Required]
        public string FilePath { get; set; }
    }
}