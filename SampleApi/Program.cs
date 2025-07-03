using SampleApi.Services;

var builder = WebApplication.CreateBuilder(args);

//establecer el puerto para Kestrel
//builder.WebHost.ConfigureKestrel(options =>
//{
//    options.ListenAnyIP(7241); // Escucha en http://0.0.0.0:7241 dentro del contenedor
//});


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
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();