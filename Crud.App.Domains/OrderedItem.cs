using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.App.Domains
{
    public class OrderedItem
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
        public Guid OrderID{ get; set; }
        [Required]
        [ForeignKey("ItemID")]
        public Guid ItemID { get; set; }
        public Item Item { get; set; }
        [Required]
        public double Ordered_QNT { get; set; }
        [Required]
        public double Price { get; set; }
        public Guid DiscountID { get; set; }
    }
}