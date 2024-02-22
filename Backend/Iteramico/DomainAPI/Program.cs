using DomainRepository;
using DomainService;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.RegisterDomainDbContext(builder.Configuration);

builder.Services.AddCors(o =>
{
    o.AddPolicy("CORS", opt =>
    {
        opt.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.RegisterDomainDbContext(builder.Configuration);
builder.Services.RegisterDomainRepositories();
builder.Services.RegisterDomainServices();

var app = builder.Build();

app.UseCors("CORS");

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