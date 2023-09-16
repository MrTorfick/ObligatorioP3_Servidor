using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Interfaces_Repositorios
{
    public interface IRepositorio<T>
    {
        IEnumerable<T> FindAll();
        T FindByID(int id);
        void Add(T unDato);
        void Remove(int id);
        void Update(T dato);

    }
}
