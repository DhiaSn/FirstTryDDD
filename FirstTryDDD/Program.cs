using FirstTryDDD.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext(builder.Configuration);

builder.Services.AddBussinessServices(); 

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opts => opts.AddPolicy("AllowAny", b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod())); 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

string[] origins = new string[]
{
    "http://localhost:4200"
};
 
app.UseCors(builder => builder.WithOrigins(origins).AllowAnyHeader().AllowAnyMethod()); 

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
