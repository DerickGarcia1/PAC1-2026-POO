using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PersonsApp.Entites
{
    public class BaseEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        //audit fields
        [Column("created_by_id")]
        public string CreatedById { get; set; }

         [Column("created_date")]
        public DateTime CreateDate { get; set; }

        [Column("update_by_id")]
        public string UpdatedById { get; set; }

         [Column("update_date")]
        public DateTime UpdateDate { get; set; }
    }
}