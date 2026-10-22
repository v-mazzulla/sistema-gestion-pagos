using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaAccesoDatos;
using Obligatorio.LogicaAccesoDatos.Repositorios;
using Obligatorio.LogicaAplicacion.CasosUso.CUEquipo;
using Obligatorio.LogicaAplicacion.CasosUso.CUMetodoPago;
using Obligatorio.LogicaAplicacion.CasosUso.CUPago;
using Obligatorio.LogicaAplicacion.CasosUso.CURolUsuario;
using Obligatorio.LogicaAplicacion.CasosUso.CUTipoGasto;
using Obligatorio.LogicaAplicacion.CasosUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUMetodoPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICURolUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar la cadena de conexión (desde appsettings.json)
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //DefaultConnection debe coincidir con el nombre designado en el JSON.

            // Registrar el DbContext en el contenedor de servicios
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();




            //ID Repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGasto>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();
            builder.Services.AddScoped<IRepositorioRolUsuario, RepositorioRolUsuario>();
            builder.Services.AddScoped<IRepositorioPago, RepositorioPago>();
            builder.Services.AddScoped<IRepositorioMetodoPago, RepositorioMetodoPago>();




            //ID Casos Uso
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddScoped<ICUAltaTipoGasto, CUAltaTipoGasto>();
            builder.Services.AddScoped<ICUObtenerTiposGastos, CUObtenerTiposGastos>();
            builder.Services.AddScoped<ICUObtenerTipoGasto, CUObtenerTipoGasto>();
            builder.Services.AddScoped<ICUEditarTipoGasto, CUEditarTipoGasto>();
            builder.Services.AddScoped<ICUEliminarTipoGasto, CUEliminarTipoGasto>();
            builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
            builder.Services.AddScoped<ICUObtenerEquipos, CUObtenerEquipos>();
            builder.Services.AddScoped<ICUObtenerRoles, CUObtenerRoles>();
            builder.Services.AddScoped<ICUAltaPago, CUAltaPago>();
            builder.Services.AddScoped<ICUObtenerMetodosPago, CUObtenerMetodosPago>();
            builder.Services.AddScoped<ICUObtenerPagosMes, CUObtenerPagosMes>();
            builder.Services.AddScoped<ICUUsuariosXMontoPago, CUUsuariosXMontoPago>();





            builder.Services.AddSession();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Auth}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
