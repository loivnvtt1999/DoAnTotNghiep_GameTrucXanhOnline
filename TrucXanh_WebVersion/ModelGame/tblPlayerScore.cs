using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGame
{
    public class tblPlayerScore
    {
        [Key]
        public int idScore { get; set; }
        public int userID { get; set; }
        public int score { get; set; }
        public int levelIdLose { get; set; }
        [ForeignKey("userID")]
        public virtual tblUser User { get; set; }
    }
}
