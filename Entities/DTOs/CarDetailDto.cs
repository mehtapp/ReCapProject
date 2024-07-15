using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int CarId { get; set; }
        public string Description  { get; set; } //same with CarName
        public string BrandName { get; set; }
        public string ColourName { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
