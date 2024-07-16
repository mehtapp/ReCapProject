using Core.Entities;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class IndividualCustomer : IIndividualCustomer, IEntity
    {
        public int IndividualCustomerId { get; set; } //uniq data oluşturmak amaçlı eklenmiştir. Datalar çekilirken kalıtım aldığı Customer tablosundaki (müşteri) Id'si ile kullanılacaktır.
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Iındivudial , IUser , ICustomer propery
        public int CustomerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        



    }
}
