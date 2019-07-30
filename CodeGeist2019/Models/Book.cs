using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CodeGeist2019.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public int AgeLimit { get; set; }
        public string Category { get; set; }
        public int Views { get; set; }


        public Account Author { get; set; }
        public BookFile File { get; set; }

        public virtual ICollection<Account> AllowedAccounts { get; set; }

    }
    
}