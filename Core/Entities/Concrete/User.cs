using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        //Her kullanıcı için gerekli temel property'ler bulunur.
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get ; set; }
        public string PasswordHash { get; set ; }
        public string PasswordSalt { get; set; }
        public string Status { get; set; }

       
        //public string UserName { get ; set; }
        //public bool Confirmation { get; set ; }


    }
}
