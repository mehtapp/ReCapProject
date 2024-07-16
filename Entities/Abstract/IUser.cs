using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    public interface IUser
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       // public string UserName { get; set; } //Üye olan herkes için ortak
       // public bool Confirmation { get; set; }
    }
}
