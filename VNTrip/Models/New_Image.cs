namespace VNTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class New_Image
    {
        public int ID { get; set; }

        public int? ID_New { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        public virtual News News { get; set; }
    }
}
