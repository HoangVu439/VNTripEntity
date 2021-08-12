namespace VNTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            Bill_Detail = new HashSet<Bill_Detail>();
        }

        public int ID { get; set; }

        public int? ID_Customer { get; set; }

        public DateTime? Date_order { get; set; }

        public int? Phone_Number { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill_Detail> Bill_Detail { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
