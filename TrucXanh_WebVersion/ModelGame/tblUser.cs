using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGame
{
    public class tblUser
    {
        [Key]
        public int userID { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public bool role { get; set; }
    }
}
