namespace Order_Management_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Item
    {
        public int itemID { get; set; }

        [StringLength(128)]
        public string iName { get; set; }

        public double? iPrice { get; set; }

        [StringLength(10)]
        public string iUnitCost { get; set; }

        public int? categoryID { get; set; }

        [Column(TypeName = "image")]
        public byte[] iImage { get; set; }

        public bool IsActive { get; set; }
    }
}
