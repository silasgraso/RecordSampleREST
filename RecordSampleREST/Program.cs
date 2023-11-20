using Microsoft.EntityFrameworkCore;
using RecordSampleREST.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll", policy =>
    {
        policy.AllowAnyOrigin().
        AllowAnyMethod(). //HTTP Metoder
        AllowAnyHeader();
    });
});

bool useMusicRecordDB = true;
if (useMusicRecordDB)
{
    var optionBuilder = new DbContextOptionsBuilder<MusicRecordDBContext>();
    optionBuilder.UseSqlServer("Data Source = mssql9.unoeuro.com; Initial Catalog = fabgras_dk_db_elearning; Persist Security Info = True; User ID = fabgras_dk; Password = pm4txrcBHhnFfRakG25y; TrustServerCertificate = True");
    MusicRecordDBContext context = new MusicRecordDBContext(optionBuilder.Options);
    builder.Services.AddSingleton<IMusicRepository>(new MusicRecordrepositoryDB(context));
}
else
{
    builder.Services.AddSingleton<IMusicRepository>(new MusicRecordRepository());
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");


app.UseAuthorization();

app.MapControllers();

app.Run();
