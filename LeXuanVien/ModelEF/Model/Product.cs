namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string ProductID { get; set; }

        [StringLength(100)]
        public string ProductName { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitCost { get; set; }

        public int? Quantity { get; set; }

        public byte[] image { get; set; }

  

        [StringLength(50)]
        public string CategoryID { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public bool Status { get; set; }
    }
}
