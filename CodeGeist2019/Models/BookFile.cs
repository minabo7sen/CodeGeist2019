using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeGeist2019.Models
{
    public class BookFile
    {

        [Key]
        public int ID { get; set; }

        public string FilePath { get; set; }

    }
}