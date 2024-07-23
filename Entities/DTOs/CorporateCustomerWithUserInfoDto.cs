using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CorporateCustomerWithUserInfoDto : IDto
    {
        public int UserId { get; set; }
        public int CorporateCustomerId { get; set; }
        public string CorporateName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
