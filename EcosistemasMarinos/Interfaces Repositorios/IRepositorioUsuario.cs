using EcosistemasMarinos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Interfaces_Repositorios
{
    public interface IRepositorioUsuario:IRepositorio<Usuario>
    {

        Usuario FindUserByCredentials(string name, string password);

    }
}
