namespace VNTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnhLoaiPhongKS")]
    public partial class AnhLoaiPhongK
    {
        public int ID { get; set; }

        public int? ID_LoaiPhongKS { get; set; }

        [StringLength(50)]
        public string TenLoaiPhong { get; set; }

        [StringLength(100)]
        public string Image1 { get; set; }

        [StringLength(100)]
        public string Image2 { get; set; }

        [StringLength(100)]
        public string Image3 { get; set; }

        [StringLength(100)]
        public string Image4 { get; set; }

        [StringLength(100)]
        public string Image5 { get; set; }

        public virtual LoaiPhongK LoaiPhongK { get; set; }
    }
}
