using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGame
{
    public class tblAccount
    {
        [Key]
        public int accountID { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn phải nhập tên tài khoản")]
        public string nameAccount { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        public string password { get; set; }
        public int? userID { get; set; }
        [ForeignKey("userID")]
        public virtual tblUser User { get; set; }
    }
}
