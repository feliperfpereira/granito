var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.ConfigureKestrel(options => options.ListenLocalhost(8888));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Juros API v1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
