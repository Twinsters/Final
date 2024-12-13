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
      
    }
    public class Logger
    {
        
        private static string rutaBitacora = @"F:\Materias\LUG\Integrador 2\Integrador 2V5\Integrador 2V5\Integrador_2\Bitacora\bitacora.txt"; 

      
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
