using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BE;

namespace DB
{
    public class BackupHelper
    {

        private static string directorioBase;
        //public const string backupDir = @"F:\Materias\LUG\Integrador 2\Integrador 2V5\Integrador 2V5\Integrador_2\Backup";
        public static string backupDir { get; private set; }
        static BackupHelper()
        {
            directorioBase = AppDomain.CurrentDomain.BaseDirectory;
            backupDir = Path.Combine(directorioBase, @"Backup");
        }


        
        string ruta = Configuracion.RutaArchivo;

        public List<BEBackup> CargarArchivosBackup()
        {
            List<BEBackup> archivosBackup = new List<BEBackup>();

            try
            {
                if (Directory.Exists(backupDir)) 
                {
                    var archivos = Directory.GetFiles(backupDir, "*.xml")
                                            .Select(f => new FileInfo(f)) 
                                            .OrderByDescending(f => f.LastWriteTime) 
                                            .ToList();
                    foreach (var archivo in archivos)
                    {
                        archivosBackup.Add(new BEBackup
                        {
                            Nombre = archivo.Name,
                            FechaCreacion = archivo.LastWriteTime 
                        });
                    }
                    return archivosBackup;
                }
             
                else
                {
                   return archivosBackup;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al realizar el backup: ", ex);
                throw ex;
            }
        }
        public bool RealizarBackup()
        {
            try
            {
                if (!Directory.Exists(backupDir))
                {
                    Directory.CreateDirectory(backupDir);
                }
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string backupFileName = $"Backup_{timestamp}.xml";
                string backupFilePath = Path.Combine(backupDir, backupFileName);
                File.Copy(ruta, backupFilePath);
                Logger.Log($"Backup creado exitosamente - Backup_{ timestamp}.xml");
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al realizar el backup: ", ex);
                throw ex;
            }
        }
        public bool ReemplazarBaseDeDatos(BEBackup Archivo,BEEmpleado usuario)
        {
            try
            {
                string rutaBackup = Path.Combine(backupDir, Archivo.Nombre);
                if (File.Exists(rutaBackup))
                {
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                    string archivoBackupConTimestamp = Path.Combine(backupDir, $"{Path.GetFileNameWithoutExtension(Archivo.Nombre)}_Restore- {timestamp}{Path.GetExtension(Archivo.Nombre)}");
                    File.Move(ruta, archivoBackupConTimestamp);
                    File.Copy(rutaBackup, ruta, overwrite: true);
                    if (File.Exists(Path.Combine(backupDir,Archivo.Nombre)))
                    {
                        File.Delete(Path.Combine(backupDir, Archivo.Nombre));
                    }
                   
                    Logger.Log($"La base de datos ha sido reemplazada exitosamente con el backup. Por: {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al reemplazar la base de datos: {ex.Message}.Por: {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}", ex);
                return false;
            }
        }
    }
}
