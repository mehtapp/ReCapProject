// See https://aka.ms/new-console-template for more information


using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;
using System.Drawing;

ICarService carManager = new CarManager(new InMemoryCarDal());

Console.WriteLine("********** Mevcut Kiralık Araç Listesi ************");
CallCarList();



Console.WriteLine("Hadi Bir araç eklemek için space tuşuna bas.");
Console.ReadKey();
Console.Clear();

carManager.AddCar(new Car { Id = 100, BrandId = 23, ColorId = 9, DailyPrice = 1000, Description = "Şahin", ModelYear = new DateTime(2024, 01, 01) });
Console.WriteLine("*************  Ekleme işlemini aldık. Sisteme senin için bir şahin ekliyorum." +
    " Araçları listelemek için space'e bas. Eklenip eklenmediğini kontrol et. *****************");
Console.ReadKey();
CallCarList();



Console.WriteLine("************* Şimdi Space'le ve senin eklediğin Aracı bir BMW'ye çevirelim  *****************");
Console.ReadKey();
Car car = carManager.GetAllCars().Last<Car>();
car.Description = "BMW";
carManager.UpdateCar(car);




Console.WriteLine("Şuan Şahin tanımlı araç BMW'ye çevrildi. Space'le ve Sadece güncellediğin aracı görüntüle.");
Console.ReadKey();

var UpdatedCar = carManager.GetCarById(car.Id);
Console.WriteLine("Araç Id  : " + car.Id);
Console.WriteLine("Araç BrandId " + car.BrandId);
Console.WriteLine("Renk " + car.ColorId);
Console.WriteLine("Açıklama " + car.Description);
Console.WriteLine("Yıl " + (car.ModelYear).Year);
Console.WriteLine();




Console.WriteLine("Tebrikler. Son adım. Lütfen eklediğin aracı sistemimizden silmek ve orjinal listeyi görmek için son bir kez space'le");
Console.ReadKey();

Car deletedCar = carManager.GetAllCars().Last<Car>();
carManager.DeleteCar(deletedCar);
CallCarList();







void CallCarList()
{
    foreach (var car in carManager.GetAllCars())
    {
        Console.WriteLine("Araç Id : " + car.Id);
        Console.WriteLine("Araç BrandId " + car.BrandId);
        Console.WriteLine("Renk " + car.ColorId);
        Console.WriteLine("Açıklama " + car.Description);
        Console.WriteLine("Yıl " + (car.ModelYear).Year);
        Console.WriteLine();
    }
}