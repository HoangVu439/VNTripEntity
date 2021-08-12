namespace VNTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiPhongNN")]
    public partial class LoaiPhongNN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiPhongNN()
        {
            AnhLoaiPhongNNs = new HashSet<AnhLoaiPhongNN>();
            Bill_Detail = new HashSet<Bill_Detail>();
            Carts = new HashSet<Cart>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ID_NhaNghi { get; set; }

        [StringLength(50)]
        public string TenLoaiPhong { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price2h { get; set; }

        [Column(TypeName = "money")]
        public decimal? PriceNight { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnhLoaiPhongNN> AnhLoaiPhongNNs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill_Detail> Bill_Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual NhaNghi NhaNghi { get; set; }
    }
}
