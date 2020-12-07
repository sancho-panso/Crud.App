using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Crud.App.Domains
{
    public enum Measures
    {
        piece,
        kg,
        mtr
    };
    public enum Packages
    {
        carton,
        bag
    };
    public enum Types
    {
        resale_Item,
        produced_Item,
        service
    };
    public class Item
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ItemID { get; set; }
        [Required]
        [ForeignKey("ItemsGroupID")]
        public Guid ItemsGroupID { get; set; }
        public ItemsGroup ItemsGroup { get; set; }
        [Required]
        [MaxLength(50)]
        public string ItemNomNr { get; set; }
        [Required]
        [MaxLength(50)]
        public string ItemName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ItemNameEN { get; set; }
        [Required]
        [MaxLength(50)]
        public string ItemNameRU { get; set; }
        [MaxLength(100)]
        public string ItemQR { get; set; }
        public Measures Measure { get; set; }
        public Packages Package { get; set; }
        public double Weight { get; set; }
        public Types Type { get; set; }
        [Required]
        public double Pricelist_A { get; set; }
        [Required]
        public double Pricelist_B { get; set; }
        [Required]
        public double Pricelist_C { get; set; }
        [Required]
        public double Pricelist_D { get; set; }
        public double WharehouseQNT { get; set; }
        public List<OrderedItem> OrderedItems { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModifiedDate { get; set; }



    }
}
