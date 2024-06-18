using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Repository;
using WebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();

builder.Services.AddScoped<AtletaRepository>();
// builder.Services.AddScoped<CategoriaRepository>();
// builder.Services.AddScoped<DisciplinaRepository>();
builder.Services.AddScoped<EventoRepository>();
// builder.Services.AddScoped<ModalidadRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("MyTestDb"))
);

var app = builder.Build();

var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

using (var scope = scopedFactory.CreateScope())
{
    var service = scope.ServiceProvider.GetService<Seed>();
    service.SeedDataContext();
}

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