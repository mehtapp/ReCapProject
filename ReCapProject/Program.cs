// See https://aka.ms/new-console-template for more information


using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Drawing;


Console.WriteLine("************  Colour Testing **********************");

//Color Listing
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
string name =  Console.ReadLine().Trim();
Colour colour = new Colour {Id = colourManager.GetColors().First().Id,  Name = name };
Console.WriteLine();
colourManager.UpdateColour(colour);
CallColours(colourManager);



Space();
Console.WriteLine("BRAND");
































static void CallColours(ColourManager colourManager)
{
    foreach (var color in colourManager.GetColors())
    {
        Console.WriteLine("{0} Id Numarına Sahip Renk : {1}", color.Id, color.Name);
    }
}

static void Space()
{
    Console.WriteLine();
}