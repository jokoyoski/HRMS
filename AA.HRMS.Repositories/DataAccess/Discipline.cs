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
    
    public partial class Discipline
    {
        public int DisciplineId { get; set; }
        public int EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public System.DateTime QueryDate { get; set; }
        public string Offence { get; set; }
        public string QueryInitiator { get; set; }
        public string Investigator { get; set; }
        public string Response { get; set; }
        public int QueryStatusId { get; set; }
        public string InvestigatorReport { get; set; }
        public string RecommendedSanction { get; set; }
        public string DisciplineCommitteeRecommendation { get; set; }
        public Nullable<int> ActionTakenId { get; set; }
        public Nullable<int> EvidenceDigitalFileId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
