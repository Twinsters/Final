using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DB;
using Abstracto;
using System.Data;
using System.Collections;
using Security;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace MPP
{
    public class MPPEmpleado : IGestor<BEEmpleado>
    {
       string ruta = Configuracion.RutaArchivo;
        BEEmpleado beEmpleado;
       
        public BEEmpleado ListarUno(BEEmpleado beEmp)
        {
            beEmpleado = new BEEmpleado();
            
            XElement empleado;
            Configuracion dbConfiguracion = new Configuracion();
            try
            {

                dbConfiguracion.creacionBaseXml();

                if (File.Exists(ruta))
                {
                    XDocument xmlDoc = XDocument.Load(ruta);
                   
                   if(beEmp.DNI != 0)
                        {
                            empleado = xmlDoc.Descendants("Empleado")
                           .FirstOrDefault(e => (int?)Convert.ToInt32(e.Element("DNI")?.Value) == beEmp.DNI &&
                                                e.Element("pass")?.Value == Seguridad.Encriptar(beEmp.Pass) && e.Element("Cod_Estado")?.Value != "E");
                        }
                   else
                        {
                        empleado = xmlDoc.Descendants("Empleado")
                          .FirstOrDefault(e => (int?)Convert.ToInt32(e.Attribute("cod_Empleado")?.Value) == beEmp.Id && e.Element("Cod_Estado")?.Value != "E");
                        }
                   

                    if (empleado != null)
                    {
                        BEPerfil bEPerfil = new BEPerfil();
                        BEDomicilio bEDomicilio = new BEDomicilio();
                        beEmpleado.Id = Convert.ToInt32(empleado.Attribute("cod_Empleado")?.Value);
                        beEmpleado.Nombre = empleado.Element("nombre")?.Value;
                        beEmpleado.Apellido = empleado.Element("apellido")?.Value;
                        beEmpleado.DNI = Convert.ToInt32(empleado.Element("DNI")?.Value);
                        
                        
                        beEmpleado.Pass = Seguridad.Desencriptar(empleado.Element("pass")?.Value);
                        bEDomicilio.Id = Convert.ToInt32(empleado.Element("cod_Domicilio")?.Value);
                        string formatoFecha = "yyyy-MM-dd";
                        string fechaNacString = empleado.Element("fecha_Nac")?.Value;

                        if (DateTime.TryParseExact(fechaNacString, formatoFecha,
                                                    System.Globalization.CultureInfo.InvariantCulture,
                                                    System.Globalization.DateTimeStyles.None,
                                                    out DateTime fechaNac))
                        {
                            beEmpleado.FechaNac = fechaNac;
                            beEmpleado.Edad = beEmpleado.Calcular_Edad(fechaNac);
                        }

                        bEPerfil.Id = Convert.ToInt32(empleado.Element("tipo_Empleado")?.Value);
                        var perfil = xmlDoc.Descendants("Perfil")
                           .FirstOrDefault(p => p.Attribute("cod_Perfil")?.Value == bEPerfil.Id.ToString());
                        bEPerfil.Tipo = perfil.Element("tipo")?.Value.ToString();

                        var permisos = xmlDoc.Descendants("Permiso")
                             .Where(per => per.Element("cod_Perfil")?.Value == bEPerfil.Id.ToString())
                             .ToList();
                        foreach (var permiso in permisos)
                        {
                            Permiso p = new Permiso();
                            p.Nombre = permiso.Element("permisosHabilitados")?.Value.ToString();
                            bEPerfil.Permisos.Add(p);
                        }
                        beEmpleado.Perfil = bEPerfil;
                        var domicilio = xmlDoc.Descendants("Domicilio").FirstOrDefault(d => (int?)Convert.ToInt32(d.Attribute("cod_Domicilio")?.Value) == bEDomicilio.Id);
                       if(domicilio != null)
                        {
                            bEDomicilio.Numero = Convert.ToInt32(domicilio.Element("numero")?.Value);
                            bEDomicilio.Calle = domicilio.Element("calle")?.Value;
                            bEDomicilio.Localidad = domicilio.Element("localidad")?.Value;
                          
                        }
                        else
                        {
                            bEDomicilio.Numero = 0;
                            bEDomicilio.Calle = string.Empty;
                            bEDomicilio.Localidad = string.Empty;
                        }
                        beEmpleado.oDom = bEDomicilio;
                        return beEmpleado;
                    }
                    else
                    {
                        Console.WriteLine("Usuario o contraseña incorrectos.");
                        return beEmpleado;
                    }
                }
                else
                {
                    Console.WriteLine("El archivo XML no se encuentra en la ruta especificada.");
                    return beEmpleado;
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: El archivo no fue encontrado.");
                throw ex;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error de entrada/salida.");
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error inesperado.");
                throw ex;
            }
        }
        public List<BEEmpleado> ListarTodo()
        {
           List<BEEmpleado> listaEmpleados = new List<BEEmpleado>();
            try
            {
              
                if (File.Exists(ruta))
                {
                    XDocument xmlDoc = XDocument.Load(ruta);

                    var empleados = xmlDoc.Descendants("Empleado")
                         .Where(e => e.Element("cod_Estado")?.Value == "A" &&  
                                  e.Attribute("cod_Empleado")?.Value != "1"); 

                    if (empleados.Any())
                    {
                        foreach (var empleado in empleados)
                        {
                            BEEmpleado bEEmpleado = new BEEmpleado();
                            BEDomicilio bEDomicilio = new BEDomicilio();
                            BEPerfil bEPerfil = new BEPerfil();
                            bEEmpleado.Id = Convert.ToInt32(empleado.Attribute("cod_Empleado")?.Value);
                            bEEmpleado.Nombre = empleado.Element("nombre")?.Value;
                            bEEmpleado.Apellido = empleado.Element("apellido")?.Value;
                            bEEmpleado.DNI = Convert.ToInt32(empleado.Element("DNI")?.Value);
                            

                            string formatoFecha = "yyyy-MM-dd";
                            string fechaNacString = empleado.Element("fecha_Nac")?.Value;

                            if (DateTime.TryParseExact(fechaNacString, formatoFecha,
                                                        System.Globalization.CultureInfo.InvariantCulture,
                                                        System.Globalization.DateTimeStyles.None,
                                                        out DateTime fechaNac))
                            {
                                bEEmpleado.FechaNac = fechaNac;
                                bEEmpleado.Edad = bEEmpleado.Calcular_Edad(fechaNac);
                            }                         
                            bEEmpleado.Pass = empleado.Element("pass")?.Value;
                            bEEmpleado.Estado = Convert.ToChar(empleado.Element("cod_Estado")?.Value);



                            bEPerfil.Id = Convert.ToInt32(empleado.Element("tipo_Empleado")?.Value);
                            var perfil = xmlDoc.Descendants("Perfil")
                               .FirstOrDefault(p => p.Attribute("cod_Perfil")?.Value == bEPerfil.Id.ToString());

                            bEPerfil.Tipo = perfil.Element("tipo")?.Value.ToString();

                            var permisos = xmlDoc.Descendants("Permiso")
                                 .Where(per => per.Element("cod_Perfil")?.Value == bEPerfil.Id.ToString())
                                 .ToList();

                            foreach (var permiso in permisos)
                            {
                                Permiso p = new Permiso();
                                p.Nombre = permiso.Element("permisosHabilitados")?.Value.ToString();
                                bEPerfil.Permisos.Add(p);
                            }

                            bEEmpleado.Perfil = bEPerfil;
                            bEDomicilio.Id = Convert.ToInt32(empleado.Element("cod_Domicilio")?.Value); 
                            var domicilio = xmlDoc.Descendants("Domicilio")
                                .FirstOrDefault(d => d.Attribute("cod_Domicilio")?.Value == bEDomicilio.Id.ToString());

                            if (domicilio != null)
                            { 
                                bEDomicilio.Calle = domicilio.Element("calle")?.Value.ToString();
                                bEDomicilio.Numero = Convert.ToInt32(domicilio.Element("numero")?.Value);
                                bEDomicilio.Localidad = domicilio.Element("localidad")?.Value;   
                            }
                            else
                            {
                                Console.WriteLine("No se encontró el domicilio correspondiente.");
                            }
                            bEEmpleado.oDom = bEDomicilio;
                            listaEmpleados.Add(bEEmpleado);
                        }
                     return  listaEmpleados;
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron empleados.");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("El archivo XML no se encuentra en la ruta especificada.");
                    return null;
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Error: El archivo no fue encontrado.");
                throw ex;
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error de entrada/salida.");
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió un error inesperado.");
                throw ex;
            }
        }
        public bool Eliminar(BEEmpleado beEmp, BEEmpleado Usuario)
        {  
            try
            {
                XDocument doc = XDocument.Load(ruta);
                var empleado = doc.Descendants("Empleado")
                          .FirstOrDefault(e => e.Attribute("cod_Empleado")?.Value == beEmp.Id.ToString());
                if (empleado != null)
                {
                    empleado.Element("cod_Estado")?.SetValue("E");
                   
                    doc.Save(ruta);
                    Logger.Log($"Empleado Eliminado - ID: {beEmp.Id}, Nombre: {beEmp.Nombre}. Por Id: {Usuario.Id}, {Usuario.Apellido} {Usuario.Nombre}, DNI: {Usuario.DNI}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al eliminar empleado", ex);
                throw ex;
            }
        }
        public bool Guardar(BEEmpleado beEmp, BEEmpleado usuario)
        {
            BEPerfil bEPerfil = new BEPerfil();
            int nuevoId;
            try
            {
                XDocument doc = XDocument.Load(ruta);

                if (beEmp.Id == 0)
                {
                    var ids = doc.Descendants("Empleado")
                        .Select(e => (int)e.Attribute("cod_Empleado"))
                        .ToList();

                    if (ids.Count > 0)
                    {
                        nuevoId = ids.Max() + 1;
                    }
                    else
                    {                  
                        nuevoId = 1;
                    }    
                    XElement nuevoEmpleado = new XElement("Empleado",
                            new XAttribute("cod_Empleado", nuevoId),
                            new XElement("nombre", beEmp.Nombre),
                            new XElement("apellido", beEmp.Apellido),
                            new XElement("DNI", beEmp.DNI),
                            new XElement("cod_Domicilio", beEmp.oDom.Id),
                            new XElement("fecha_Nac", beEmp.FechaNac.ToString("yyyy-MM-dd")),
                            new XElement("cod_Estado", "A"),
                            new XElement("tipo_Empleado", beEmp.Perfil.Id), 
                    new XElement("pass", Seguridad.Encriptar(beEmp.Pass))
                    );
                       var EmpleadoElement = doc.Element("Empresa").Element("Empleados");
                            if (EmpleadoElement == null)
                            {
                                EmpleadoElement = new XElement("Empleados");
                                doc.Element("Empresa").Add(EmpleadoElement);
                            }

                            EmpleadoElement.Add(nuevoEmpleado);
                            doc.Save(ruta);
                            Logger.Log($"Empleado Guardado - ID: {nuevoId}, Nombre: {beEmp.Nombre}, Tipo Empleado:{beEmp.Perfil.Tipo}.Creado por: {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                            return true;
                        }
                else
                {
                    var empleado = doc.Descendants("Empleado").FirstOrDefault(e => (int)e.Attribute("cod_Empleado") == beEmp.Id);

                    empleado.Element("nombre")?.SetValue(beEmp.Nombre);
                    empleado.Element("apellido")?.SetValue(beEmp.Apellido);
                    empleado.Element("DNI")?.SetValue(beEmp.DNI);
                    empleado.Element("tipo_Empleado")?.SetValue(beEmp.Perfil.Id);
                    empleado.Element("fecha_Nac")?.SetValue(beEmp.FechaNac.ToString("yyyy-MM-dd"));
                    empleado.Element("pass")?.SetValue(Seguridad.Encriptar(beEmp.Pass)); 
                    empleado.Element("Cod_Estado")?.SetValue(beEmp.Estado);
                    empleado.Element("cod_Domicilio")?.SetValue(beEmp.oDom.Id);
                    doc.Save(ruta);
                    Logger.Log($"Empleado Modificado - ID: {beEmp.Id}, Nombre: {beEmp.Nombre}, Tipo Empleado:{ beEmp.Perfil.Tipo}.Creado por: {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                    return true;
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
        public bool CorroborarDni(BEEmpleado beEmpleado)
        {
         
            try
            {
                XDocument doc = XDocument.Load(ruta);

                var dni = doc.Descendants("Empleado")
                       .Select(e => (int)e.Element("DNI") == beEmpleado.DNI);
                
                if (dni.Any())
                {
                    
                    return false;
                }
                else
                {

                    return true;
                }

            }
            catch (Exception ex)
            {
                Logger.LogError("Error a corroborar DNI", ex);
                throw ex;
            }
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
