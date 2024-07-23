using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee : IEntity  //Eksik var Ad ve Soyad ayrı bir interface te olmalı
    {
        [Key]
        public int EmployeeId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        public decimal Salary { get; set; }
        public int WeeklyWorkHour { get; set; }
        public DateTime StartedDate { get; set; }
        public int UserId { get ; set; }
    
    }


}
