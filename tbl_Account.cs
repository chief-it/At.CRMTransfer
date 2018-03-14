//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace crmtransfer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Account()
        {
            this.tbl_Contact2 = new HashSet<tbl_Contact>();
            this.tbl_AccountCommunication = new HashSet<tbl_AccountCommunication>();
            this.tbl_ContactCareer = new HashSet<tbl_ContactCareer>();
            this.tbl_AccountAddress = new HashSet<tbl_AccountAddress>();
            this.tbl_Task = new HashSet<tbl_Task>();
        }
    
        public System.Guid ID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string Name { get; set; }
        public Nullable<System.Guid> CreatedByID { get; set; }
        public Nullable<System.Guid> ModifiedByID { get; set; }
        public string OfficialAccountName { get; set; }
        public Nullable<System.Guid> PrimaryContactID { get; set; }
        public Nullable<System.Guid> TerritoryID { get; set; }
        public Nullable<int> AnnualRevenue { get; set; }
        public Nullable<int> EmployeesNumber { get; set; }
        public Nullable<System.Guid> OwnerID { get; set; }
        public Nullable<System.Guid> AddressTypeID { get; set; }
        public string Address { get; set; }
        public Nullable<System.Guid> CityID { get; set; }
        public Nullable<System.Guid> StateID { get; set; }
        public string ZIP { get; set; }
        public Nullable<System.Guid> CountryID { get; set; }
        public Nullable<System.Guid> ActivityID { get; set; }
        public Nullable<System.Guid> FieldID { get; set; }
        public string Communication1 { get; set; }
        public string Communication2 { get; set; }
        public string Communication3 { get; set; }
        public string Communication4 { get; set; }
        public string Communication5 { get; set; }
        public Nullable<System.Guid> Communication1TypeID { get; set; }
        public Nullable<System.Guid> Communication2TypeID { get; set; }
        public Nullable<System.Guid> Communication3TypeID { get; set; }
        public Nullable<System.Guid> Communication4TypeID { get; set; }
        public Nullable<System.Guid> Communication5TypeID { get; set; }
        public byte[] Description { get; set; }
        public Nullable<System.Guid> AccountTypeID { get; set; }
        public string Code { get; set; }
        public string TaxRegistrationCode { get; set; }
        public Nullable<decimal> SettledCredit { get; set; }
        public Nullable<int> PostponementPayment { get; set; }
        public Nullable<System.Guid> DistanceID { get; set; }
        public Nullable<System.Guid> Distance_1ID { get; set; }
        public Nullable<int> UsedCars { get; set; }
        public Nullable<int> OwnService { get; set; }
        public Nullable<int> ASMAP { get; set; }
        public Nullable<System.Guid> Dir1 { get; set; }
        public Nullable<System.Guid> Dir2 { get; set; }
        public Nullable<System.Guid> Dir3 { get; set; }
        public Nullable<System.Guid> TransportType1 { get; set; }
        public Nullable<System.Guid> TransportType2 { get; set; }
        public Nullable<System.Guid> TransportType3 { get; set; }
        public Nullable<System.Guid> AuthorID { get; set; }
        public Nullable<System.Guid> Owner2ID { get; set; }
        public Nullable<System.Guid> Owner3ID { get; set; }
        public Nullable<System.Guid> Owner4ID { get; set; }
        public string Comment { get; set; }
    
        public virtual tbl_Contact tbl_Contact { get; set; }
        public virtual tbl_Contact tbl_Contact1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Contact> tbl_Contact2 { get; set; }
        public virtual tbl_Contact tbl_Contact3 { get; set; }
        public virtual tbl_Contact tbl_Contact4 { get; set; }
        public virtual tbl_Contact tbl_Contact5 { get; set; }
        public virtual tbl_Contact tbl_Contact6 { get; set; }
        public virtual tbl_Field tbl_Field { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccountCommunication> tbl_AccountCommunication { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ContactCareer> tbl_ContactCareer { get; set; }
        public virtual tbl_City tbl_City { get; set; }
        public virtual tbl_Country tbl_Country { get; set; }
        public virtual tbl_State tbl_State { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_AccountAddress> tbl_AccountAddress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Task> tbl_Task { get; set; }
    }
}
