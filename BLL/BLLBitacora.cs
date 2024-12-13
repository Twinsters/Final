using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
namespace BLL
{
    public class BLLBitacora
    {
        MPPBitacora mppBitacora;
        public bool guardarBitacora(BEBitacora bitacora)
        {
            mppBitacora = new MPPBitacora();
            return mppBitacora.guardarBitacora(bitacora);
        }
        public List<BEBitacora> listarTodo()
        {
            mppBitacora = new MPPBitacora();
            return mppBitacora.listarTodo();
        }


    }
}
