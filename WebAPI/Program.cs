using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

/* **************************************************  .net IoC Container ile yapýldý. Autofac 'e çekildi.   ****************************************** */
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IColourService, ColourManager>();
//builder.Services.AddSingleton<IColourDal, EfColourDal>();
//builder.Services.AddSingleton<IBrandService, BrandManager>();
//builder.Services.AddSingleton<IBrandDal, EfBrandDal>();
//builder.Services.AddSingleton<ICarService, CarManager>();
//builder.Services.AddSingleton<ICarDal, EfCarDal>();
//builder.Services.AddSingleton<IIndividualCustomerService , IndividualCustomerManager>();
//builder.Services.AddSingleton<IIndividualCustomerDal, EfIndividualCustomerDal>();
//builder.Services.AddSingleton<ICorporateCustomerService, CorporateCustomerManager>();
//builder.Services.AddSingleton<ICorporateCustomerDal, EfCorporateCustomerDal>();
//builder.Services.AddSingleton<IRentalService , RentalManager>();
//builder.Services.AddSingleton<IRentalDal , EfRentalDal>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
