using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Abstracto;
using BE;
using DB;
namespace MPP
{
    public class MPPProveedor : IGestor<BEProveedor>
    {
      
        BEProveedor beProveedor;
       
        string ruta = Configuracion.RutaArchivo;
        public List<BEProveedor> ListarTodo()
        {
            DataTable dt = new DataTable();
            List<BEProveedor> listaProveedores = new List<BEProveedor>();
            try
            {
                if (File.Exists(ruta))
                {
                    XDocument xmlDoc = XDocument.Load(ruta);
                    var proveedores = xmlDoc.Descendants("Proveedor").Where(p => p.Element("cod_Estado").Value == "A");
                    if (proveedores.Any())
                    {
                        foreach (var provedoor in proveedores)
                        {
                            BEProveedor bEEProveedor = new BEProveedor();
                            BEDomicilio bEDomicilio = new BEDomicilio();
                            bEEProveedor.Id = Convert.ToInt32(provedoor.Attribute("cod_Proveedor")?.Value);
                            bEEProveedor.Nombre = provedoor.Element("nombre")?.Value;
                            bEDomicilio.Id = Convert.ToInt32(provedoor.Element("cod_Domicilio")?.Value);
                            bEEProveedor.CodEstado = Convert.ToChar(provedoor.Element("cod_Estado")?.Value);
                            var domicilio = xmlDoc.Descendants("Domicilio")
                                .FirstOrDefault(d => d.Attribute("cod_Domicilio")?.Value == bEDomicilio.Id.ToString());
                            if (domicilio != null)
                            {
                                bEDomicilio.Calle = domicilio.Element("calle")?.Value.ToString();
                                bEDomicilio.Numero = Convert.ToInt32(domicilio.Element("numero")?.Value);
                                bEDomicilio.Localidad = domicilio.Element("localidad")?.Value;
                            }
                            bEEProveedor.Domicilio = bEDomicilio;
                            listaProveedores.Add(bEEProveedor);
                        }
                      
                    }
                }
                return listaProveedores;
                }
            catch (FileNotFoundException ex)
            {
                Logger.LogError("Error al traer proveedores", ex);
                throw ex;
            }
            catch (IOException ex)
            {
                Logger.LogError("Error al traer proveedores", ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al traer proveedores", ex);
                throw ex;
            }

        }
        public bool Guardar(BEProveedor oBE,BEEmpleado usuario)
        {


            int nuevoId;
            try
            {
                XDocument doc = XDocument.Load(ruta);

                if (oBE.Id == 0)
                {

                    var ids = doc.Descendants("Proveedor")
                        .Select(e => (int)e.Attribute("cod_Proveedor"))
                        .ToList();

                    if (ids.Count > 0)
                    {

                        nuevoId = ids.Max() + 1;
                    }
                    else
                    {

                        nuevoId = 1;
                    }
                    XElement nuevoProveedor = new XElement("Proveedor",
                        new XAttribute("cod_Proveedor", nuevoId),
                        new XElement("nombre", oBE.Nombre),
                        new XElement("cod_Domicilio", oBE.Domicilio.Id),
                       new XElement("cod_Estado", "A")
                );
                    var ProveedorElement = doc.Element("Empresa").Element("Proveedores");
                    if (ProveedorElement == null)
                    {
                        ProveedorElement = new XElement("Proveedores");
                        doc.Element("Empresa").Add(ProveedorElement);
                    }
                    ProveedorElement.Add(nuevoProveedor);
                    doc.Save(ruta);
                    Logger.Log($"Proveedor Guardado - ID: {nuevoId}, Nombre: {oBE.Nombre}. Creado por: {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                    return true;
                }
                else
                {
                    var proveedor = doc.Descendants("Proveedor").FirstOrDefault(e => (int)e.Attribute("cod_Proveedor") == oBE.Id);
                    proveedor.Element("nombre")?.SetValue(oBE.Nombre);
                    doc.Save(ruta);
                    Logger.Log($"Proveedor Modificado - ID: {oBE.Id}, Nombre: {oBE.Nombre}. Creado por: {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                    return true;
                }
            }
            catch (System.IO.IOException ioEx)
            {
                Logger.LogError("Error al realizar a guardar juego", ioEx);
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                Logger.LogError("Error al realizar a guardar juego", xmlEx);
                throw xmlEx;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al realizar a guardar juego", ex);
                throw ex;
            }
           

        }
        public bool Eliminar(BEProveedor oBE,BEEmpleado usuario)
        {
            try
            {
                XDocument doc = XDocument.Load(ruta);
                var proveedor = doc.Descendants("Proveedor")
                          .FirstOrDefault(e => e.Attribute("cod_Proveedor")?.Value == oBE.Id.ToString());
                if (proveedor != null)
                {
                    proveedor.Element("cod_Estado")?.SetValue("E");
                    doc.Save(ruta);
                    Logger.Log($"Proveedor Eliminado - ID: {oBE.Id}. Eliminado por: codigo {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al realizar a guardar juego", ex);
                throw ex;
            }
        }
        public BEProveedor ListarUno(BEProveedor beProveedor)
        {
            BEDomicilio domicilio = new BEDomicilio();
            try
            {
                XDocument doc = XDocument.Load(ruta);
                var proveedor = doc.Descendants("Proveedor").FirstOrDefault(p => p.Attribute("cod_Proveedor")?.Value == beProveedor.Id.ToString());
                beProveedor.Nombre = proveedor.Element("nombre")?.Value;
                domicilio.Id = Convert.ToInt32(proveedor.Element("cod_Domicilio")?.Value);
                var dom = doc.Descendants("Domicilio").FirstOrDefault(d => d.Attribute("cod_Domicilio")?.Value == domicilio.Id.ToString());
                domicilio.Calle = dom.Element("calle")?.Value;
                domicilio.Numero = Convert.ToInt32(dom.Element("numero")?.Value);
                domicilio.Localidad = dom.Element("localidad")?.Value;
                beProveedor.Domicilio = domicilio;
                return beProveedor;

            }
            catch (Exception ex)
            {

                throw ex;
            }
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
