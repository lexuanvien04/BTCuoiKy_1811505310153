namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string CustomerID { get; set; }

        public DateTime? OrderDate { get; set; }
    }
}
