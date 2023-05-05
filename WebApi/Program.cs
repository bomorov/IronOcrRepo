using WebApi.Interfaces;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOcrService, IronOcrService>();
builder.Services.AddScoped<ITextRecognitionService, TextRecognitionService>();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
  c.RoutePrefix = string.Empty;
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "IronOCR test");
});

app.UseHttpsRedirection();

app.UseRouting();

app.MapControllers();

app.Run();
