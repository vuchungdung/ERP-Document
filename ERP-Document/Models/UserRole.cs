﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP_Document.Models
{
    [Table("UserRoles")]
    public class UserRole
    {
        [Key]
        [Column(Order = 1)]
        public int RoleId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int UserId { get; set; }
    }
}