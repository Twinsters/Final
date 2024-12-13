using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using Abstracto;
using MPP;
namespace BLL
{
    public class BLLDomicilio : IGestor<BEDomicilio>
    {
        MPPDomicilio mppDomicilio;
        public bool Guardar(BEDomicilio bEDomicilio)
        {
            mppDomicilio = new MPPDomicilio();
            return mppDomicilio.Guardar(bEDomicilio);
            
        }
        public BEDomicilio GuardarYTraer(BEDomicilio bEDomicilio,BEEmpleado usuario)
        {
            mppDomicilio = new MPPDomicilio();
            return mppDomicilio.GuardarYTraer(bEDomicilio, usuario);

        }
        public List<BEDomicilio> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public BEDomicilio ListarUno(BEDomicilio bEDomicilio)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(BEDomicilio bEDomicilio)
        {
            throw new NotImplementedException();
        }
    }
}
