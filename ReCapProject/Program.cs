// See https://aka.ms/new-console-template for more information


using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Identity.Client;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http.Headers;




//Color Listing
//TestingForColours();


//Brand Testing
//TestingForBrands();

//Car testing
//TestingForCars();


//CorporateCustomer Testing
//TestingCorporateCustomer();


//IndividualCustomer Testing
//TestingForIndividualCustomer();

//NOTLAR rentdate ve returndate bugun olarak ayarlanmıştır.
//TestingRental();


static void Space()
{
    Console.WriteLine();
}


static void CallColours(ColourManager colourManager)
{
    var result = colourManager.GetColors();
    if (result.Data == null)
    {
        Console.WriteLine(result.Success + " " + result.Message);

    }
    else
    {
        foreach (var color in colourManager.GetColors().Data)
        {
            Console.WriteLine("{0} Id Numarına Sahip Renk : {1}", color.Id, color.Name);
        }

    }

}
Console.ReadKey();
static void CallBrands(BrandManager brandManager)
{
    foreach (var brand in brandManager.GetBrands().Data)
    {
        Console.WriteLine("{0} Id nolu brand  : {1} ", brand.Id, brand.Name);

    }
}
static void CallCarsWithDto(CarManager carManager)
{
    foreach (var car in carManager.GetCarDetails().Data)
    {
        Console.WriteLine(
            "Id     :  {0}\n" +
            "Ad     :  {1}\n" +
            "Marka  :  {2}\n" +
            "Renk   :  {3}\n" +
            "Günlük :  {4}TL", car.CarId, car.Description, car.BrandName, car.ColourName, car.DailyPrice);
        Console.WriteLine();
    }
}
static void TestingForColours()
{
    Console.WriteLine("************  Colour Testing **********************");
    Space();

    //listing
    ColourManager colourManager = new ColourManager(new EfColourDal());
    Console.WriteLine("Renkler Tablosu Listesi");
    CallColours(colourManager);
    //Console.ReadKey();
    Space();
    //Color Adding
    Console.WriteLine("Beyaz rengini ekliyoruz.");
    IResult result = colourManager.AddColour(new Colour { Name = "Beyaz" });
    Console.WriteLine(result.Success + " " + result.Message);



    //Console.ReadKey();

    CallColours(colourManager);

    //update Color
    Space();
    Console.WriteLine("Son İndexteki rengi güncelliyorum Listede olmayan bir renk yazarmısın.");
    string name = Console.ReadLine().Trim();
    Colour colour = new Colour { Id = colourManager.GetColors().Data.Last().Id, Name = name };
    Console.WriteLine();
    colourManager.UpdateColour(colour);
    Console.WriteLine("Liste Güncel");
    Space();
    CallColours(colourManager);

    Space();
    //Color  deleting + listing
    Console.WriteLine("Renkler listesi son elemanını silelim. Ve iki listeyi kıyaslayalım. Liste orjinal haline dönmüş olmalı");
    Colour deletedColour = colourManager.GetColors().Data.Last();
    IResult process = colourManager.DeleteColour(deletedColour);
    Console.WriteLine(process.Message);
    Space();
    Console.WriteLine("Yeni Listegri");
    CallColours(colourManager);

    //Getting a colour with its Id
    Space();
    Console.WriteLine("Son index'teki veriyi okuyorum. (GetColourByıd metodu ile)");
    int id = colourManager.GetColors().Data.Last().Id;
    Colour lastColour = colourManager.GetColourById(id).Data;
    Console.WriteLine(lastColour.Id + " " + lastColour.Name);

}

static void TestingForBrands()
{
    //Brand Listing

    Console.WriteLine("************************* Brand Testing ************************************");
    Space();

    BrandManager brandManager = new BrandManager(new EfBrandDal());
    Console.WriteLine("Brand listesi");
    CallBrands(brandManager);

    Space();

    //Adding and Listing
    Console.WriteLine("Yeni bir marka eklemek için bir marka ismi yaz.");
    string brandName = Console.ReadLine().Trim();
    Space();
    brandManager.AddBrand(new Brand { Name = brandName });
    CallBrands(brandManager);

    //Updating last brand and Get it by brand id
    Space();
    Console.WriteLine("Yeni eklenilen markayı güncellemek için farklı bir marka yazınız.");
    string updateBrandName = Console.ReadLine().Trim();

    brandManager.UpdateBrand(
        new Brand
        {
            Id = brandManager.GetBrands().Data.Last().Id,
            Name = updateBrandName
        });
    CallBrands(brandManager);

    Space();
    Console.WriteLine("GetById ile sadece son kayıt getiriliyor");
    IDataResult<Brand> brand = brandManager.GetBrandById(brandManager.GetBrands().Data.Last().Id);
    Console.WriteLine("{0} Id nolu brand  : {1} : ", brand.Data.Id, brand.Data.Name);

    Space();
    Console.WriteLine("Son kayıt silindi listenin ilk ve son hali aynı olmalı.");
    brandManager.DeleteBrand(brandManager.GetBrands().Data.Last());
    CallBrands(brandManager);
}

static void TestingForCars()
{
    Space();
    Console.WriteLine("************************** Car Testing ******************************************");
    Console.WriteLine("Car DTO ile Liste");
    Space();
    CarManager carManager = new CarManager(new EfCarDal());

    CallCarsWithDto(carManager);
    Space();

    Console.WriteLine("***** Araç Ekleme  ******");
    //brand Id'ye var olan ilk aracın brandIdsini attım.Rastgele bir sayı versem sistemde olmayan bir
    //bir  ıd olacaktı. 
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    ColourManager colourManager = new ColourManager(new EfColourDal());
    //adding + listing
    Random rnd = new Random();
    int year = rnd.Next(2000, 2024);
    carManager.AddCar(new Car
    {
        BrandId = brandManager.GetBrands().Data.First().Id,
        Description = "Senin eklediğin araç",
        ColorId = colourManager.GetColors().Data.First().Id,
        ModelYear = new DateTime(year, 01, 01),
        DailyPrice = 3900

    });
    CallCarsWithDto(carManager);

    Space();
    //updating + listing
    Console.WriteLine("**** Rastgele eklediğim aracın descriptionını değiştir.  ***** ");

    string carName = Console.ReadLine().Trim();
    Car UpdatedCar = carManager.GetCars().Data.Last();
    carManager.UpdateCar(new Car
    {
        Id = UpdatedCar.Id,
        Description = carName,
        BrandId = UpdatedCar.BrandId,
        ColorId = UpdatedCar.ColorId,
        DailyPrice = UpdatedCar.DailyPrice,
        ModelYear = UpdatedCar.ModelYear
    });
    Car selectedcar = carManager.GetCarById(UpdatedCar.Id).Data;
    Console.WriteLine("Aracın bilgisini aşağıdaki ad ile değiştirdin.");
    Console.WriteLine(
            "Id     :  {0}\n" +
            "Ad     :  {1}\n",
             selectedcar.Id, selectedcar.Description);

    Space();
    //deleting + listing
    Console.WriteLine(" **** Veritabanına son eklenen araç siliniyor. ****");
    carManager.DeleteCar(carManager.GetCars().Data.Last());
    CallCarsWithDto(carManager);

}

//static void TestingCorporateCustomer()
//{
//    CorporateCustomerManager corporateCustomerManager = new CorporateCustomerManager(new EfCorporateCustomerDal());
//    //Adding
//    IResult result = corporateCustomerManager.AddCorporateCustomer(
//     //new CorporateCustomerWithUserInfoDto { UserName = "kur123", Email = "kur@gmail.com", Password = "123", CorporateName = "Mehtap Butik" });
//     //new User { UserName = "kur123", Email = "kur@gmail.com", Password = "123" },
//     new CorporateCustomer { CompanyName = "Mehtap Butik" });
//    Console.WriteLine(result.Message);


//    //Deleting
//    IResult resultfordeleted = corporateCustomerManager.DeleteCorporateCustomer(
//        //new User { UserId = 4, UserName = "kur123", Email = "kur@gmail.com", Password = "123" },
//        new CorporateCustomer { UserId = 4, CorporateId = 2, CompanyName = "Mehtap Butik" });

//    Console.WriteLine(resultfordeleted.Message);

//    //Listing
//    IDataResult<List<CorporateCustomerWithUserInfoDto>> resultofCorporateCustomer = corporateCustomerManager.GetAllCorporateCustomer();
//    Console.WriteLine("*********************     Kurumsal Müşteri Listesi    ******************************");
//    foreach (var corporateCustomer in resultofCorporateCustomer.Data)
//    {

//        Console.WriteLine("UserId     : " + corporateCustomer.UserId);
//        Console.WriteLine("CustomerId : " + corporateCustomer.CorporateCustomerId);
//        Console.WriteLine("UserName   : " + corporateCustomer.UserName);
//        Console.WriteLine("Şirket Adı : " + corporateCustomer.CorporateName);
//        Console.WriteLine("Mail       : " + corporateCustomer.Email);
//    }
//}

//static void TestingForIndividualCustomer()
//{
//    IndividualCustomerManager individualCustomerManager = new IndividualCustomerManager(new EfIndividualCustomerDal());
//    IResult success = individualCustomerManager.AddIndividualCustomer(new User
//    {
//        UserName = "bireysel",
//        Email = "bir@xyz.com",
//        Password = "343"
//    },
//    new IndividualCustomer
//    {
//        FirstName = "Ali",
//        LastName = "cAN",

//    });
//    Console.WriteLine(success.Message);

//    IResult ICustDeleteresult = individualCustomerManager.DeleteIndividualCustomer(new User
//    {
//        UserId = 9,
//        UserName = "bireysel",
//        Email = "bir@xyz.com",
//        Password = "343"
//    },
//    new IndividualCustomer
//    {
//        UserId = 9,
//        IndividualCustomerId = 1,
//        FirstName = "Ali",
//        LastName = "cAN",

//    }
//    );
//    Console.WriteLine(ICustDeleteresult.Message);

//    IDataResult<List<IndividualCustomerWithUserInfoDto>> IndividualCustomersListResult = individualCustomerManager.GetAllIndividualCustomer();
//    Console.WriteLine("*********************************** Bireysel Müşteri     *********************************************");
//    foreach (var individualCustomer in IndividualCustomersListResult.Data)
//    {
//        Console.WriteLine("UserId     : " + individualCustomer.UserId);
//        Console.WriteLine("CustomerId : " + individualCustomer.IndividualCustomerId);
//        Console.WriteLine("UserName   : " + individualCustomer.UserName);
//        Console.WriteLine("Ad         : " + individualCustomer.FirstName);
//        Console.WriteLine("Soyad      : " + individualCustomer.LastName);
//        Console.WriteLine("Mail       : " + individualCustomer.Email);
//    }
//    Console.WriteLine(IndividualCustomersListResult.Message);
//}

static void TestingRental()
{
    RentalManager rentalManager = new RentalManager(new EfRentalDal());

    IResult AddRentalResult = rentalManager.AddRentedCar(new Rental
    {
        CarId = 15,
        RentDate = DateTime.Now,
        UserId = 3,


    });
    Console.WriteLine(AddRentalResult.Message);

    IResult deliveredCarBack = rentalManager.DeliverACarBack(new Rental
    {
        CarId = 1,
        RentDate = DateTime.Now,
        UserId = 10,
        Id = 1,

    });
    Console.WriteLine(deliveredCarBack.Message);

    var result = rentalManager.GetAllRentedCars().Data;
    Console.WriteLine("*");
    foreach (var rentedcar in result)
    {
        Console.WriteLine(rentedcar.Id);
        Console.WriteLine(rentedcar.CarId);
        Console.WriteLine(rentedcar.UserId);
        Console.WriteLine(rentedcar.RentDate);
        Console.WriteLine(rentedcar.ReturnDate);
    }
}