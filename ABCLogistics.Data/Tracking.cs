//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABCLogistics.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tracking
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Location { get; set; }
        public System.DateTime Date { get; set; }
        public string Status { get; set; }
    }
}
