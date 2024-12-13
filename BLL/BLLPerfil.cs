using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
using BE;
namespace BLL
{
    public class BLLPerfil
    {
        MPPPerfil mmpPerfil;
        public bool Guardar(BEPerfil bePerfil, BEEmpleado Usuario)
        {
            mmpPerfil = new MPPPerfil();
            return mmpPerfil.Guardar(bePerfil, Usuario);

        }
        public List<BEPerfil> buscarPerfiles()
        {
            mmpPerfil = new MPPPerfil();
            return mmpPerfil.buscarPerfiles();

        }
   
        
        public List<Permiso> buscarPermisos(int idPerfil)
        {
            mmpPerfil = new MPPPerfil();
            return mmpPerfil.buscarPermisos(idPerfil);
        }
        public bool eliminarPerfil(int idPerfil,BEEmpleado Usuario)
        {
            mmpPerfil = new MPPPerfil();
            return mmpPerfil.eliminarPerfil(idPerfil, Usuario);
        }
        public void AsignarPermisos(int idPerfil)
        {
           
            mmpPerfil = new MPPPerfil();
            mmpPerfil.AsignarPermisos(idPerfil);
        }

    }
}
