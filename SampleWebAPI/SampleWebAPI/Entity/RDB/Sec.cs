using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleWebAPI.Entity.RDB
{
    [Table("Sec")]
    public class Sec
    {
        [Key]
        public int SecId { get; set; }

        public int FaId { get; set; }

        [ForeignKey("FaId")]
        public virtual Fa Fa { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool DeleteFlag { get; set; }
    }
}