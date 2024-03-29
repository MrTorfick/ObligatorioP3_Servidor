using _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL;
using _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso.Ecosistema_Marino;
using _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso.Especie_Marina;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Ecosistema_Marino;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Especie_Marina;
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
            builder.Services.AddScoped<IRepositorioConfiguracion, RepositorioConfiguracion>();
            builder.Services.AddScoped<IRepositorioPais, RepositorioPais>();
            builder.Services.AddScoped<IRepositorioAuditoria, RepositorioAuditoria>();


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
            builder.Services.AddScoped<IObtenerEcosistemaMarinoPorId, ObtenerEcosistemaMarinoPorIdUC>();
            builder.Services.AddScoped<IAddEspecieMarina, AddEspecieMarinaCU>();
            builder.Services.AddScoped<IObtenerConfiguraciones, ObtenerConfiguracionesUC>();
            builder.Services.AddScoped<IUpdateConfiguracion, UpdateConfiguracionUC>();
            builder.Services.AddScoped<IObtenerConfiguracionPorNombre, ObtenerConfiguracionPorNombreUC>();
            builder.Services.AddScoped<IBorrarEcosistemaMarino, BorrarEcosistemaMarinoUC>();
            builder.Services.AddScoped<IObtenerEspecieMarinaPorId, ObtenerEspecieMarinaPorIdUC>();
            builder.Services.AddScoped<IAsociarEspecieEcosistema, AsociarEspecieAEcosistemaUC>();
            builder.Services.AddScoped<IObtenerEspecieMarinaPorNombreCientifico, ObtenerEspecieMarinaPorNombreCientificoUC>();
            builder.Services.AddScoped<IObtenerEspecieMarinaPorRangoPeso, ObtenerEspecieMarinaPorRangoDePesoUC>();
            builder.Services.AddScoped<IObtenerEcosistemasMarinosNoPuedenHabitarEspecies, ObtenerEcosistemasMarinosNoPuedenHabitarEspeciesUC>();
            builder.Services.AddScoped<IBuscarEspeciesQueHabitanUnEcosistema, BuscarEspeciesQueHabitanUnEcosistemaUC>();
            builder.Services.AddScoped<IBuscarEspeciesEnPeligroDeExtincion, BuscarEspeciesEnPeligroDeExtincionUC>();
            builder.Services.AddScoped<IObtenerPaises, ObtenerPaisesUC>();
            builder.Services.AddScoped<IUpdateEcosistemaMarino, UpdateEcosistemaMarinoUC>();
            builder.Services.AddScoped<IObtenerPaisPorISO, ObtenerPaisPorISOUC>();
            builder.Services.AddScoped<IAddAuditoria, AddAuditoriaUC>();
            builder.Services.AddScoped<IUpdateEspecieMarina, UpdateEspecieMarinaUC>();

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
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}