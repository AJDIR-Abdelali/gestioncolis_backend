using GestioColis.Data;
using GestioColis.Repositories.Implementation;
using GestioColis.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<GestionColisContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddScoped<IClientRepo, ClientRepo>();
builder.Services.AddScoped<IProduitRepo, ProduitRepo>();
builder.Services.AddScoped<ILivreurRepo, LivreurRepo>();
builder.Services.AddScoped<IPaysRepo, PaysRepo>();
builder.Services.AddScoped<IVilleRepo, VilleRepo>();
builder.Services.AddScoped<ISecteurRepo, SecteurRepo>();
builder.Services.AddScoped<IAgenceRepo, AgenceRepo>();
builder.Services.AddScoped<IStatutRepo, StatutRepo>();
builder.Services.AddScoped<ICommandeRepo, CommandeRepo>();



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
