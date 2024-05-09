using ProjetoIntegrador.Application.Handler.User;
using ProjetoIntegrador.Config;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositories();

builder.Services.AddMediatR(x => {
    x.RegisterServicesFromAssembly(typeof(UpdateUserHandler).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseEnsureMigrations(builder.Configuration);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
