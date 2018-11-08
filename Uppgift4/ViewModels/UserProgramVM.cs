using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Uppgift4.ViewModels
{
    public class UserProgramVM
    {
        [Key]
        public int? user_id { get; set; }
        public int? channel_id { get; set; }
        public string channel_name { get; set; }
    }
}