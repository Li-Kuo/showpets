using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShowPets.Models
{
    public partial class Pet
    {
        public int PetId { get; set; }
        public int SpeciesId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender { get; set; }
        [Required]
        [StringLength(10)]
        public string Color { get; set; }

        [ForeignKey("SpeciesId")]
        [InverseProperty("Pet")]
        public virtual Species Species { get; set; }
    }
}
