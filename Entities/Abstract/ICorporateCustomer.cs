using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface ICorporateCustomer : ICustomer
    {
        int Id { get; set; }
        string CompanyName { get; set; }
    }
}
