var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var corsPolicyName = "frontPolicy";
builder.Services.AddCors(
  options => options.AddPolicy(
  name: corsPolicyName, 
  b => 
  {
    b.WithOrigins(builder.Configuration.GetSection("CORS:Origins").Get<string[]>())
    .WithHeaders(builder.Configuration.GetSection("CORS:Headers").Get<string[]>())
    .WithMethods(builder.Configuration.GetSection("CORS:Methods").Get<string[]>());
  }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(corsPolicyName);

app.Run();
