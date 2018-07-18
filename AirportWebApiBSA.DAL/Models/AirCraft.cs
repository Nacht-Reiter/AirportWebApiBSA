using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    public class AirCraft : Interfaces.IModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("AirCraftType")]
        public int AirCraftTypeId { get; set; }
        public virtual AirCraftType AirCraftType { get; set; }
        public DateTime Manufactured { get; set; }
        public int Age { get; set; }
    }
}
