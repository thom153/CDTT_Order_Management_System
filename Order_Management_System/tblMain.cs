namespace Order_Management_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblMain")]
    public partial class tblMain
    {
        [Key]
        public int MainID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? aDate { get; set; }

        [StringLength(15)]
        public string aTime { get; set; }

        [StringLength(20)]
        public string TableName { get; set; }

        [StringLength(50)]
        public string WaiterName { get; set; }

        [StringLength(20)]
        public string status { get; set; }

        public double? total { get; set; }

        public double? received { get; set; }

        public double? change { get; set; }
    }
}
