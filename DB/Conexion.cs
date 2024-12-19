using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace DB
{

    public class Configuracion
    {
        private static string directorioBase;
        public static string RutaArchivo { get; private set; }
        public static string RutaArchivoBitacora { get; private set; }
        static Configuracion()
        {
            directorioBase = AppDomain.CurrentDomain.BaseDirectory;
            RutaArchivo = Path.Combine(directorioBase, @"Base XML\Empresa.xml");
            RutaArchivoBitacora = Path.Combine(directorioBase, @"Bitacora XML\Bitacora.xml");

        }

        public void creacionBaseXml()
        {
            if (!File.Exists(RutaArchivo))
            {
                XmlDocument doc = new XmlDocument();

                XmlElement empresaElement = doc.CreateElement("Empresa");

                XmlElement empleadosElement = doc.CreateElement("Empleados");

                XmlElement empleadoElement = doc.CreateElement("Empleado");
                empleadoElement.SetAttribute("cod_Empleado", "1");

                XmlElement nombreElement = doc.CreateElement("nombre");
                nombreElement.InnerText = "Admin";
                empleadoElement.AppendChild(nombreElement);

                XmlElement apellidoElement = doc.CreateElement("apellido");
                apellidoElement.InnerText = "Admin";
                empleadoElement.AppendChild(apellidoElement);

                XmlElement dniElement = doc.CreateElement("DNI");
                dniElement.InnerText = "1";
                empleadoElement.AppendChild(dniElement);

                XmlElement codDomicilioElement = doc.CreateElement("cod_Domicilio");
                codDomicilioElement.InnerText = "1";
                empleadoElement.AppendChild(codDomicilioElement);

                XmlElement fechaNacElement = doc.CreateElement("fecha_Nac");
                fechaNacElement.InnerText = "2024-10-31";
                empleadoElement.AppendChild(fechaNacElement);

                XmlElement codEstadoElement = doc.CreateElement("cod_Estado");
                codEstadoElement.InnerText = "A";
                empleadoElement.AppendChild(codEstadoElement);

                XmlElement tipoEmpleadoElement = doc.CreateElement("tipo_Empleado");
                tipoEmpleadoElement.InnerText = "1";
                empleadoElement.AppendChild(tipoEmpleadoElement);

                XmlElement passElement = doc.CreateElement("pass");
                passElement.InnerText = "Mi23XlTubhw=";
                empleadoElement.AppendChild(passElement);

                empleadosElement.AppendChild(empleadoElement);
                empresaElement.AppendChild(empleadosElement);

                XmlElement domiciliosElement = doc.CreateElement("Domicilios");

                XmlElement domicilioElement = doc.CreateElement("Domicilio");
                domicilioElement.SetAttribute("cod_Domicilio", "1");

                XmlElement calleElement = doc.CreateElement("calle");
                calleElement.InnerText = "0";
                domicilioElement.AppendChild(calleElement);

                XmlElement numeroElement = doc.CreateElement("numero");
                numeroElement.InnerText = "0";
                domicilioElement.AppendChild(numeroElement);

                XmlElement localidadElement = doc.CreateElement("localidad");
                localidadElement.InnerText = "0";
                domicilioElement.AppendChild(localidadElement);

                domiciliosElement.AppendChild(domicilioElement);
                empresaElement.AppendChild(domiciliosElement);
                
                XmlElement perfilesElement = doc.CreateElement("Perfiles");
                
                XmlElement perfilElement = doc.CreateElement("Perfil");
                perfilElement.SetAttribute("cod_Perfil", "1");
                
                XmlElement tipoElement = doc.CreateElement("tipo");
                tipoElement.InnerText = "Admin";
                perfilElement.AppendChild(tipoElement);
                
                XmlElement codEstadoPerfilElement = doc.CreateElement("cod_Estado");
                codEstadoPerfilElement.InnerXml = "A";
                perfilElement.AppendChild(codEstadoPerfilElement);

                perfilesElement.AppendChild(perfilElement);
                empresaElement.AppendChild(perfilesElement);
                //Venta
                XmlElement permisosElement = doc.CreateElement("Permisos");

                XmlElement permiso1Element = doc.CreateElement("Permiso");

                XmlElement codPermisoPerfil1Element = doc.CreateElement("cod_Perfil");
                codPermisoPerfil1Element.InnerXml = "1";
                permiso1Element.AppendChild(codPermisoPerfil1Element);

                XmlElement permisoHabilitadoVentaElement = doc.CreateElement("permisosHabilitados");
                permisoHabilitadoVentaElement.InnerXml = "Venta";
                permiso1Element.AppendChild(permisoHabilitadoVentaElement);

                permisosElement.AppendChild(permiso1Element);
                //Informes
                XmlElement permiso2Element = doc.CreateElement("Permiso");

                XmlElement codPermisoPerfil2Element = doc.CreateElement("cod_Perfil");
                codPermisoPerfil2Element.InnerXml = "1";
                permiso2Element.AppendChild(codPermisoPerfil2Element);

                XmlElement permisoHabilitadoInformeElement = doc.CreateElement("permisosHabilitados");
                permisoHabilitadoInformeElement.InnerXml = "Informes";
                permiso2Element.AppendChild(permisoHabilitadoInformeElement);

                permisosElement.AppendChild(permiso2Element);

                //Compras
                XmlElement permiso3Element = doc.CreateElement("Permiso");

                XmlElement codPermisoPerfil3Element = doc.CreateElement("cod_Perfil");
                codPermisoPerfil3Element.InnerXml = "1";
                permiso3Element.AppendChild(codPermisoPerfil3Element);

                XmlElement permisoHabilitadoComprasElement = doc.CreateElement("permisosHabilitados");
                permisoHabilitadoComprasElement.InnerXml = "Compras";
                permiso3Element.AppendChild(permisoHabilitadoComprasElement);

                permisosElement.AppendChild(permiso3Element);

                //Dashboard
                XmlElement permiso4Element = doc.CreateElement("Permiso");

                XmlElement codPermisoPerfil4Element = doc.CreateElement("cod_Perfil");
                codPermisoPerfil4Element.InnerXml = "1";
                permiso4Element.AppendChild(codPermisoPerfil4Element);

                XmlElement permisoHabilitadoDashboardElement = doc.CreateElement("permisosHabilitados");
                permisoHabilitadoDashboardElement.InnerXml = "Dashboard";
                permiso4Element.AppendChild(permisoHabilitadoDashboardElement);

                permisosElement.AppendChild(permiso4Element);

                //Juegos
                XmlElement permiso5Element = doc.CreateElement("Permiso");

                XmlElement codPermisoPerfil5Element = doc.CreateElement("cod_Perfil");
                codPermisoPerfil5Element.InnerXml = "1";
                permiso5Element.AppendChild(codPermisoPerfil5Element);

                XmlElement permisoHabilitadoJuegosElement = doc.CreateElement("permisosHabilitados");
                permisoHabilitadoJuegosElement.InnerXml = "Juegos";
                permiso5Element.AppendChild(permisoHabilitadoJuegosElement);

                permisosElement.AppendChild(permiso5Element);

                //Empleados
                XmlElement permiso6Element = doc.CreateElement("Permiso");

                XmlElement codPermisoPerfil6Element = doc.CreateElement("cod_Perfil");
                codPermisoPerfil6Element.InnerXml = "1";
                permiso6Element.AppendChild(codPermisoPerfil6Element);

                XmlElement permisoHabilitadoEmpleadosElement = doc.CreateElement("permisosHabilitados");
                permisoHabilitadoEmpleadosElement.InnerXml = "Empleados";
                permiso6Element.AppendChild(permisoHabilitadoEmpleadosElement);

                permisosElement.AppendChild(permiso6Element);

                //Proveedores
                XmlElement permiso7Element = doc.CreateElement("Permiso");

                XmlElement codPermisoPerfil7Element = doc.CreateElement("cod_Perfil");
                codPermisoPerfil7Element.InnerXml = "1";
                permiso7Element.AppendChild(codPermisoPerfil7Element);

                XmlElement permisoHabilitadoProveedoresElement = doc.CreateElement("permisosHabilitados");
                permisoHabilitadoProveedoresElement.InnerXml = "Proveedores";
                permiso7Element.AppendChild(permisoHabilitadoProveedoresElement);

                permisosElement.AppendChild(permiso7Element);

                //Ventas
                XmlElement permiso8Element = doc.CreateElement("Permiso");

                XmlElement codPermisoPerfil8Element = doc.CreateElement("cod_Perfil");
                codPermisoPerfil8Element.InnerXml = "1";
                permiso8Element.AppendChild(codPermisoPerfil8Element);

                XmlElement permisoHabilitadoVentasElement = doc.CreateElement("permisosHabilitados");
                permisoHabilitadoVentasElement.InnerXml = "Ventas";
                permiso8Element.AppendChild(permisoHabilitadoVentasElement);

                permisosElement.AppendChild(permiso8Element);

                //Backups
                XmlElement permiso9Element = doc.CreateElement("Permiso");

                XmlElement codPermisoPerfil9Element = doc.CreateElement("cod_Perfil");
                codPermisoPerfil9Element.InnerXml = "1";
                permiso9Element.AppendChild(codPermisoPerfil9Element);

                XmlElement permisoHabilitadoBackupElement = doc.CreateElement("permisosHabilitados");
                permisoHabilitadoBackupElement.InnerXml = "Backups";
                permiso9Element.AppendChild(permisoHabilitadoBackupElement);

                permisosElement.AppendChild(permiso9Element);

                //Perfiles
                XmlElement permiso10Element = doc.CreateElement("Permiso");

                XmlElement codPermisoPerfil10Element = doc.CreateElement("cod_Perfil");
                codPermisoPerfil10Element.InnerXml = "1";
                permiso10Element.AppendChild(codPermisoPerfil10Element);

                XmlElement permisoHabilitadoPerfilElement = doc.CreateElement("permisosHabilitados");
                permisoHabilitadoPerfilElement.InnerXml = "Perfiles";
                permiso10Element.AppendChild(permisoHabilitadoPerfilElement);

                permisosElement.AppendChild(permiso10Element);
                empresaElement.AppendChild(permisosElement);

                doc.AppendChild(empresaElement);
                doc.Save(RutaArchivo);

                Console.WriteLine($"El archivo {RutaArchivo} ha sido creado con el formato especificado.");
            }
            else
            {
                Console.WriteLine($"El archivo {RutaArchivo} ya existe.");
            }

        }
      
    }
    public class Logger
    {
        
        private static string rutaBitacora =Path.Combine(AppDomain.CurrentDomain.BaseDirectory,@"bitacora.txt"); 



        public static void Log(string message)
        {
            try
            {

                string logDirectory = Path.GetDirectoryName(rutaBitacora);
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }


                string dateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                
                string logMessage = $"{dateTime} - {message}";

               
                File.AppendAllText(rutaBitacora, logMessage + Environment.NewLine);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Error al escribir en la bitácora: {ex.Message}");
            }
        }

       
        public static void LogError(string message, Exception ex)
        {
            
            string errorMessage = $"{message} - Error: {ex.Message} - StackTrace: {ex.StackTrace}";
            Log(errorMessage);
        }
    }
   
}
