using EcosistemasMarinos.Excepciones;
using EcosistemasMarinos.Interfaces_Repositorios;
using EcosistemasMarinos.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Entidades
{
    public class EcosistemaMarino
    {
        [Key]
        public int Id { get; set; }
        // [Required, StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; }
        public Coordenadas Coordenadas { get; set; }
        [Required]
        public double Area { get; set; }
        [Required]
        public string DescripcionCaracteristicas { get; set; }
        public List<Imagen> Imagen { get; set; }
        public List<EspecieMarina> EspeciesHabitan { get; set; }

        public List<AmenazasAsociadas> Amenazas { get; set; }
        public Pais pais { get; set; }
        [ForeignKey(nameof(EstadoConservacion))] public int? EstadoConservacionId { get; set; }
        public EstadoConservacion? EstadoConservacion { get; set; }
        public EcosistemaMarino() { }

        public void Validar(IRepositorioConfiguracion configuracion)
        {

            if (string.IsNullOrEmpty(Nombre))
                throw new Exception("El nombre no puede ser nulo ni vacío");

            if (Area <= 0)
                throw new Exception("El área debe ser mayor a 0");

            if (Nombre.Length < configuracion.GetTopeInferior("EcosistemaNombre"))
            {
                throw new RangoValoresException("Nombre demasiado corto");
            }

            if (Nombre.Length > configuracion.GetTopeSuperior("EcosistemaNombre"))
            {
                throw new RangoValoresException("Nombre demasiado largo");
            }

            if (DescripcionCaracteristicas.Length < configuracion.GetTopeInferior("EcosistemaDescripcion"))
            {
                throw new RangoValoresException("Descripcion demasiado corta");
            }

            if (DescripcionCaracteristicas.Length > configuracion.GetTopeSuperior("EcosistemaDescripcion"))
            {
                throw new RangoValoresException("Descripcion demasiado larga");
            }
            if (Coordenadas == null)
            {
                throw new Exception("Las coordenadas no pueden ser nulas");
            }
            if (Imagen.Count == 0)
            {
                throw new Exception("Debe haber al menos una imagen");
            }
            if (pais == null)
            {
                throw new Exception("Debe seleccionar un pais");
            }
            if (EstadoConservacion == null)
            {
                throw new Exception("Debe seleccionar un estado de conservacion");
            }
            if (Area <= 0)
            {
                throw new Exception("El area debe ser mayor a 0");
            }
            if (Amenazas.Count == 0)
            {
                throw new Exception("Debe haber al menos una amenaza");
            }
        }
  
    public string GradosMinutosSegundos(string valor, string tipo)
    {

        if (string.IsNullOrEmpty(valor) && !valor.Contains('.'))
            throw new Exception("Las coordenadas, deben tener al menos un punto." +
                "Ejemplo: -56.1881600");

        string[] grados = valor.Split('.');


        double parteEnteraGrados = int.Parse(grados[0]);
        if (tipo == "Longitud")
        {
            if (parteEnteraGrados <= -180 || parteEnteraGrados >= 180)
            {
                throw new Exception("La longitud debe estar entre -180° y 180°");
            }
        }
        else
        {

            if (parteEnteraGrados <= -90 || parteEnteraGrados >= 90)
            {
                throw new Exception("La latitud debe estar entre -90° y 90°");
            }
        }
        int parteDecimal = int.Parse(grados[1]);
        int minutos = (parteDecimal * 60);
        string StringMinutos = minutos.ToString();
        int parteEnteraMinutos = int.Parse(StringMinutos.Substring(0, 2));
        int parteDecimalMinutos = int.Parse(StringMinutos.Substring(2, StringMinutos.Length - 2));
        double segundos = (parteDecimalMinutos * 60);
        string StringSegundos = segundos.ToString();
        segundos = double.Parse(StringSegundos.Substring(0, 4));
        segundos = segundos / 100;
        parteEnteraGrados = Math.Abs(parteEnteraGrados);
        return $"{parteEnteraGrados}° {parteEnteraMinutos}' {segundos}''";


    }


}
}
