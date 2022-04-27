using Api.Configurations;
using Api.Data;
using Api.DependencyInjection;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.AddConfigurations();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddServices();
builder.Services.AddAuthService(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.EnableFilter();
    c.DisplayRequestDuration();
    //c.IndexStream = () => GetType().Assembly.GetManifestResourceStream("CustomUIIndex.Swagger.index.html");
    c.InjectStylesheet("/swagger-ui/custom.css");
    //c.InjectStylesheet(typeof(SwaggerConfig).Assembly,
    //  "ProjectName.FolderName.SwaggerHeader.css"));
});

app.UseCors(x=>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
