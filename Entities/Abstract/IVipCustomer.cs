using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface IVipCustomer : ICustomer
    {
        int VipCustomerId { get; set; }
        string VipBenefits { get; set; }
    }
}
