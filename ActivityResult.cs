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
    
    public partial class ActivityResult
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActivityResult()
        {
            this.Activity = new HashSet<Activity>();
        }
    
        public System.Guid Id { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> CreatedById { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.Guid> ModifiedById { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProcessListeners { get; set; }
        public Nullable<System.Guid> CategoryId { get; set; }
        public bool BusinessProcessOnly { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity { get; set; }
    }
}
