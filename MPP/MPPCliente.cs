using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DB;
using Abstracto;
using System.Collections;
using System.Data;
using System.Xml.Linq;

namespace MPP
{
    public class MPPCliente : IGestor<BEPersona>
    {
       string ruta = Configuracion.RutaArchivo;
        public BEPersona GuardarYTraer(BEPersona beCliente)
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
                if (beCliente.Id == 0)
                {
                    var ids = doc.Descendants("Cliente")
                        .Select(e => (int)e.Attribute("cod_Cliente"))
                        .ToList();
                    if (ids.Count > 0)
                    {
                        nuevoId = ids.Max() + 1;
                    }
                    else
                    {
                        nuevoId = 1;
                    }
                    XElement nuevoCliente = new XElement("Cliente",
                            new XAttribute("cod_Cliente", nuevoId),
                            new XElement("nombre", beCliente.Nombre),
                            new XElement("apellido", beCliente.Apellido),
                            new XElement("DNI", beCliente.DNI),
                            new XElement("fec_Nac", beCliente.FechaNac.ToString("yyyy-MM-dd")),
                            new XElement("cod_Estado","A")

                    );
                    var clienteElement = doc.Element("Empresa").Element("Clientes");
                    if (clienteElement == null)
                    {
                        clienteElement = new XElement("Clientes");
                        doc.Element("Empresa").Add(clienteElement);
                    }
                    clienteElement.Add(nuevoCliente);
                    doc.Save(ruta);
                    Logger.Log($"Cliente Guardado - ID: {beCliente.Id}, Nombre: {beCliente.Nombre}, DNI:{beCliente.DNI}");
                    beCliente.Id = nuevoId;
                }
                else
                {
                    var cliente = doc.Descendants("Cliente").FirstOrDefault(e => (int)e.Attribute("cod_Cliente") == beCliente.Id);
                    cliente.Element("nombre")?.SetValue(beCliente.Nombre);
                    cliente.Element("apellido")?.SetValue(beCliente.Apellido);
                    cliente.Element("DNI")?.SetValue(beCliente.DNI);
                    cliente.Element("fec_Nac")?.SetValue(beCliente.FechaNac);           
                    doc.Save(ruta);
                    Logger.Log($"Cliente Modificado - ID: {beCliente.Id}, Nombre: {beCliente.Nombre}, DNI:{beCliente.DNI}");
                }
                return beCliente;
            }
            catch (System.IO.IOException ioEx)
            {
                Logger.LogError("Error al agregar Cliente", ioEx);
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                Logger.LogError("Error al agregar Cliente", xmlEx);
                throw xmlEx;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al agregar Cliente", ex);
                throw ex;
            }
        }
        public bool Guardar(BEPersona bECliente)
        {
            throw new NotImplementedException();
        }
        public bool Eliminar(BEPersona bECliente)
        {
            throw new NotImplementedException();
        }
        public List<BEPersona> ListarTodo()
        {
            throw new NotImplementedException();
        }
        public BEPersona ListarUno(BEPersona bECliente)
        {
            throw new NotImplementedException();
        }
    }
}
