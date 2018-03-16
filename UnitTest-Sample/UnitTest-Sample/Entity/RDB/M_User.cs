using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using UnitTest_Sample.Models;

namespace UnitTest_Sample.Entity.RDB
{
    [Table("M_User")]
    public class M_User
    {
        public int M_UserId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}