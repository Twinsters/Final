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
    public class BLLProveedor : IGestor<BEProveedor>
    {
        MPPProveedor mppProveedor;
        BLLDomicilio bllDomicilio;
     
        public List<BEProveedor> ListarTodo()
        {
           mppProveedor = new MPPProveedor();
           return mppProveedor.ListarTodo();
        }
        public bool Guardar(BEProveedor bEProveedor, BEEmpleado usuario)
        {
            bllDomicilio = new BLLDomicilio();
            mppProveedor = new MPPProveedor();
            try
            {
                if(bEProveedor.Id == 0)
                {
                    bEProveedor.Domicilio = bllDomicilio.GuardarYTraer(bEProveedor.Domicilio, usuario);
                    if (bEProveedor.Domicilio.Id != 0)
                    {
                        return mppProveedor.Guardar(bEProveedor, usuario);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    bEProveedor.Domicilio = bllDomicilio.GuardarYTraer(bEProveedor.Domicilio, usuario);
                    return mppProveedor.Guardar(bEProveedor, usuario);
                }              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Eliminar(BEProveedor bEProveedor, BEEmpleado usuario)
        {
            mppProveedor = new MPPProveedor();
            return mppProveedor.Eliminar(bEProveedor, usuario);
        }
        public BEProveedor ListarUno(BEProveedor bEProveedor)
        {
            mppProveedor = new MPPProveedor();
            return mppProveedor.ListarUno(bEProveedor);
        }

        public bool Eliminar(BEProveedor obj)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEProveedor obj)
        {
            throw new NotImplementedException();
        }
    }
}
