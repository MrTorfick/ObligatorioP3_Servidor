using _EcosistemasMarinos.LogicaAplicacion.Interfaces_Caso_de_Uso;
using EcosistemasMarinos.Entidades;
using EcosistemasMarinos.Interfaces_Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _EcosistemasMarinos.LogicaAplicacion.Caso_de_Uso
{
    public class AddAuditoriaUC : IAddAuditoria
    {

        private IRepositorioAuditoria _repositorioAuditoria;

        public AddAuditoriaUC(IRepositorioAuditoria repositorioAuditoria)
        {
            _repositorioAuditoria = repositorioAuditoria;
        }


        public void AddAuditoria(Auditoria auditoria)
        {
            _repositorioAuditoria.Add(auditoria);
        }
    }
}
