using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.App.Domains
{
    public class Client
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [MaxLength(50)]
        public List<Branch> Branches { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string BussinessID { get; set; }
        [Required]
        [MaxLength(50)]
        public string VAT_ID { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [ForeignKey("AdressID")]
        public Adress Adress { get; set; }
        public Guid AdressID { get; set; }
        [Required]
        [ForeignKey("DeliveryAdressID")]
        public Adress DeliveryAdress { get; set; }
        public Guid DeliveryAdressID { get; set; }
        public double CreditLimit { get; set; }
        [Required]
        public PricelistCode PricelistCode { get; set; }
        [Required]
        [ForeignKey("ClientsGroupID")]
        public ClientGroup Group { get; set; }
        public Guid ClientsGroupID { get; set; }
        public List<Order> ClientsOrders { get; set; }

        public Client()
        {
            Guid ID = Guid.NewGuid();
            Branches = new List<Branch>();
            ClientsOrders = new List<Order>();
        }

    }
}