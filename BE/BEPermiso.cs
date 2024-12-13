using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Permiso
    {
        public string Nombre { get; set; }

        public Permiso(string nombre)
        {
            Nombre = nombre;
        }

        public Permiso()
        {
        }

        public virtual bool TieneAcceso(string recurso)
        {
            return Nombre.Equals(recurso, StringComparison.OrdinalIgnoreCase);
        }
    }
    public class PermisoSimple : Permiso
    {
        public PermisoSimple(string nombre) : base(nombre)
        {
        }

        public override bool TieneAcceso(string recurso)
        {
            return base.TieneAcceso(recurso);
        }
    }
    public class PermisoCompuesto : Permiso
    {
        private List<Permiso> _permisos;  

        public PermisoCompuesto(string nombre) : base(nombre)
        {
            _permisos = new List<Permiso>();
        }

        public void AgregarPermiso(Permiso permiso)
        {
            _permisos.Add(permiso);
        }

        public override bool TieneAcceso(string recurso)
        {
            foreach (var permiso in _permisos)
            {
                if (permiso.TieneAcceso(recurso))  
                    return true;
            }
            return false;
        }
    }
}
