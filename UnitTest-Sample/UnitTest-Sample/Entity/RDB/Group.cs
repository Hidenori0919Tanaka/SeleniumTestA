using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UnitTest_Sample.Entity.RDB
{
    [Table("Group")]
    public class Group
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public virtual ICollection<M_User> M_Users { get; set; }

        public virtual ICollection<Fa> Fas { get; set; }
    }
}