//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldServiceOrganization.Models
{
    using System;
    
    public partial class TransactionSummaryList_Result2
    {
        public int TransactionIDNumber { get; set; }
        public string IDCode { get; set; }
        public Nullable<double> Cost { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string ApplicationDate { get; set; }
        public string IssueDate { get; set; }
        public string SentDate { get; set; }
        public string ReturnDate { get; set; }
        public string Problems { get; set; }
        public Nullable<int> ProductIDNumber { get; set; }
        public Nullable<int> PersonIDNumber { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> EditBy { get; set; }
        public System.DateTime EditDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string Name { get; set; }
    }
}