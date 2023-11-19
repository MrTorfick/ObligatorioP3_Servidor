﻿using _EcosistemasMarinos.LogicaAplicacion.DTOs;
using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso
{
    public interface IUpdateConfiguracion
    {
        public void UpdateConfiguracion(ConfiguracionDto configuracion, string UsuarioLogueado);
    }
}
