using Microsoft.EntityFrameworkCore;
using SistemaVentas.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddControllersWithViews();

// Añadir soporte de sesión
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Configuración del DbContext para usar la cadena de conexión de `appsettings.json`
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configuración del pipeline de solicitudes HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // Activar el uso de sesiones
app.UseAuthorization();

// Configuración de la ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Duración de la sesión: 30 minutos
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

app.UseSession(); // Añadir esto en la pipeline de middleware
