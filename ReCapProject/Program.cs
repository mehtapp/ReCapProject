// See https://aka.ms/new-console-template for more information


using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Drawing;


Console.WriteLine("************  Kiralanabilecek araç listesi **********************");
CarManager carManager = new CarManager(new EfCarDal());
foreach (var car in carManager.GetCars())
{
    Console.WriteLine("Araç Id " + car.Id);
    Console.WriteLine("Brand Id " + car.BrandId);
    Console.WriteLine("Color Id " + car.ColorId);
    Console.WriteLine("Açıklama " + car.Description);
    Console.WriteLine("Model Yılı " + car.ModelYear.Year);
    Console.WriteLine("Günlük Kira Bedeli " + car.DailyPrice);

}



