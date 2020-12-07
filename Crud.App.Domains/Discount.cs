using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Crud.App.Domains
{
    public class Discount
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DiscountID { get; set; }
        [ForeignKey("ClientID")]
        public Client Client { get; set; }
        public Guid ClientID { get; set; }
        [ForeignKey("ClientGroupID")]
        public ClientGroup ClientGroup { get; set; }
        public Guid ClientGroupID { get; set; }
        [ForeignKey("ItemGroupID")]
        public ItemsGroup ItemGroup { get; set; }
        public Guid ItemGroupID { get; set; }
        [ForeignKey("ItemID")]
        public Item Item { get; set; }
        public Guid ItemID { get; set; }
        public double DiscountMultiplier { get; set; }
        public PricelistCode PricelictCode { get; set; }
    }

    public enum PricelistCode
    {
        A,B,C,D
    }
}
