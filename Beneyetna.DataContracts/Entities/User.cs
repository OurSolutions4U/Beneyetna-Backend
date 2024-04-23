using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beneyetna.DataContracts.Entities
{
    [Table("User")]
    public class User : BaseEntity
    {
        public string? Email { set; get; }
        public string? Name { set; get; }


    }
}
