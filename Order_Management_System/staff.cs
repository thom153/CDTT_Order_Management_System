namespace Order_Management_System
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("staff")]
    public partial class staff
    {
        public int staffID { get; set; }

        [StringLength(50)]
        public string sName { get; set; }

        [StringLength(3)]
        public string sGender { get; set; }

        [StringLength(10)]
        public string sPhone { get; set; }

        [StringLength(50)]
        public string sAddress { get; set; }

        [StringLength(20)]
        public string sRole { get; set; }
    }
}
