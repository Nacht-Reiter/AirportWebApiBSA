using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AirportWebApiBSA.DAL.Models
{
    public class Crew : Interfaces.IModel
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Pilot")]
        public int PilotId { get; set; }
        public virtual Pilot Pilot { get; set; }
        public virtual IEnumerable<Stewardess> Stewardesses { get; set; }

        public Crew()
        {
            Stewardesses = new List<Stewardess>();
        }
    }
}
