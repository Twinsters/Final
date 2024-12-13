using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;
using Abstracto;
namespace BLL
{
    public class BLLCliente : IGestor<BEPersona>
    {
        MPPCliente mppCliente;
        public BEPersona GuardarYTraer(BEPersona beCliente)
        {
            mppCliente = new MPPCliente();
            return mppCliente.GuardarYTraer(beCliente);
        }

        public bool Eliminar(BEPersona bECliente)
        {
            throw new NotImplementedException();
        }
        public bool Guardar(BEPersona bECliente)
        {
            throw new NotImplementedException();
        }

        public List<BEPersona> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public BEPersona ListarUno(BEPersona bECliente)
        {
            throw new NotImplementedException();
        }
    }
}
