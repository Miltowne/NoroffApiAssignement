using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appenix_B_01.Models
{
    /// <summary>
    /// model of highest customer spender
    /// </summary>
    public class CustomerSpender
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SqlDecimal Total { get; set; }

    }
}
