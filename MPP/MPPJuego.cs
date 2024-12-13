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
using System.IO;
using System.Globalization;

namespace MPP
{
    public class MPPJuego : IGestor<BEJuego>
    {
        

        string ruta = Configuracion.RutaArchivo;
        public bool Guardar(BEJuego oBeJuego,BEEmpleado usuario)
        {           
           int nuevoId;
           try
           {
               XDocument doc = XDocument.Load(ruta);
               if (oBeJuego.Id == 0)
               {
                   var ids = doc.Descendants("Juego")
                       .Select(e => (int)e.Attribute("cod_Juego"))
                       .ToList();


                   if (ids.Count > 0)
                   {
                       nuevoId = ids.Max() + 1;
                   }
                   else
                   {
                       nuevoId = 1;
                   }
                   XElement nuevoJuego = new XElement("Juego",
                       new XAttribute("cod_Juego", nuevoId),
                       new XElement("nombre", oBeJuego.Descripcion),
                       new XElement("categoria", oBeJuego.Categoria),
                       new XElement("precio", oBeJuego.Precio),
                       new XElement("cod_Proveedor", oBeJuego.bEProveedor.Id),
                       new XElement("stock", oBeJuego.Stock),
                       new XElement("cod_Estado", "A"),
                       new XElement("plataforma", oBeJuego.Plataforma)
               );
                   var JuegoElement = doc.Element("Empresa").Element("Juegos");
                   if (JuegoElement == null)
                   {
                        JuegoElement = new XElement("Juegos");
                       doc.Element("Empresa").Add(JuegoElement);
                   }
                   JuegoElement.Add(nuevoJuego);
                   doc.Save(ruta); 
                   Logger.Log($"Juego Guardado - ID: {oBeJuego.Id}, Nombre: {oBeJuego.Descripcion}, Categoria: {oBeJuego.Categoria}, Precio:{oBeJuego.Precio},Plataforma:{oBeJuego.Plataforma}. Guardado por ID: {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                   return true;
               }
               else
               {
                   var juego = doc.Descendants("Juego").FirstOrDefault(e => (int)e.Attribute("cod_Juego") == oBeJuego.Id);
                   juego.Element("nombre")?.SetValue(oBeJuego.Descripcion);
                   juego.Element("categoria")?.SetValue(oBeJuego.Categoria);
                   juego.Element("precio")?.SetValue(oBeJuego.Precio);
                   juego.Element("cod_Proveedor")?.SetValue(oBeJuego.bEProveedor.Id);
                   juego.Element("stock")?.SetValue(oBeJuego.Stock);
                   juego.Element("plataforma")?.SetValue(oBeJuego.Plataforma);
                   doc.Save(ruta);
                    Logger.Log($"Juego Modificado - ID: {oBeJuego.Id}, Nombre: {oBeJuego.Descripcion}, Categoria: {oBeJuego.Categoria}, Precio:{oBeJuego.Precio},Plataforma:{oBeJuego.Plataforma}. Modificado por ID: {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
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
        public List<BEJuego> ListarTodo()
        {
            DataTable dt = new DataTable();
            List<BEJuego> listaJuegos = new List<BEJuego>();

            try
            {
                if (File.Exists(ruta))
                {


                    XDocument xmlDoc = XDocument.Load(ruta);
                    var Juegos = xmlDoc.Descendants("Juego")
                        .Where(e => e.Element("cod_Estado")?.Value == "A");

                    if (Juegos.Any())
                    {
                        foreach (var Juego in Juegos)
                        {
                            BEJuego bEJuego = new BEJuego();
                            BEProveedor bEProveedor = new BEProveedor();
                            BEDomicilio bEDomicilio = new BEDomicilio();
                            bEJuego.Id = Convert.ToInt32(Juego.Attribute("cod_Juego")?.Value);
                            bEJuego.Descripcion = Juego.Element("nombre")?.Value;
                            bEJuego.Plataforma = Juego.Element("plataforma")?.Value;
                            bEJuego.Categoria = Juego.Element("categoria")?.Value;
                            bEJuego.Precio = Decimal.Parse(Juego.Element("precio")?.Value, CultureInfo.InvariantCulture);
                            bEJuego.Stock = Convert.ToInt32(Juego.Element("stock")?.Value);
                            bEJuego.CodEstado = Convert.ToChar(Juego.Element("cod_Estado")?.Value);
                            bEProveedor.Id = Convert.ToInt32(Juego.Element("cod_Proveedor")?.Value);
                            var proveedor = xmlDoc.Descendants("Proveedor")
                                .FirstOrDefault(d => d.Attribute("cod_Proveedor")?.Value == bEProveedor.Id.ToString());
                            if (proveedor != null)
                            {
                                bEProveedor.Nombre = proveedor.Element("nombre")?.Value.ToString();
                                bEDomicilio.Id = Convert.ToInt32(proveedor.Element("cod_Domicilio")?.Value);
                                bEProveedor.Domicilio = bEDomicilio;
                                bEProveedor.CodEstado = Convert.ToChar(proveedor.Element("cod_Estado")?.Value);
                            }
                            bEJuego.bEProveedor = bEProveedor;
                            listaJuegos.Add(bEJuego);
                        }  
                    } 
                }
                return listaJuegos;
            }
            catch (FileNotFoundException ex)
            {
                Logger.LogError("Error al traer juegos", ex);
                throw ex;
            }
            catch (IOException ex)
            {
                Logger.LogError("Error al traer juegos", ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al traer juegos", ex);
                throw ex;
            }
        }
        public bool Eliminar(BEJuego oBeJuego, BEEmpleado usuario)
        {
            try
            {
                XDocument doc = XDocument.Load(ruta);
                var Juego = doc.Descendants("Juego")
                          .FirstOrDefault(j => j.Attribute("cod_Juego")?.Value == oBeJuego.Id.ToString());
                if (Juego != null)
                {
                    Juego.Element("cod_Estado")?.SetValue("E");
                    doc.Save(ruta);
                    Logger.Log($"Juego Eliminado - ID: {oBeJuego.Id}, Nombre: {oBeJuego.Descripcion}, Categoria: {oBeJuego.Categoria}, Precio:{oBeJuego.Precio},Plataforma:{oBeJuego.Plataforma}, Eliminado por: codigo {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al traer juegos", ex);
                throw ex;
            }
        }
        public BEJuego ListarUno(BEJuego juego)
        {
            XDocument xmlDoc = XDocument.Load(ruta);
            BEProveedor proveedor = new BEProveedor();
            try
            {
                if (File.Exists(ruta))
                {
                    var Juego = xmlDoc.Descendants("Juego")
                         .FirstOrDefault(j => j.Attribute("cod_Juego")?.Value == juego.Id.ToString());
                    juego.Descripcion = Juego.Element("nombre")?.Value;
                    juego.Categoria = Juego.Element("categoria")?.Value;

                    juego.Plataforma = Juego.Element("plataforma")?.Value;
                    juego.Precio = Decimal.Parse(Juego.Element("precio")?.Value, CultureInfo.InvariantCulture);
                    juego.Stock = Convert.ToInt32(Juego.Element("stock")?.Value);
                    proveedor.Id = Convert.ToInt32(Juego.Element("cod_Proveedor")?.Value);
                    var proveedorJuego = xmlDoc.Descendants("Proveedor").FirstOrDefault(p => p.Attribute("cod_Proveedor")?.Value == proveedor.Id.ToString());
                    proveedor.Nombre = proveedorJuego.Element("nombre")?.Value;
                    juego.bEProveedor = proveedor;    
                }
                return juego;
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

        public bool guardarPedido(BEJuego juegoPedido, BEEmpleado usuario)
        {
            int nuevoId;
            DateTime hoy = DateTime.Now;
            try
            {
                XDocument xmlDoc = XDocument.Load(ruta);
                var ids = xmlDoc.Descendants("JuegoPedido")
                      .Select(e => (int)e.Attribute("cod_JuegoPedido"))
                      .ToList();
                if (ids.Count > 0)
                {
                    nuevoId = ids.Max() + 1;
                }
                else
                {
                    nuevoId = 1;
                }
                XElement nuevoJuego = new XElement("JuegoPedido",
                    new XAttribute("cod_JuegoPedido", nuevoId),
                    new XElement("nombre", juegoPedido.Descripcion),
                    new XElement("categoria", juegoPedido.Categoria),
                    new XElement("plataforma", juegoPedido.Plataforma),
                    new XElement("Cantidad",juegoPedido.Stock),
                    new XElement("Fecha",hoy.ToString("yyyy-MM-dd HH:mm:ss")),
                    new XElement("cod_Estado", "A")                   
            );
                var JuegosPedidosElement = xmlDoc.Element("Empresa").Element("JuegosPedidos");
                if (JuegosPedidosElement == null)
                {
                    JuegosPedidosElement = new XElement("JuegosPedidos");
                    xmlDoc.Element("Empresa").Add(JuegosPedidosElement);
                }
                JuegosPedidosElement.Add(nuevoJuego);
                xmlDoc.Save(ruta);
                Logger.Log($"Juego Pedido - ID: {nuevoId}, Nombre: {juegoPedido.Descripcion}, Categoria: {juegoPedido.Categoria}, Precio:{juegoPedido.Precio},Plataforma:{juegoPedido.Plataforma}, Cantidad: {juegoPedido.Stock}. Guardado por ID: {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                return true;
            }
            catch (System.IO.IOException ioEx)
            {
                Logger.LogError("Error al realizar guardado del pedido", ioEx);
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                Logger.LogError("Error al realizar guardado del pedido", xmlEx);
                throw xmlEx;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al realizar guardado del pedido", ex);
                throw ex;
            }
        }
       
        public bool EliminarReserva(BEJuego oBeJuego, BEEmpleado usuario)
        {
            try
            {
                XDocument doc = XDocument.Load(ruta);
                var Juego = doc.Descendants("JuegoPedido")
                          .FirstOrDefault(j => j.Attribute("cod_JuegoPedido")?.Value == oBeJuego.Id.ToString());
                if (Juego != null)
                {
                    Juego.Element("cod_Estado")?.SetValue("E");
                    doc.Save(ruta);
                    Logger.Log($"Juego Eliminado - ID: {oBeJuego.Id}, Nombre: {oBeJuego.Descripcion}, Categoria: {oBeJuego.Categoria}, Precio:{oBeJuego.Precio},Plataforma:{oBeJuego.Plataforma}, Eliminado por: codigo {usuario.Id}, {usuario.Apellido} {usuario.Nombre}, DNI: {usuario.DNI}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al traer juegos", ex);
                throw ex;
            }
        }
        public IEnumerable<dynamic> traerJuegosPedidos()
        {
            try
            {
                XDocument xmlDoc = XDocument.Load(ruta);
                List<dynamic> listaJuegosPedidos = new List<dynamic>();
                var JuegosPedidos = xmlDoc.Descendants("JuegoPedido")
                        .Where(jp => jp.Element("cod_Estado")?.Value == "A");
                foreach (var jp in JuegosPedidos)
                {
                    string formatoFecha = "yyyy-MM-dd HH:mm:ss";
                    string fechaPedidoStr = jp.Element("Fecha")?.Value;
                    DateTime fechaPedido;
                    if (!DateTime.TryParseExact(fechaPedidoStr, formatoFecha,
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None,
                        out fechaPedido))
                    {
                        fechaPedido = DateTime.MinValue;
                    }
                    var juego = new
                    {
                        Id = Convert.ToInt32(jp.Attribute("cod_JuegoPedido")?.Value),
                        Descripcion = Convert.ToString(jp.Element("nombre")?.Value),
                        Categoria = Convert.ToString(jp.Element("categoria")?.Value),
                        Plataforma = Convert.ToString(jp.Element("plataforma")?.Value),
                        FechaPedido = fechaPedido,
                        Cantidad = jp.Element("Cantidad")?.Value,
                        Cod_Estado = jp.Element("cod_Estado")?.Value,
                    };
                    listaJuegosPedidos.Add(juego);
                }
                return listaJuegosPedidos;
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
        public IEnumerable<dynamic> traerJuegosPedidosFiltro(BEJuego juego)
        {
            XDocument xmlDoc = XDocument.Load(ruta);
            try
            {
                    List<dynamic> listaJuegos = new List<dynamic>();
                    var juegos = xmlDoc.Descendants("JuegoPedido").Where(j =>
                        (string.IsNullOrEmpty(juego.Plataforma) || j.Element("plataforma").Value == juego.Plataforma) &&
                        (string.IsNullOrEmpty(juego.Categoria) || j.Element("categoria").Value == juego.Categoria) && Convert.ToInt32(j.Element("Cantidad").Value) > 0 && j.Element("cod_Estado").Value == "A"
                    );
                    foreach (var jp in juegos)
                    {
                        string formatoFecha = "yyyy-MM-dd HH:mm:ss";
                        string fechaPedidoStr = jp.Element("Fecha")?.Value;
                        DateTime fechaPedido;
                        if (!DateTime.TryParseExact(fechaPedidoStr, formatoFecha,
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out fechaPedido))
                        {
                            fechaPedido = DateTime.MinValue;
                        }
                        var juegosPedidos = new
                        {
                            Id = Convert.ToInt32(jp.Attribute("cod_JuegoPedido")?.Value),
                            Descripcion = Convert.ToString(jp.Element("nombre")?.Value),
                            Categoria = Convert.ToString(jp.Element("categoria")?.Value),
                            Plataforma = Convert.ToString(jp.Element("plataforma")?.Value),
                            FechaPedido = fechaPedido,
                            Cantidad = jp.Element("Cantidad")?.Value,
                            Cod_Estado = jp.Element("cod_Estado")?.Value,
                        };
                        listaJuegos.Add(juegosPedidos);
                    }
                    return listaJuegos;
            }
            catch (FileNotFoundException ex)
            {
                Logger.LogError("Error al traer juegos", ex);
                throw ex;
            }
            catch (IOException ex)
            {
                Logger.LogError("Error al traer juegos", ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al traer juegos", ex);
                throw ex;
            }

        }
        public List<BEJuego> buscarJuegos(BEJuego juego)
        {
            XDocument xmlDoc = XDocument.Load(ruta);
            try
            {
                List<BEJuego> listaJuegos = new List<BEJuego>();
                if (string.IsNullOrEmpty(juego.Descripcion) && string.IsNullOrEmpty(juego.Plataforma) && string.IsNullOrEmpty(juego.Categoria))
                {
                    return listaJuegos = this.ListarTodo();
                }
                else
                {
                    var juegos = xmlDoc.Descendants("Juego").Where(j =>
                           
                             (string.IsNullOrEmpty(juego.Descripcion) || (j.Element("nombre") != null && j.Element("nombre").Value == juego.Descripcion)) &&
                             (string.IsNullOrEmpty(juego.Plataforma) || (j.Element("plataforma") != null && j.Element("plataforma").Value == juego.Plataforma)) &&
                             (string.IsNullOrEmpty(juego.Categoria) || (j.Element("categoria") != null && j.Element("categoria").Value == juego.Categoria)) &&
                             (j.Element("stock") != null && int.TryParse(j.Element("stock").Value, out int stock) && stock > 0) &&
                             (j.Element("cod_Estado") != null && j.Element("cod_Estado").Value == "A")
                         ).ToList();
                    foreach (var j in juegos)
                    {
                        BEJuego bEJuego = new BEJuego();
                        BEProveedor bEProveedor = new BEProveedor();
                        BEDomicilio bEDomicilio = new BEDomicilio();
                        bEJuego.Id = Convert.ToInt32(j.Attribute("cod_Juego").Value);
                        bEJuego.Descripcion = j.Element("nombre").Value;
                        bEJuego.Plataforma = j.Element("plataforma").Value;
                        bEJuego.Categoria = j.Element("categoria").Value;
                        bEJuego.Stock = Convert.ToInt32(j.Element("stock").Value);
                        bEJuego.Precio = Convert.ToDecimal(j.Element("precio").Value);
                        bEProveedor.Id = Convert.ToInt32(j.Element("cod_Proveedor")?.Value);

                        var proveedor = xmlDoc.Descendants("Proveedor")
                            .FirstOrDefault(d => d.Attribute("cod_Proveedor")?.Value == bEProveedor.Id.ToString());
                        if (proveedor != null)
                        {
                            bEProveedor.Nombre = proveedor.Element("nombre")?.Value.ToString();
                            bEDomicilio.Id = Convert.ToInt32(proveedor.Element("cod_Domicilio")?.Value);
                            bEProveedor.Domicilio = bEDomicilio;
                            bEProveedor.CodEstado = Convert.ToChar(proveedor.Element("cod_Estado")?.Value);
                        }
                        bEJuego.bEProveedor = bEProveedor;

                        listaJuegos.Add(bEJuego);

                    }
                    return listaJuegos;
                }  
            }
            catch (FileNotFoundException ex)
            {
                Logger.LogError("Error al traer juegos", ex);
                throw ex;
            }
            catch (IOException ex)
            {
                Logger.LogError("Error al traer juegos", ex);
                throw ex;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al traer juegos", ex);
                throw ex;
            }
        }
        
        public bool Eliminar(BEJuego obj)
        {
            throw new NotImplementedException();
        }

        public bool Guardar(BEJuego obj)
        {
            throw new NotImplementedException();
        }
    }
}
