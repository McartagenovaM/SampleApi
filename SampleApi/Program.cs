using SampleApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// Inyección de dependencias personalizadas
builder.Services.AddHttpClient<WeatherForecast>();
builder.Services.AddSingleton<DummyMathService>();
builder.Services.AddSingleton<DummyUserService>();
builder.Services.AddSingleton<DummyLogService>();

var app = builder.Build();

// Configurar Swagger en tiempo de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();