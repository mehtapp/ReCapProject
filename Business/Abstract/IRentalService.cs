using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult AddRentedCar(Rental rental); //Araç kiralama
        IResult DeleteRentedCar(Rental rental);
        IResult UpdateRentedCar(Rental rental);
        IDataResult<List<Rental>> GetAllRentedCars(); 
        
        
        IDataResult<List<Rental>> GetRentedCarById(int CarId);  // Kiralanmış teslim edilmiş ya da teslim edilmemiş aracı id ile çeker.

        IResult DeliverACarBack(Rental rental); //Aracının müşteri tarafından teslim edilmesi. teslim ettiği günün tarihi ile kaydedilecek.
        //IDataResult<List<Rental>> GetAvailableCarForRent(); //Şuanda kiralanabilir durumda araçlar.
        

    }
}
