//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _MiniProject_
{
    using System;
    using System.Collections.Generic;
    
    public partial class train
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public train()
        {
            this.Bookings = new HashSet<Booking>();
        }
    
        public int Train_Id { get; set; }
        public string Class { get; set; }
        public string TrainName { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        public Nullable<int> TotalBerths { get; set; }
        public Nullable<int> AvailableBerths { get; set; }
        public Nullable<decimal> Fare { get; set; }
        public string IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
