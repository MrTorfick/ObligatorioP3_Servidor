﻿using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso.Ecosistema_Marino
{
    public interface IUpdateEcosistemaMarino
    {

        public void UpdateEcosistemaMarino(EcosistemaMarino ecosistemaMarino, string UsuarioLogueado);

    }
}
