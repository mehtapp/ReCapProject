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
        IDataResult<List<Rental>> GetRentedCars(); // Eskiden kiralanmış ve teslim edilmiş, hala kiralık durumda olan araçları listeler.
        IDataResult<Rental> GetRentedCarById(int rentalId);  // Kiralanmış teslim edilmiş, teslim edilmemiş araçları id ile çeker.

        IResult DeliverACar(); //Araç teslim etme. teslim ettiği günün tarihi ile kaydedilecek.
        IDataResult<List<Rental>> GetAvailableCarForRent(); //Şuanda kiralanabilir durumda araçlar.
        

    }
}
