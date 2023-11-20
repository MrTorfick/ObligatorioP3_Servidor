using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.DTOs
{
    public class ConfiguracionDto
    {

        [JsonIgnore]
        public int Id { get; set; }
        public string NombreAtributo { get; set; }
        public int topeSuperior { get; set; }
        public int topeInferior { get; set; }

        public ConfiguracionDto() { }

        public ConfiguracionDto(Configuracion configuracion)
        {
            if (configuracion!=null){
                this.Id = configuracion.Id;
                this.NombreAtributo = configuracion.NombreAtributo;
                this.topeSuperior = configuracion.topeSuperior;
                this.topeInferior = configuracion.topeInferior;
            }
            
        }
    }
}
