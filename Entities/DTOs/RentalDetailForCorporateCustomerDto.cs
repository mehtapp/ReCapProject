using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailForCorporateCustomerDto : IDto
    {
        public int Id { get; set; }
        public int CarBrandId { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public decimal DailyPrice { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
