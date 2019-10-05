using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowPets.Models
{
    public partial class Species
    {
        public Species()
        {
            Pet = new HashSet<Pet>();
        }

        public int SpeciesId { get; set; }
        [Required]
        [Column("Species")]
        [StringLength(50)]
        public string Species1 { get; set; }
        [StringLength(50)]
        public string Area { get; set; }
        [StringLength(10)]
        public string IsEndangered { get; set; }

        [InverseProperty("Species")]
        public virtual ICollection<Pet> Pet { get; set; }
    }
}
