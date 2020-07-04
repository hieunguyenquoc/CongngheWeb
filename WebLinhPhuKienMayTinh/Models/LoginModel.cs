using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLinhPhuKienMayTinh.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage ="Bạn phải nhập tên đăng nhập")]
        public string name { set; get; }
        [Display(Name ="Mật khẩu")]
        [Required(ErrorMessage ="Bạn phải nhập mật khẩu")]
        public string password0 { set; get; }
    }
}