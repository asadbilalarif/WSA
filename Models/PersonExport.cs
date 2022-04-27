using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorldServiceOrganization.Models
{
    public class PersonExport
    {
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
        public Nullable<int> BirthDay { get; set; }
        public Nullable<int> BirthMonth { get; set; }
        public Nullable<int> BirthYear { get; set; }
        public Nullable<int> Sex { get; set; }
        public Nullable<double> Height { get; set; }
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
        public string CountryOfApplicationName { get; set; }
        public string CountryOfBirthName { get; set; }
        public string CountryOfBirthStatisticalName { get; set; }
        public string OccupationName  { get; set; }
        public string EyeName { get; set; }
        public string SexName { get; set; }
        public string StatusName { get; set; }
    }
}