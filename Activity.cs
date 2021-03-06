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
    
    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            this.Activity1 = new HashSet<Activity>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> CreatedById { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> ModifiedById { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.Guid> PriorityId { get; set; }
        public Nullable<System.Guid> AuthorId { get; set; }
        public bool RemindToAuthor { get; set; }
        public Nullable<System.DateTime> RemindToAuthorDate { get; set; }
        public Nullable<System.Guid> OwnerId { get; set; }
        public bool RemindToOwner { get; set; }
        public Nullable<System.DateTime> RemindToOwnerDate { get; set; }
        public Nullable<System.Guid> TypeId { get; set; }
        public bool ShowInScheduler { get; set; }
        public Nullable<System.Guid> StatusId { get; set; }
        public Nullable<System.Guid> ResultId { get; set; }
        public string DetailedResult { get; set; }
        public Nullable<System.Guid> TimeZoneId { get; set; }
        public Nullable<System.Guid> AccountId { get; set; }
        public Nullable<System.Guid> ContactId { get; set; }
        public string Recepient { get; set; }
        public string CopyRecepient { get; set; }
        public string BlindCopyRecepient { get; set; }
        public string Body { get; set; }
        public string Notes { get; set; }
        public string Color { get; set; }
        public Nullable<System.DateTime> SendDate { get; set; }
        public Nullable<System.Guid> EmailSendStatusId { get; set; }
        public string ErrorOnSend { get; set; }
        public int DurationInMinutes { get; set; }
        public string DurationInMnutesAndHours { get; set; }
        public Nullable<System.Guid> ActivityCategoryId { get; set; }
        public string AllowedResult { get; set; }
        public bool CreatedByInvCRM { get; set; }
        public Nullable<System.Guid> MessageTypeId { get; set; }
        public string Sender { get; set; }
        public int ProcessListeners { get; set; }
        public bool IsHtmlBody { get; set; }
        public string HtmlBody { get; set; }
        public string MailHash { get; set; }
        public Nullable<System.Guid> ProcessElementId { get; set; }
        public string GlobalActivityID { get; set; }
        public string UserEmailAddress { get; set; }
        public Nullable<System.Guid> InvoiceId { get; set; }
        public Nullable<System.Guid> LeadId { get; set; }
        public Nullable<System.Guid> OpportunityId { get; set; }
        public Nullable<System.Guid> ProjectId { get; set; }
        public Nullable<System.Guid> OrderId { get; set; }
        public string FullProjectName { get; set; }
        public bool IsNeedProcess { get; set; }
        public Nullable<System.Guid> ActivityConnectionId { get; set; }
        public Nullable<System.Guid> ContractId { get; set; }
        public Nullable<System.Guid> DocumentId { get; set; }
        public Nullable<System.Guid> EventId { get; set; }
        public Nullable<System.Guid> CaseId { get; set; }
        public Nullable<System.Guid> ChangeId { get; set; }
        public Nullable<System.Guid> ReleaseId { get; set; }
        public Nullable<System.Guid> ProblemId { get; set; }
        public Nullable<System.Guid> QueueItemId { get; set; }
        public Nullable<System.Guid> OrganizerId { get; set; }
        public string Location { get; set; }
        public bool IsNotPublished { get; set; }
        public Nullable<System.Guid> CallDirectionId { get; set; }
        public Nullable<System.Guid> ConfItemId { get; set; }
        public string HeaderProperties { get; set; }
        public Nullable<System.Guid> EnrchEmailDataId { get; set; }
        public string EnrichStatus { get; set; }
        public bool ServiceProcessed { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Contact Contact1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity1 { get; set; }
        public virtual Activity Activity2 { get; set; }
        public virtual Contact Contact2 { get; set; }
        public virtual Contact Contact3 { get; set; }
        public virtual ActivityResult ActivityResult { get; set; }
    }
}
