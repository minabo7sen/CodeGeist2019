using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeGeist2019.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }

        public string Email { get; set; } //For binding account with ApplicationUser

        [Required]
        [Display(Name ="Full Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        public string BioGraphy { get; set; }
        public double Rating { get; set; }
        public bool Verfied{ get; set; }

        public List<Book> WriteList { get; set; }
        public List<Book> ReadList { get; set; }
        public List<Book> LikedList { get; set; }


        public virtual ICollection<Book> BoughtBooks { get; set; }

    }
}