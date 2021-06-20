namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [StringLength(50)]
        public string CustomerID { get; set; }

        [StringLength(100)]
        public string CustomerName { get; set; }

        public bool? Sex { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [StringLength(100)]
        public string Address { get; set; }
    }
}
