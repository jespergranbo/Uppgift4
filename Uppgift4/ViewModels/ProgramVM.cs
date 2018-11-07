using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Uppgift4.ViewModels
{
    public class ProgramVM
    {
        public int channel_id { get; set; }
        public string channel_name { get; set; }
        public int program_id { get; set; }
        public string program_name { get; set; }
        public DateTime start_time { get; set; }
        public int end_time { get; set; }
        public string program_type { get; set; }
        public string description { get; set; }
        public string viewDay { get; set; }
    }
}