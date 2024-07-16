using Core.Entities;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class VipCustomer : IVipCustomer, IUser, IEntity
    {
        public int VipCustomerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string VipBenefits { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CustomerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
