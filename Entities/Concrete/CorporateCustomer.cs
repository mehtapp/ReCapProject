using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CorporateCustomer : IEntity
    {
        [Key]
        public int CorporateId { get; set; }
       
        public string CompanyName { get; set; }

        // IUser ve ICustomer Propertyleri

        public int UserId { get; set; }
        //public User CurrentUser { get; set; }      // 

    }
}
