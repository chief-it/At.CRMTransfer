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
    
    public partial class AccountCommunication
    {
        public System.Guid Id { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> CreatedById { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> ModifiedById { get; set; }
        public Nullable<System.Guid> CommunicationTypeId { get; set; }
        public string Number { get; set; }
        public Nullable<System.Guid> AccountId { get; set; }
        public int Position { get; set; }
        public string SocialMediaId { get; set; }
        public string SearchNumber { get; set; }
        public int ProcessListeners { get; set; }
        public bool Primary { get; set; }
    
        public virtual Account Account { get; set; }
    }
}
