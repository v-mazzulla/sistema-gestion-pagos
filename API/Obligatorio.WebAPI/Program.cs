
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Obligatorio.LogicaAccesoDatos;
using Obligatorio.LogicaAccesoDatos.Repositorios;
using Obligatorio.LogicaAplicacion.CasosUso.CUUsuario;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUUsuario;
using Obligatorio.LogicaAplicacion.CasosUso.CUPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUPago;
using Obligatorio.LogicaAplicacion.CasosUso.CUMetodoPago;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUMetodoPago;
using Obligatorio.LogicaAplicacion.CasosUso.CUTipoGasto;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUTipoGasto;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUAuditoria;
using Obligatorio.LogicaAplicacion.CasosUso.CUAuditoria;
using Obligatorio.LogicaAplicacion.ICasosUso.ICUEquipo;
using Obligatorio.LogicaAplicacion.CasosUso.CUEquipo;

namespace Obligatorio.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            
            builder.Services.AddScoped<IRepositorioPago, RepositorioPago>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGasto>();
            builder.Services.AddScoped<IRepositorioMetodoPago, RepositorioMetodoPago>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();
            builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipo>();

            builder.Services.AddScoped<ICUObtenerPago, CUObtenerPago>();
            builder.Services.AddScoped<ICUObtenerMetodosPago, CUObtenerMetodosPago>();
            builder.Services.AddScoped<ICUObtenerTiposGastos, CUObtenerTiposGastos>();
            builder.Services.AddScoped<ICULogin, CULogin>();
            builder.Services.AddScoped<ICUPagosUsuario, CUPagosUsuario>();
            builder.Services.AddScoped<ICUAltaPago, CUAltaPago>();
            builder.Services.AddScoped<ICUAuditoriasDeTipoGasto, CUAuditoriasDeTipoGasto>();
            builder.Services.AddScoped<ICUResetearContrasenia, CUResetearContrasenia>();
            builder.Services.AddScoped<ICUEquiposPagoUnicoMayor, CUEquiposPagoUnicoMayor>();



            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDistributedMemoryCache(); // almacén en memoria
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // tiempo de expiración
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            // Configuración JWT
            var jwtKey = builder.Configuration["Jwt:Key"];

            if (string.IsNullOrWhiteSpace(jwtKey))
            {
                throw new InvalidOperationException(
                    "No se encontró la clave de configuración 'Jwt:Key'.");
            }

            var signingKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey));


            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    //Definir las verificaciones a realizar
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = claveCodificada
                };
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            


            app.MapControllers();

            app.Run();
        }
    }
}
