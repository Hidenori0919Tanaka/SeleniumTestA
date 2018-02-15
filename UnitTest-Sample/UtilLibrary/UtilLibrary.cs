using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest_Sample.Models;

namespace UnitTest_Sample.UtilLibrary
{
    public sealed class UtilLibrary
    {
        public static ApplicationDbContext DbContext()
        {
            return new ApplicationDbContext();
        }
    }
}
