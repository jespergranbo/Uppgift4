using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Uppgift4.Models
{
    public class Channel
    {
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public TimeSpan endTime { get; set; }
        public string showType { get; set; }
    }
}