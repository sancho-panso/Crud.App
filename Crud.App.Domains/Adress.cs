using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crud.App.Domains
{
    public class Adress
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [MaxLength(50)]
        public string Building { get; set; }
        [Required]
        [MaxLength(50)]
        public string Index { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        public Adress()
        {
            Guid ID = Guid.NewGuid();
        }

    }
}