﻿using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Interfaces_Repositorios
{
    public interface IRepositorioEspecieMarina:IRepositorio<EspecieMarina>
    {

        public void AsociarEspecieAEcosistema(int idEspecie, int idEcosistema);

    }
}
