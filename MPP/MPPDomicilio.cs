using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstracto;
using DB;
using BE;
using System.Collections;
using System.Data;
using System.Xml.Linq;

namespace MPP
{
    public class MPPDomicilio : IGestor<BEDomicilio>
    {
      
        Hashtable hashtable;
        string ruta = Configuracion.RutaArchivo;
        public BEDomicilio GuardarYTraer(BEDomicilio beDomicilio, BEEmpleado usuario)
        {
            XDocument doc;
            int nuevoId;
            try
            {
                doc = XDocument.Load(ruta);
            }
            catch (Exception ex)
            {

                throw ex;
             
            }
            try
            {
              
                if (beDomicilio.Id == 0)
                {
                    var ids = doc.Descendants("Domicilio")
                        .Select(e => (int)e.Attribute("cod_Domicilio"))
                        .ToList();

                    

                    if (ids.Count > 0)
                    {
                        nuevoId = ids.Max() + 1;
                    }
                    else
                    {
                        nuevoId = 1;
                    }
                    XElement nuevoDomicilio = new XElement("Domicilio",
                            new XAttribute("cod_Domicilio", nuevoId),
                            new XElement("calle", beDomicilio.Calle),
                            new XElement("numero", beDomicilio.Numero),
                            new XElement("localidad", beDomicilio.Localidad)                         
                    );
                    var domiciliosElement = doc.Element("Empresa").Element("Domicilios");
                    if (domiciliosElement == null)
                    {
                        domiciliosElement = new XElement("Domicilios");
                        doc.Element("Empresa").Add(domiciliosElement);
                    }
                    domiciliosElement.Add(nuevoDomicilio);
                    doc.Save(ruta);
                    Logger.Log($"Domicilio Guardado - ID: {nuevoId}, Localidad: {beDomicilio.Localidad}, Calle: {beDomicilio.Calle}, Numero:{beDomicilio.Numero}. Creado por: {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                    beDomicilio.Id = nuevoId;
                    
                }
                else
                {
                    var domicilio = doc.Descendants("Domicilio").FirstOrDefault(e => (int)e.Attribute("cod_Domicilio") == beDomicilio.Id);

                    domicilio.Element("calle")?.SetValue(beDomicilio.Calle);
                    domicilio.Element("numero")?.SetValue(beDomicilio.Numero);
                    domicilio.Element("localidad")?.SetValue(beDomicilio.Localidad);
                    doc.Save(ruta);
                    Logger.Log($"Domicilio Modificado - ID: {beDomicilio.Id}, Localidad: {beDomicilio.Localidad}, Calle: {beDomicilio.Calle}, Numero:{beDomicilio.Numero}. Creado por: {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                }
                return beDomicilio;
            }
            catch (System.IO.IOException ioEx)
            {
                Logger.LogError("Error al agregar producto al carrito", ioEx);
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                Logger.LogError("Error al agregar producto al carrito", xmlEx);
                throw xmlEx;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al agregar producto al carrito", ex);
                throw ex;
            }
        }

        public List<BEDomicilio> ListarTodo()
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEDomicilio obj)
        {
            throw new NotImplementedException();
        }

        public bool Eliminar(BEDomicilio obj)
        {
            throw new NotImplementedException();
        }

        public BEDomicilio ListarUno(BEDomicilio obj)
        {
            throw new NotImplementedException();
        }
    }
}
