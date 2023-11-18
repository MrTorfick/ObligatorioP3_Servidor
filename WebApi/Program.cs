using _EcosistemasMarinos.AccesoDatos.EntityFramework.SQL;
using _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso.Ecosistema_Marino;
using _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso.Especie_Marina;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Ecosistema_Marino;
using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Especie_Marina;
using EcosistemasMarinos.Interfaces_Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var rutaArchivo = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebApi.xml");


builder.Services.AddSwaggerGen(opciones =>
{
    //Se agrega la opcion de autenticarse en Swagger
    opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        Description = "Autorizacion estandar mediante esquema Bearer",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    opciones.OperationFilter<SecurityRequirementsOperationFilter>();

    //Se agregan las opciones para la documentación de swagger
    opciones.IncludeXmlComments(rutaArchivo);
    opciones.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Documentación de Obligatorio.Api",
        Description = "Aqui se encuentran todos los endpoint activos para utilizar los servicios del Obligatorio",
        Contact = new OpenApiContact
        {
            Email = "correo@correo.com"
        },
        Version = "v1"
    });
});

// Configurar de la autenticacion
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opciones =>
{
    opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:SecretTokenKey").Value!)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});


//Configurar la autorización
builder.Services.AddAuthorization(opciones =>
{
    opciones.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});


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
builder.Services.AddScoped<IObtenerPaisPorId, ObtenerPaisPorIdUC>();
builder.Services.AddScoped<IAddAuditoria, AddAuditoriaUC>();
builder.Services.AddScoped<IUpdateEspecieMarina, UpdateEspecieMarinaUC>();

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
