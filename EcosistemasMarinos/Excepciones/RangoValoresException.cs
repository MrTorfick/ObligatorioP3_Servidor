using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcosistemasMarinos.Excepciones
{
    public class RangoValoresException:Exception
    {

        public RangoValoresException()
        {

        }
        public RangoValoresException(string mensaje) : base(mensaje)
        {

        }
        public RangoValoresException(string mensaje, Exception ex) : base(mensaje, ex)
        {

        }
    }
}
