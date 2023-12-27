using TestTask.Domain.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<IEntityService, EntityService>();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();