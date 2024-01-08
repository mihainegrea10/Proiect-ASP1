using Microsoft.EntityFrameworkCore;
using Proiect_ASP.Data;
using Proiect_ASP1.Helper;
using Proiect_ASP1.Helper.Extensions;
using Proiect_ASP1.Helper.Middleware;
using Proiect_ASP1.Helper.Seeders;
using Proiect_ASP1.Repositories.ImpresarRepository;
using Proiect_ASP1.Services.DemoService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSeeders();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.Run();



void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        // Seed pentru antrenori
        var antrenorSeeder = scope.ServiceProvider.GetService<AntrenorSeeder>();
        antrenorSeeder.SeedInitialAntrenori();

        // Seed pentru jucãtori
        var jucatorSeeder = scope.ServiceProvider.GetService<JucatorSeeder>();
        jucatorSeeder.SeedInitialJucatori();

        var impresarSeeder = scope.ServiceProvider.GetService<ImpresarSeeder>();
        impresarSeeder.SeedInitialImpresari();

        var echipaSeeder = scope.ServiceProvider.GetService<EchipaSeeder>();
        echipaSeeder.SeedInitialEchipai();

    }
}


