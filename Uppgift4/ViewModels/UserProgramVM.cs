using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Uppgift4.ViewModels
{
    public class UserProgramVM
    {
        public int user_channel_id { get; set; }
        public int? user_id { get; set; }
        public int? channel_id { get; set; }
        public string channel_name { get; set; }
        public string program_name { get; set; }
        public string program_type { get; set; }
        public DateTime start_time { get; set; }
        public string description { get; set; }
    }
}