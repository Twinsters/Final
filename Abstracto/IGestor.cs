using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracto
{
    public interface IGestor<T> where T : IEntidad
    {
        List<T> ListarTodo();
        bool Guardar(T obj);
        bool Eliminar(T obj);
        T ListarUno(T obj);


    }
}
