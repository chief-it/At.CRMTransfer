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
    
    public partial class tbl_Contact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Contact()
        {
            this.tbl_Contact1 = new HashSet<tbl_Contact>();
            this.tbl_Contact11 = new HashSet<tbl_Contact>();
            this.tbl_ContactCommunication = new HashSet<tbl_ContactCommunication>();
            this.tbl_Account = new HashSet<tbl_Account>();
            this.tbl_Account1 = new HashSet<tbl_Account>();
            this.tbl_Account3 = new HashSet<tbl_Account>();
            this.tbl_Account4 = new HashSet<tbl_Account>();
            this.tbl_Account5 = new HashSet<tbl_Account>();
            this.tbl_Account6 = new HashSet<tbl_Account>();
            this.tbl_ContactCareer = new HashSet<tbl_ContactCareer>();
            this.tbl_Task = new HashSet<tbl_Task>();
            this.tbl_Task1 = new HashSet<tbl_Task>();
        }
    
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> AccountID { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string Name { get; set; }
        public string TimeZone { get; set; }
        public Nullable<System.Guid> CreatedByID { get; set; }
        public Nullable<System.Guid> ModifiedByID { get; set; }
        public string Dear { get; set; }
        public Nullable<System.Guid> SalutationID { get; set; }
        public string GenderID { get; set; }
        public Nullable<System.Guid> DepartmentID { get; set; }
        public Nullable<System.Guid> JobID { get; set; }
        public string JobTitle { get; set; }
        public Nullable<System.Guid> OwnerID { get; set; }
        public string Address { get; set; }
        public Nullable<System.Guid> AddressTypeID { get; set; }
        public Nullable<System.Guid> CityID { get; set; }
        public Nullable<System.Guid> StateID { get; set; }
        public Nullable<System.Guid> CountryID { get; set; }
        public Nullable<System.Guid> TerritoryID { get; set; }
        public string ZIP { get; set; }
        public string Communication1 { get; set; }
        public string Communication2 { get; set; }
        public string Communication3 { get; set; }
        public string Communication4 { get; set; }
        public Nullable<System.Guid> Communication1TypeID { get; set; }
        public Nullable<System.Guid> Communication2TypeID { get; set; }
        public Nullable<System.Guid> Communication3TypeID { get; set; }
        public Nullable<System.Guid> Communication4TypeID { get; set; }
        public Nullable<System.Guid> DecisionRoleID { get; set; }
        public byte[] Description { get; set; }
        public Nullable<int> DoNotCall { get; set; }
        public Nullable<int> EmailOptOut { get; set; }
        public Nullable<System.Guid> ContactTypeID { get; set; }
        public byte[] Photo { get; set; }
        public Nullable<System.Guid> AuthorID { get; set; }
        public string DocumentName { get; set; }
        public string DocumentBasis { get; set; }
        public string Comment { get; set; }
    
        public virtual tbl_Job tbl_Job { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Contact> tbl_Contact1 { get; set; }
        public virtual tbl_Contact tbl_Contact2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Contact> tbl_Contact11 { get; set; }
        public virtual tbl_Contact tbl_Contact3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ContactCommunication> tbl_ContactCommunication { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Account> tbl_Account { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Account> tbl_Account1 { get; set; }
        public virtual tbl_Account tbl_Account2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Account> tbl_Account3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Account> tbl_Account4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Account> tbl_Account5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Account> tbl_Account6 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ContactCareer> tbl_ContactCareer { get; set; }
        public virtual tbl_City tbl_City { get; set; }
        public virtual tbl_Country tbl_Country { get; set; }
        public virtual tbl_State tbl_State { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Task> tbl_Task { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Task> tbl_Task1 { get; set; }
    }
}
