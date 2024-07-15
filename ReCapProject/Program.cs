// See https://aka.ms/new-console-template for more information


using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Drawing;
using System.Net.Http.Headers;




//Color Listing
TestingForColours();

//Brand Testing
TestingForBrands();

//Car testing
TestingForCars();




static void Space()
{
    Console.WriteLine();
}


static void CallColours(ColourManager colourManager)
{
    foreach (var color in colourManager.GetColors())
    {
        Console.WriteLine("{0} Id Numarına Sahip Renk : {1}", color.Id, color.Name);
    }
}

static void CallBrands(BrandManager brandManager)
{
    foreach (var brand in brandManager.GetBrands())
    {
        Console.WriteLine("{0} Id nolu brand  : {1} ", brand.Id, brand.Name);

    }
}
static void CallCarsWithDto(CarManager carManager)
{
    foreach (var car in carManager.GetCarDetails())
    {
        Console.WriteLine("{0} : ıd nolu {1} \n{2} : markalı \n{3} : renge sahip \n" +
            "aracın günlük ücreti : {4}'tür", car.CarId, car.Description, car.BrandName, car.ColourName, car.DailyPrice);
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

    Space();
    //Color Adding
    Console.WriteLine("Beyaz rengini ekliyoruz.");
    colourManager.AddColour(new Colour { Name = "Mavi" });
    CallColours(colourManager);

    //update Color
    Space();
    Console.WriteLine("Son İndexteki rengi güncelliyorum Listede olmayan bir renk yazarmısın.");
    string name = Console.ReadLine().Trim();
    Colour colour = new Colour { Id = colourManager.GetColors().Last().Id, Name = name };
    Console.WriteLine();
    colourManager.UpdateColour(colour);
    Console.WriteLine("Liste Güncel");
    Space();
    CallColours(colourManager);

    Space();
    //Color  deleting + listing
    Console.WriteLine("Renkler listesi son elemanını silelim. Ve iki listeyi kıyaslayalım. Liste orjinal haline dönmüş olmalı");
    colourManager.DeleteColour(colourManager.GetColors().Last());
    Space();
    Console.WriteLine("Yeni Liste");
    CallColours(colourManager);

    //Getting a colour with its Id
    Space();
    Console.WriteLine("Son index'teki veriyi okuyorum. (GetColourByıd metodu ile)");
    int id = colourManager.GetColors().Last().Id;
    Colour lastColour = colourManager.GetColourById(id);
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
            Id = brandManager.GetBrands().Last().Id,
            Name = updateBrandName
        });
    CallBrands(brandManager);

    Space();
    Console.WriteLine("GetById ile sadece son kayıt getiriliyor");
    Brand brand = brandManager.GetBrandById(brandManager.GetBrands().Last().Id);
    Console.WriteLine("{0} Id nolu brand  : {1} : ", brand.Id, brand.Name);

    Space();
    Console.WriteLine("Son kayıt silindi listenin ilk ve son hali aynı olmalı.");
    brandManager.DeleteBrand(brandManager.GetBrands().Last());
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

    Console.WriteLine("Car Ekleme");
    //brand Id'ye var olan ilk aracın brandIdsini attım.Rastgele bir sayı versem sistemde olmayan bir
    //bir  ıd olacaktı. 
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    ColourManager colourManager = new ColourManager(new EfColourDal());
    //adding + listing
    Random rnd = new Random();
    int year = rnd.Next(2000, 2024);
    carManager.AddCar(new Car
    {
        BrandId = brandManager.GetBrands().First().Id,
        Description = "Araç Description bla bla",
        ColorId = colourManager.GetColors().First().Id,
        ModelYear = new DateTime(year, 01, 01),
        DailyPrice = 3900

    });
    CallCarsWithDto(carManager);

    Space();
    //updating + listing
    Console.WriteLine("Rastgele eklediğim aracın descriptionını değiştir. ");
    string carName = Console.ReadLine().Trim();
    Car UpdatedCar = carManager.GetCars().Last();
    carManager.UpdateCar(new Car
    {
        Id = UpdatedCar.Id,
        Description = carName,
        BrandId = UpdatedCar.BrandId,
        ColorId = UpdatedCar.ColorId,
        DailyPrice = UpdatedCar.DailyPrice,
        ModelYear = UpdatedCar.ModelYear
    });
    CallCarsWithDto(carManager);

    Space();
    //deleting + listing
    Console.WriteLine("Veritabanına son elenen araç siliniyor.");
    carManager.DeleteCar(carManager.GetCars().Last());
    CallCarsWithDto(carManager);
    
}