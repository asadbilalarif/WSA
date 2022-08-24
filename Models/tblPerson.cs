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
    using System.Collections.Generic;
    
    public partial class tblPerson
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPerson()
        {
            this.tblAddresses = new HashSet<tblAddress>();
            this.tblChilds = new HashSet<tblChild>();
            this.tblDocumentImgs = new HashSet<tblDocumentImg>();
            this.tblTransactions = new HashSet<tblTransaction>();
        }
    
        public int PersonIDNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Nullable<int> CountryOfApplication { get; set; }
        public string CityOfBirth { get; set; }
        public Nullable<int> CountryOfBirth { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string EMail { get; set; }
        public string Website { get; set; }
        public string DateOfBirth { get; set; }
        public string BirthDay { get; set; }
        public string BirthMonth { get; set; }
        public string BirthYear { get; set; }
        public Nullable<int> Sex { get; set; }
        public string Height { get; set; }
        public Nullable<int> HeightUnit { get; set; }
        public Nullable<int> Eyes { get; set; }
        public string Marks { get; set; }
        public Nullable<int> OccupationId { get; set; }
        public Nullable<int> OccupationCode { get; set; }
        public string Title { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public Nullable<int> WSANumber { get; set; }
        public string Comments { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> TransactionCount { get; set; }
        public string SignaturePath { get; set; }
        public string Photo { get; set; }
        public byte[] Photograph { get; set; }
        public byte[] Signature { get; set; }
        public string Certification { get; set; }
        public Nullable<int> CountryOfBirthStatistical { get; set; }
        public string QRCode { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime EntryDate { get; set; }
        public Nullable<int> LastEditedBy { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<bool> isActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblAddress> tblAddresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblChild> tblChilds { get; set; }
        public virtual tblCountry tblCountry { get; set; }
        public virtual tblCountry tblCountry1 { get; set; }
        public virtual tblCountry tblCountry2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDocumentImg> tblDocumentImgs { get; set; }
        public virtual tblEye tblEye { get; set; }
        public virtual tblOccupation tblOccupation { get; set; }
        public virtual tblSex tblSex { get; set; }
        public virtual tblStatus tblStatu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTransaction> tblTransactions { get; set; }
        public virtual tblUser tblUser { get; set; }
        public virtual tblUser tblUser1 { get; set; }
        public virtual tblUser tblUser2 { get; set; }
    }
}
