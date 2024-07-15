// See https://aka.ms/new-console-template for more information


using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Diagnostics;
using System.Drawing;




//Color Listing
//TestingForColours();

//TestingForBrands();

//Car testing
Console.WriteLine("Car dto ile istenen veriler");


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
        Console.WriteLine("{0} Id nolu brand  : {1} : ", brand.Id, brand.Name);

    }
}

static void TestingForColours()
{
    Console.WriteLine("************  Colour Testing **********************");
    ColourManager colourManager = new ColourManager(new EfColourDal());
    Console.WriteLine("Renkler Tablosu Listesi");
    CallColours(colourManager);

    //Color  deleting + listing
    Console.WriteLine("Renkler listesi son elemanını silelim. Ve iki listeyi kıyaslayalım.");
    colourManager.DeleteColour(colourManager.GetColors().Last());
    Space();
    Console.WriteLine("Yeni Liste");
    CallColours(colourManager);

    //Color Adding
    Console.WriteLine("Yeni bir renk kaydı ekliyoruz.");
    Space();
    colourManager.AddColour(new Colour { Name = "Pembe" });
    CallColours(colourManager);


    //Getting a colour with its Id
    Space();
    Console.WriteLine("Son index'teki veriyi okuyorum.");
    colourManager.GetColourById(colourManager.GetColors().Last().Id);
    Console.WriteLine(colourManager.GetColourById(colourManager.GetColors().Last().Id));

    Space();
    Console.WriteLine("İlk İndexteki rengi güncelliyorum Listede olmayan bir renk yazarmısın.");
    string name = Console.ReadLine().Trim();
    Colour colour = new Colour { Id = colourManager.GetColors().First().Id, Name = name };
    Console.WriteLine();
    colourManager.UpdateColour(colour);
    CallColours(colourManager);
}

static void TestingForBrands()
{
    //Brand Listing
    Space();
    Console.WriteLine("BRAND");
    BrandManager brandManager = new BrandManager(new EfBrandDal());
    Console.WriteLine("Brand listesi");
    CallBrands(brandManager);

    //Adding and Listing
    Space();
    Console.WriteLine("Yeni bir marka eklemek için bir marka ismi yaz.");
    string brandName = Console.ReadLine().Trim();
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
    Console.WriteLine("Son kayıt silinmiş hali");
    brandManager.DeleteBrand(brandManager.GetBrands().Last());
    CallBrands(brandManager);
}