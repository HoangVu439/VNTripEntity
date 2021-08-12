namespace VNTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int ID { get; set; }

        public int? ID_Customer { get; set; }

        public int? ID_LoaiPhongKS { get; set; }

        public int? ID_VeMayBay { get; set; }

        public int? ID_LoaiPhongNN { get; set; }

        public int? Quantity_Purchased { get; set; }

        public DateTime? created_at { get; set; }

        public DateTime? updated_at { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual LoaiPhongK LoaiPhongK { get; set; }

        public virtual LoaiPhongNN LoaiPhongNN { get; set; }

        public virtual VeMayBay VeMayBay { get; set; }
    }
}
