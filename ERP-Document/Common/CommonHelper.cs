using ERP_Document.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ERP_Document.Common
{
    public class CommonHelper
    {       
        public static IEnumerable<SelectListItem> GetDepartments()
        {
            ERDDbContext _db = new ERDDbContext();
            IEnumerable<SelectListItem> listItems = null;
            List<SelectListItem> list = new List<SelectListItem>();
            listItems = _db.Departments.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.DepartmentId.ToString()
            }).ToList();
            list.Add(new SelectListItem
            {
                Text = "Chọn phòng ban công tác",
                Value = ""
            });
            list.AddRange(listItems);
            listItems = list;
            return listItems;
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text)); 
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            { 
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }
    }
}