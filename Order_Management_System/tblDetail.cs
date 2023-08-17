namespace Order_Management_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblDetail
    {
        [Key]
        public int DetailID { get; set; }

        public int? MainID { get; set; }

        public int? itemmID { get; set; }

        public int? qty { get; set; }

        public double? price { get; set; }

        public double? amount { get; set; }
    }
}
