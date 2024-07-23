using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class VipCustomer :  IEntity
    {
        [Key]
        public int VipCustomerId { get ; set; }
        
        public int UserId { get; set; }
        public string VipBenefits { get ; set ; }
     
        

    }
}
