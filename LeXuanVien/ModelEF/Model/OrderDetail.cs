namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string ProductID { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total { get; set; }

        [StringLength(10)]
        public string Description { get; set; }
    }
}
