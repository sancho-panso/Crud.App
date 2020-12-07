using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.App.Domains
{
    public class Branch
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        [ForeignKey("ClientID")]
        public Guid ClientID { get; set; }
        public Client Client { get; set; }
        [MaxLength(50)]
        public string BranchName { get; set; }
        [Phone]
        public string Phone { get; set; }
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

        public Branch()
        {
            Guid ID = Guid.NewGuid();
        }

    }
}