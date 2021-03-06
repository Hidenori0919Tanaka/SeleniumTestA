﻿using SampleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SampleWebAPI.Entity.RDB
{
    [Table("Fa")]
    public class Fa
    {
        public int FaId { get; set; }

        public string FaName { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public bool DeleteFlag { get; set; }
    }
}