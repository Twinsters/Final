using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracto;
using BE;
using MPP;
namespace BLL
{
    public class BLLEmpleado : IGestor<BEEmpleado>
    {
        MPPEmpleado mppEmp;
        BLLDomicilio bllDomicilio;

        public BEEmpleado ListarUno(BEEmpleado beeEmp)
        {
            mppEmp = new MPPEmpleado();
            return mppEmp.ListarUno(beeEmp);
        }

        public List<BEEmpleado> ListarTodo()
        {
            mppEmp = new MPPEmpleado();
            return mppEmp.ListarTodo();
        }
        public bool Guardar(BEEmpleado beeEmp,BEEmpleado usuario)
        {
            bllDomicilio = new BLLDomicilio();
            mppEmp = new MPPEmpleado();
            try
            {
                
                
                if (beeEmp.Id == 0)
                
                {
                if (!mppEmp.CorroborarDni(beeEmp))
                {
                    beeEmp.oDom = bllDomicilio.GuardarYTraer(beeEmp.oDom, usuario);

                        if (beeEmp.oDom.Id != 0)
                        {

                            return mppEmp.Guardar(beeEmp, usuario);
                        }
                        else
                        {
                            return false;
                        }
                    
                }
                else
                {
                    return false;
                }
                }
                else
                {
                    beeEmp.oDom = bllDomicilio.GuardarYTraer(beeEmp.oDom,usuario);
                    return mppEmp.Guardar(beeEmp, usuario);
                    
                }
                
               
               

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool Eliminar(BEEmpleado beeEmp, BEEmpleado Usuario)
        {
            mppEmp = new MPPEmpleado();
            return mppEmp.Eliminar(beeEmp, Usuario);
        }

        public bool Eliminar(BEEmpleado obj)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEEmpleado obj)
        {
            throw new NotImplementedException();
        }
    }
}
