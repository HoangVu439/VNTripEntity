namespace VNTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VeMayBay")]
    public partial class VeMayBay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VeMayBay()
        {
            Bill_Detail = new HashSet<Bill_Detail>();
            Carts = new HashSet<Cart>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ID_Khuvuc { get; set; }

        [StringLength(50)]
        public string Group_Pro { get; set; }

        [StringLength(50)]
        public string Tenhang { get; set; }

        [StringLength(30)]
        public string Diemdi { get; set; }

        [StringLength(30)]
        public string Diemden { get; set; }

        public DateTime? Ngaydi { get; set; }

        public DateTime? Ngayve { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill_Detail> Bill_Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Khuvuc Khuvuc { get; set; }
    }
}
