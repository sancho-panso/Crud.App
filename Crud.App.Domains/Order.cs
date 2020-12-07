using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Text;

namespace Crud.App.Domains
{
    public class Order
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderID { get; set; }
        [Required]
        [MaxLength(50)]
        public string OrderNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderData { get; set; }
        public Adress DeliveryAdress { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        [Required]
        [ForeignKey("ClientID")]
        public Client Client { get; set; }
        public Guid ClientID { get; set; }
        [ForeignKey("BranchID")]
        public Branch Branch { get; set; }
                public Guid? BranchID { get; set; }
        [Required]
        [MaxLength(50)]
        public List<OrderedItem> OrderedItems { get; set; }
        [Required]
        public Status OrderStatus { get; set; }
    }

    public enum Status
    {
        placed,
        confirmed,
        paid_in_advance,
        delivered_unpaid,
        delivered_paid
    }
}
