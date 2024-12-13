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
    public class MPPBitacora
    {
        string ruta = Configuracion.RutaArchivoBitacora;
        public bool guardarBitacora(BEBitacora bitacora)
        {
            try
            {
                if (!File.Exists(ruta))
                {

                    XDocument doc = new XDocument(
                        new XElement("Bitacora")
                    );
                    doc.Save(ruta);
                }
                XDocument archivoBitacora = XDocument.Load(ruta);
                archivoBitacora.Root.Add(
                    new XElement("Registro",
                        new XElement("usuario", bitacora.Usuario.Apellido + "," + bitacora.Usuario.Nombre),
                        new XElement("fechaYHora", bitacora.FechaYHora.ToString("dd-MM-yyyy HH:mm:ss")),
                        new XElement("nombreArchivo", bitacora.NombreArchivo),
                        new XElement("evento", bitacora.Evento)
                    )
                );
                archivoBitacora.Save(ruta);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la bitácora: " + ex.Message);
                return false;
            }
        }
        public List<BEBitacora> listarTodo()
        {
            try
            {
                if (File.Exists(ruta))
                {    
                    XDocument doc = XDocument.Load(ruta);
                    var registros = doc.Descendants("Registro")
                        .Select(r => new BEBitacora
                        {
                            Usuario = new BEEmpleado
                            {
                                Apellido = r.Element("usuario")?.Value.Split(',').FirstOrDefault(),
                                Nombre = r.Element("usuario")?.Value.Split(',').Skip(1).FirstOrDefault()
                            },
                            FechaYHora = DateTime.Parse(r.Element("fechaYHora")?.Value),
                            NombreArchivo = r.Element("nombreArchivo")?.Value,
                            Evento = r.Element("evento")?.Value
                        })
                        .ToList();
                    return registros;
                }
                else
                {
                    Console.WriteLine("El archivo de bitácora no existe.");
                    return new List<BEBitacora>();
                }
            }
            catch (Exception ex)
            {             
                Console.WriteLine("Error al listar la bitácora: " + ex.Message);
                return new List<BEBitacora>();
            }


        }

    }
}
