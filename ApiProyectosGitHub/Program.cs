using ApiProyectosGitHub.Data;
using ApiProyectosGitHub.Servicios;
using ApiProyectosGitHub.Servicios.Implementacion;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Inyeccion Dependencias:
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServicioCRUD, ServicioCRUD>();

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<DataContext>();
//    db.Database.Migrate();
//}

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
