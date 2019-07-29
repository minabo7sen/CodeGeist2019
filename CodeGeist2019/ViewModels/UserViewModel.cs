using CodeGeist2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeGeist2019.ViewModels
{
    public class UserViewModel
    {
        public Account NewUser { get; set; }
        public bool Designer { get; set; }
        public bool Translator { get; set; }
    }
}