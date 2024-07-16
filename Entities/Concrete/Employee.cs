using Core.Entities;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee : IUser,  IEntity  //Eksik var Ad ve Soyad ayrı bir interface te olmalı
    {
        public int EmployeeId { get; set; }
        public decimal Salary { get; set; }
        public int WeeklyWorkHour { get; set; }
        public DateTime StartedDate { get; set; }
        public int UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


}
