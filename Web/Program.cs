using _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL;
using _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Interfaces_Repositorios;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //inicializacion de repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioEcosistemaMarino, RepositorioEcosistemaMarino>();
            builder.Services.AddScoped<IRepositorioEstadoConservacion, RepositorioEstadoConservacion>();
            builder.Services.AddScoped<IRepositorioEspecieMarina, RepositorioEspecieMarina>();
            builder.Services.AddScoped<IRepositorioAmenaza, RepositorioAmenaza>();

            //inicializacion de casos de uso
            builder.Services.AddScoped<IAddUsuario, AddUsuarioCU>();
            builder.Services.AddScoped<IObtenerUsuarioPorCredenciales, ObtenerUsuarioPorCredencialesCU>();
            builder.Services.AddScoped<IAddEcosistemaMarino, AddEcosistemaMarinoCU>();
            builder.Services.AddScoped<IObtenerEcosistemasMarinos, ObtenerEcosistemasMarinosUC>();
            builder.Services.AddScoped<IAddEstadoConservacion, AddEstadoConservacionCU>();
            builder.Services.AddScoped<IObtenerEspeciesMarinas, ObtenerEspeciesMarinasUC>();
            builder.Services.AddScoped<IObtenerEstadosConservacion, ObtenerEstadosConservacionCU>();
            builder.Services.AddScoped<IObtenerEstadoConservacionPorId, ObtenerEstadoConservacionIdUC>();
            builder.Services.AddScoped<IObtenerAmenazas, ObtenerAmenazasUC>();
            builder.Services.AddScoped<IObtenerAmenazaPorId, ObtenerAmenazaPorIdUC>();
            builder.Services.AddScoped<IUpdateAmenaza, UpdateAmenazaCU>();

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

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}