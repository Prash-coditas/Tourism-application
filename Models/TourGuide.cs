//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tourism_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TourGuide
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TourGuide()
        {
            this.Packages = new HashSet<Package>();
        }
    
        public int GuideId { get; set; }
        public string GuideName { get; set; }
        public string GuideMobile { get; set; }
        public string GuideEmail { get; set; }
        public string GuideAddress { get; set; }
        public int CityId { get; set; }
        public int Charges { get; set; }
    
        public virtual City City { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Package> Packages { get; set; }
    }
}
