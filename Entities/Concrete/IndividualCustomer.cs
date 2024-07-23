using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class IndividualCustomer : IEntity
    {
        [Key]
        public int IndividualCustomerId { get; set; } //uniq data oluşturmak amaçlı eklenmiştir. Datalar çekilirken kalıtım aldığı Customer tablosundaki (müşteri) Id'si ile kullanılacaktır.
    
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //Iındivudial , IUser , ICustomer propery







    }
}
