using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelGame
{
    public class tblImage
    {
        [Key]
        public int idImage { get; set; }
        public string nameImage { get; set; }
    }
}
