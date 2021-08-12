namespace VNTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiPhongKS")]
    public partial class LoaiPhongK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiPhongK()
        {
            AnhLoaiPhongKS = new HashSet<AnhLoaiPhongK>();
            Bill_Detail = new HashSet<Bill_Detail>();
            Carts = new HashSet<Cart>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ID_KhachSan { get; set; }

        [StringLength(50)]
        public string TenLoaiPhong { get; set; }

        [StringLength(20)]
        public string SucChua { get; set; }

        [StringLength(20)]
        public string BuaAn { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [StringLength(500)]
        public string Utilities { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [Column(TypeName = "money")]
        public decimal? Promotion_Price { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnhLoaiPhongK> AnhLoaiPhongKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill_Detail> Bill_Detail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual KhachSan KhachSan { get; set; }
    }
}
