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
    
    public partial class Contact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contact()
        {
            this.Account = new HashSet<Account>();
            this.Account2 = new HashSet<Account>();
            this.Activity = new HashSet<Activity>();
            this.Activity1 = new HashSet<Activity>();
            this.Activity2 = new HashSet<Activity>();
            this.Activity3 = new HashSet<Activity>();
            this.Contact1 = new HashSet<Contact>();
            this.Contact11 = new HashSet<Contact>();
            this.ContactCommunication = new HashSet<ContactCommunication>();
            this.Account3 = new HashSet<Account>();
            this.ContactCareer = new HashSet<ContactCareer>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.Guid> CreatedById { get; set; }
        public Nullable<System.Guid> ModifiedById { get; set; }
        public Nullable<System.Guid> AccountId { get; set; }
        public string Dear { get; set; }
        public Nullable<System.Guid> SalutationTypeId { get; set; }
        public Nullable<System.Guid> GenderId { get; set; }
        public Nullable<System.Guid> OwnerId { get; set; }
        public Nullable<System.Guid> DecisionRoleId { get; set; }
        public Nullable<System.Guid> JobId { get; set; }
        public string JobTitle { get; set; }
        public Nullable<System.Guid> DepartmentId { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Phone { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string Skype { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Nullable<System.Guid> CityId { get; set; }
        public Nullable<System.Guid> RegionId { get; set; }
        public string Zip { get; set; }
        public Nullable<System.Guid> CountryId { get; set; }
        public bool DoNotUseEmail { get; set; }
        public bool DoNotUseCall { get; set; }
        public bool DoNotUseFax { get; set; }
        public bool DoNotUseSms { get; set; }
        public bool DoNotUseMail { get; set; }
        public string Notes { get; set; }
        public Nullable<System.Guid> TypeId { get; set; }
        public Nullable<System.Guid> AddressTypeId { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string FacebookId { get; set; }
        public string LinkedInId { get; set; }
        public string TwitterId { get; set; }
        public byte[] ContactPhoto { get; set; }
        public Nullable<System.Guid> TwitterAFDAId { get; set; }
        public Nullable<System.Guid> FacebookAFDAId { get; set; }
        public Nullable<System.Guid> LinkedInAFDAId { get; set; }
        public int ProcessListeners { get; set; }
        public Nullable<System.Guid> PhotoId { get; set; }
        public string GPSN { get; set; }
        public string GPSE { get; set; }
        public string Surname { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public bool Confirmed { get; set; }
        public bool IsNonActualEmail { get; set; }
        public int RId { get; set; }
        public int Completeness { get; set; }
        public Nullable<System.Guid> LanguageId { get; set; }
        public string UsrDocumentBasis { get; set; }
        public string UsrDocumentName { get; set; }
        public Nullable<System.Guid> UsrAuthorId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Account { get; set; }
        public virtual Account Account1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Account2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> Contact1 { get; set; }
        public virtual Contact Contact2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> Contact11 { get; set; }
        public virtual Contact Contact21 { get; set; }
        public virtual Job Job { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactCommunication> ContactCommunication { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Account3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactCareer> ContactCareer { get; set; }
        public virtual City City { get; set; }
        public virtual Region Region { get; set; }
        public virtual Country Country { get; set; }
    }
}
