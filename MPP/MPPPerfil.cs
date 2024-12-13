using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE;
using DB;

namespace MPP
{
    public class MPPPerfil
    {
        string ruta = Configuracion.RutaArchivo;
        public List<BEPerfil> buscarPerfiles()
        {

            try
            {

                if (File.Exists(ruta))
                {
                    XDocument xmlDoc = XDocument.Load(ruta);

                    var listaPerfiles = xmlDoc.Descendants("Perfil")
                                         .Where(p => (string)p.Element("cod_Estado") == "A" && (int)p.Attribute("cod_Perfil") != 2)
                                         .Select(p => new BEPerfil
                                         {
                                             Id = (int)p.Attribute("cod_Perfil"),
                                             Tipo = (string)p.Element("tipo"),
                                             Permisos = p.Descendants("Permiso")
                                                         .Where(permiso => (int)permiso.Element("cod_Perfil") == (int)p.Attribute("cod_Perfil"))
                                                         .Select(permiso => new Permiso
                                                         {
                                                             Nombre = (string)permiso.Element("permisosHabilitados")
                                                         })
                                                         .ToList()
                                         })
                                         .ToList();

                    return listaPerfiles;
                }
                else
                {
                    Console.WriteLine("El archivo XML no se encuentra en la ruta especificada.");
                    return null;
                }
            }
            catch( Exception ex)
            {
                throw ex;
            }   
        }
        public List<Permiso> buscarPermisos(int idPerfil)
        {
            try
            {

                XDocument xmlDoc = XDocument.Load(ruta);
                var permisos = xmlDoc.Descendants("Permiso")
                    .Where(p => (int)p.Element("cod_Perfil") == idPerfil)
                    .Select(p => new Permiso
                    {

                        Nombre = (string)p.Element("permisosHabilitados")
                    })
                    .ToList();

                return permisos;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public bool Guardar(BEPerfil bePerfil, BEEmpleado Usuario)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(ruta);

                int nuevoId;

                if (bePerfil.Id == 0 && bePerfil.Tipo != null)
                {
                    var ids = xmlDoc.Descendants("Perfil")
                                   .Select(e => (int)e.Attribute("cod_Perfil"))
                                   .ToList();

                    nuevoId = ids.Count > 0 ? ids.Max() + 1 : 1;

                    XElement nuevoPerfil = new XElement("Perfil",
                               new XAttribute("cod_Perfil", nuevoId),
                               new XElement("tipo", bePerfil.Tipo),
                               new XElement("cod_Estado", 'A')
                    );

                    var perfilElement = xmlDoc.Element("Empresa")?.Element("Perfiles");
                    if (perfilElement == null)
                    {
                        perfilElement = new XElement("Perfiles");
                        xmlDoc.Element("Empresa")?.Add(perfilElement);
                    }

                    perfilElement.Add(nuevoPerfil);

                    if (bePerfil.Permisos.Count > 0)
                    {
                        var permisosElement = xmlDoc.Element("Empresa")?.Element("Permisos");
                        if (permisosElement == null)
                        {
                            permisosElement = new XElement("Permisos");
                            xmlDoc.Element("Empresa")?.Add(permisosElement);
                        }

                        foreach (var permiso in bePerfil.Permisos)
                        {
                            XElement nuevoPermiso = new XElement("Permiso",
                                                                new XElement("cod_Perfil", nuevoId),
                                                                new XElement("permisosHabilitados", permiso.Nombre)
                            );
                            permisosElement.Add(nuevoPermiso);
                        }
                    }

                    xmlDoc.Save(ruta);
                }
                else if(bePerfil.Id != 0  )
                {

                    var perfil = xmlDoc.Descendants("Perfil").FirstOrDefault(e => (int)e.Attribute("cod_Perfil") == bePerfil.Id);

                    perfil.Element("tipo")?.SetValue(bePerfil.Tipo);

                    xmlDoc.Save(ruta);

                    var permisos = xmlDoc.Descendants("Permiso")
                      .Where(e => (int)e.Element("cod_Perfil") == bePerfil.Id)
                      .ToList();

                    foreach (var permiso in permisos)
                    {
                        permiso.Remove();
                    }
                    var PermisosElement = xmlDoc.Element("Empresa").Element("Permisos");
                    foreach (var permiso in bePerfil.Permisos)
                    {
                        XElement nuevoPermiso = new XElement("Permiso",
                            new XElement("cod_Perfil", bePerfil.Id),
                            new XElement("permisosHabilitados", permiso.Nombre)
                        );

                        PermisosElement.Add(nuevoPermiso);
                    }
                  
                    xmlDoc.Save(ruta);

                    Logger.Log($"Perfil Modificado - ID: {bePerfil.Id}, Nombre: {bePerfil.Tipo}.Creado por: {Usuario.Id}, {Usuario.Apellido} {Usuario.Nombre}, DNI: {Usuario.DNI}");
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }
        public bool eliminarPerfil(int idPerfil, BEEmpleado Usuario)
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(ruta);
                var perfil = xmlDoc.Descendants("Perfil")
                           .FirstOrDefault(e => e.Attribute("cod_Perfil")?.Value == idPerfil.ToString() && e.Element("cod_Estado")?.Value == "A");
                if (perfil != null)
                {
                    perfil.Element("cod_Estado")?.SetValue("E");

                    xmlDoc.Save(ruta);
                    Logger.Log($"Perfil Eliminado - ID: {idPerfil}. Por Id: {Usuario.Id}, {Usuario.Apellido} {Usuario.Nombre}, DNI: {Usuario.DNI}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.IO.IOException ioEx)
            {
                Logger.LogError("Error al realizar  guardado", ioEx);
                throw ioEx;

            }
            catch (System.Xml.XmlException xmlEx)
            {
                Logger.LogError("Error al realizar  guardado", xmlEx);
                throw xmlEx;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al realizar  guardado", ex);
                throw ex;
            }
        }

        public void AsignarPermisos(int idPerfil)
        {
            try
            {
               List<Permiso> permisos1 = new List<Permiso>();
               XDocument xmlDoc = XDocument.Load(ruta);
               var permisos = xmlDoc.Descendants("Permiso")
                    .Where(p => (int)p.Element("cod_Perfil") == idPerfil)
                    .Select(p => new Permiso
                    {

                        Nombre = (string)p.Element("permisosHabilitados")
                    })
                    .ToList();
                var permisosCompuesto = new PermisoCompuesto("Permiso Compuesto");
                foreach (var permiso in permisos)
                {

                    permisosCompuesto.AgregarPermiso(new PermisoSimple(permiso.Nombre));

                    permisos1.Add(permisosCompuesto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
