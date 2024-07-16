using Core.Entities;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IUser, IEntity
    {
        //Her kullanıcı için gerekli temel property'ler bulunur.
        public int Id { get; set; }
        public string Email { get ; set; }
        public string Password { get; set ; }
        //public string UserName { get ; set; }
        //public bool Confirmation { get; set ; }

        
    }
}
