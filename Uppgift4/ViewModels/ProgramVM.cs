using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uppgift4.ViewModels
{
    public class ProgramVM
    {
        public int channel_id { get; set; }
        public string channel_name { get; set; }
        public int program_id { get; set; }
        public string program_name { get; set; }
        public DateTime start_time { get; set; }
        public byte[] end_time { get; set; }
    }
}