//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uppgift4.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class program
    {
        public int program_id { get; set; }
        public string program_name { get; set; }
        public System.DateTime start_time { get; set; }
        public byte[] end_time { get; set; }
        public int channel_id { get; set; }
        public string program_type { get; set; }
    
        public virtual channel channel { get; set; }
    }
}
