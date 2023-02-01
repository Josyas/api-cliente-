using CadastroCliente.AutoMapper;
using CadastroCliente.Data;
using CadastroCliente.Interface;
using CadastroCliente.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICliente, ClienteRepositorio>();
builder.Services.AddScoped<IContato, ContatoRepositorio>();
builder.Services.AddScoped<IEndereco, EnderecoRepositorio>();
builder.Services.AddDbContext<AppDbContextCadastro>();
builder.Services.AddAutoMapper(typeof(EntitiesToDTOProfile));
builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
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

app.Run();
