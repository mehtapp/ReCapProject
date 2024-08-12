using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Core.DependencyResolvers;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

/* **************************************************  .net IoC Container ile yapýldý. Autofac 'e çekildi.   ****************************************** */
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // JWT için Security Definition ekleme
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token as 'Bearer {token}'",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    // Security Requirement ekleme
    c.AddSecurityRequirement(new OpenApiSecurityRequirement{
            {
                new OpenApiSecurityScheme{
                    Reference = new OpenApiReference{
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }});
});

//builder.Services.AddSingleton<IColourService, ColourManager>();
//builder.Services.AddSingleton<IColourDal, EfColourDal>();
//builder.Services.AddSingleton<IBrandService, BrandManager>();
//builder.Services.AddSingleton<IBrandDal, EfBrandDal>();
//builder.Services.AddSingleton<ICarSerCOLOvice, CarManager>();
//builder.Services.AddSingleton<ICarDal, EfCarDal>();
//builder.Services.AddSingleton<IIndividualCustomerService , IndividualCustomerManager>();
//builder.Services.AddSingleton<IIndividualCustomerDal, EfIndividualCustomerDal>();
//builder.Services.AddSingleton<ICorporateCustomerService, CorporateCustomerManager>();
//builder.Services.AddSingleton<ICorporateCustomerDal, EfCorporateCustomerDal>();
//builder.Services.AddSingleton<IRentalService , RentalManager>();
//builder.Services.AddSingleton<IRentalDal , EfRentalDal>();

//Artýk IoC Servici olarak WebAPI'de Autoc kullnacaðýmýzý belirttik*********************
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); biz autofac'i devreye soktuðumuz için bu giremedi.
var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true, //mehtapçcom tokenda bunu kontrole et
        ValidateAudience = true, //kotnrol et bunuda verdiðimle ayný mý
        ValidateLifetime = true, //TOKEN IN YAÞAM ÖMRÜNÜ KONTROL EDEYÝM MÝ SON TARÝH VS
        ValidIssuer = tokenOptions.Issuer,    //VALÝD ÝSSUER KÝM
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };
});
//ServiceTool.Create(builder.Services);
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterModule(new AutofacBusinessModel());
});


builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//angular adresimiz
app.UseCors(builder => builder.WithOrigins("http://localhost:4200/").AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
