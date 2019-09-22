namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Good")]
    public partial class Good
    {
        public int GoodId { get; set; }

        [Required]
        [StringLength(100)]
        public string GoodName { get; set; }

        [Required]
        [StringLength(100)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        public int? CategoryId { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GoodCount { get; set; }

        public virtual Category Category { get; set; }
    }
}
