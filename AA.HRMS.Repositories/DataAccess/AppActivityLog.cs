//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AA.HRMS.Repositories.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class AppActivityLog
    {
        public int AppActivityLogId { get; set; }
        public System.DateTime LogDate { get; set; }
        public string Username { get; set; }
        public string Activity { get; set; }
    }
}
