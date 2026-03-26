using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Antiforgery;

namespace PersonsApp.Entites
{
    [Table("persons")]
    public class PersonEntity : BaseEntity
    {
        [Required()]
        [StringLength(13)]
        [Column("dni")]
        public string DNI { get; set; }

        [Required()]
        [StringLength(50)]
        [Column("first_name")]
        public string FirstName { get; set; }

        [Required()]
        [StringLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        
        [Column("gender")]
        public string Gender { get; set; }

        [Column("country_id")]
        [Required()]
        public string CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual CountryEntity Country { get; set; }
    }
}