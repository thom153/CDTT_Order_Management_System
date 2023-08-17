namespace Order_Management_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class table
    {
        [Key]
        public int tid { get; set; }

        [StringLength(10)]
        public string tname { get; set; }

        public int? tchair { get; set; }

        [StringLength(20)]
        public string tstatus { get; set; }
    }
}
