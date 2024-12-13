using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BE
{
    public class BEPerfil
    {

        public int Id { get; set; }
        public string Tipo { get; set; }
        public List<Permiso> Permisos { get; set; }

        public BEPerfil(string tipo,int id)
        {
            Id = Id;
            Tipo = tipo;
            Permisos = new List<Permiso>();         
        }
        public BEPerfil(string tipo)
        {           
            Tipo = tipo;
            Permisos = new List<Permiso>();            
        }

        public BEPerfil()
        {
            Permisos = new List<Permiso>();            
        }
        public override string ToString()
        {
            return Tipo;
        }
        /*
        private void AsignarPermisos()
        {
            switch (Tipo)
            {
                case "Admin":
                   
                    var permisosAdmin = new PermisoCompuesto("Permisos Admin");
                    permisosAdmin.AgregarPermiso(new PermisoSimple("Acciones"));
                    permisosAdmin.AgregarPermiso(new PermisoSimple("AMB"));
                    permisosAdmin.AgregarPermiso(new PermisoSimple("Backup"));
                    permisosAdmin.AgregarPermiso(new PermisoSimple("Juegos"));
                    permisosAdmin.AgregarPermiso(new PermisoSimple("Proveedores"));
                    permisosAdmin.AgregarPermiso(new PermisoSimple("Compras"));
                    permisosAdmin.AgregarPermiso(new PermisoSimple("Venta"));
                    Permisos.Add(permisosAdmin);
                    break;

                case "Gerente":
                    
                    var permisosGerente = new PermisoCompuesto("Permisos Gerente");
                    permisosGerente.AgregarPermiso(new PermisoSimple("Acciones"));
                    permisosGerente.AgregarPermiso(new PermisoSimple("AMB"));
                    permisosGerente.AgregarPermiso(new PermisoSimple("Backup"));
                    permisosGerente.AgregarPermiso(new PermisoSimple("Juegos"));
                    permisosGerente.AgregarPermiso(new PermisoSimple("Proveedores"));
                    permisosGerente.AgregarPermiso(new PermisoSimple("Compras"));
                    permisosGerente.AgregarPermiso(new PermisoSimple("Venta"));
                    Permisos.Add(permisosGerente);
                    break;
                case "Deposito":
                    var permisosDeposito = new PermisoCompuesto("Permisos Deposito");
                    permisosDeposito.AgregarPermiso(new PermisoSimple("Juegos"));
                    permisosDeposito.AgregarPermiso(new PermisoSimple("Proveedores"));
                    permisosDeposito.AgregarPermiso(new PermisoSimple("Compras"));
                    Permisos.Add(permisosDeposito);
                    break;
                case "Empleado":
                   
                    var permisosEmpleado = new PermisoCompuesto("Permisos Empleado");
                    permisosEmpleado.AgregarPermiso(new PermisoSimple("Venta"));
                    Permisos.Add(permisosEmpleado);
                    break;
            }
        }
        */
        public bool TieneAcceso(string recurso)
        {
            foreach (var permiso in this.Permisos)
            {
                if (permiso.TieneAcceso(recurso))
                    return true;
            }
            return false;
        }

    }
   
}
