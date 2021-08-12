namespace VNTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachSan")]
    public partial class KhachSan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachSan()
        {
            LoaiPhongKS = new HashSet<LoaiPhongK>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? ID_Khuvuc { get; set; }

        [StringLength(50)]
        public string Group_Pro { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        public int? Phone_Number { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        [StringLength(500)]
        public string Utilities { get; set; }

        [StringLength(200)]
        public string Thongtin { get; set; }

        [StringLength(20)]
        public string Checkin { get; set; }

        [StringLength(20)]
        public string Checkout { get; set; }

        [StringLength(100)]
        public string Image { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoaiPhongK> LoaiPhongKS { get; set; }

        public virtual Khuvuc Khuvuc { get; set; }
    }
}
