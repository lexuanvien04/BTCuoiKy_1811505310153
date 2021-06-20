namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [Key]
        [StringLength(50)]
        public string CategoryID { get; set; }

        [StringLength(100)]
        public string CategoryName { get; set; }

        [StringLength(100)]
        public string Description { get; set; }
    }
}
