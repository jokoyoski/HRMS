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
    
    public partial class Asset
    {
        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public string AssetDescription { get; set; }
        public decimal AssetCost { get; set; }
        public int LifeSpan { get; set; }
        public string AssetSerialNumber { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int CompanyId { get; set; }
    }
}
