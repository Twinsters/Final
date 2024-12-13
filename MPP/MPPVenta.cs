using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

using DB;
using System.Collections;
using System.Xml.Linq;
using System.Globalization;

namespace MPP
{
    public class MPPVenta
    {
        string ruta = Configuracion.RutaArchivo;
        public bool eliminarVentas(int Id, BEEmpleado Usuario)
        {
            XDocument doc = XDocument.Load(ruta);
            try
            {
                var venta = doc.Descendants("Venta")
                    .FirstOrDefault(e => e.Element("cod_Estado")?.Value == "A" &&
                          int.TryParse(e.Attribute("cod_Venta")?.Value, out int codVenta) &&
                          codVenta == Id);
                var codEstadoElement = venta.Element("cod_Estado");
                codEstadoElement.Value = "E";
                doc.Save(ruta);
                var juego = doc.Descendants("Juego").FirstOrDefault(j => j.Attribute("cod_Juego")?.Value == venta.Element("cod_Juego").Value && j.Element("cod_Estado")?.Value == "A");
                var stockElement = juego.Element("stock");
                int stockValue = Convert.ToInt32(stockElement.Value);
                stockValue++;
                stockElement.Value = stockValue.ToString();
                doc.Save(ruta);
                Logger.Log($"Se Realizo la eliminacion de la venta por: ID:{Usuario.Id}, {Usuario.Apellido + Usuario.Nombre}, DNI: {Usuario.DNI} ");
                return true;
                
            }
            catch (System.IO.IOException ioEx)
            {
                Logger.LogError("Error al eliminar la venta", ioEx);
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                Logger.LogError("Error al eliminar la venta", xmlEx);
                throw xmlEx;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al eliminar la venta", ex);
                throw ex;
            }
        }

        public List<BEVenta> ListarTodo()
        {
            try
            {
                XDocument doc = XDocument.Load(ruta);
               List<BEVenta> listaVenta = new List<BEVenta>();

                var ventas = doc.Descendants("Venta")
                 .Where(e => e.Element("cod_Estado")?.Value == "A");

                foreach (var venta in ventas) 
                {
                    BEEmpleado beEmpleado = new BEEmpleado();
                    BEVenta beVenta = new BEVenta();
                    BEJuego beJuego = new BEJuego();
                    BEPersona beCliente = new BEPersona();

                    beVenta.Id = Convert.ToInt32(venta.Attribute("cod_Venta")?.Value);
                    beVenta.Pago = Decimal.Parse(venta.Element("pago")?.Value, CultureInfo.InvariantCulture);

                    string formatoFecha = "yyyy-MM-dd HH:mm:ss";
                    string fechaString = venta.Element("fecha")?.Value;
                    if (DateTime.TryParseExact(fechaString, formatoFecha,
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out DateTime fechaCompra))
                    {
                        beVenta.FechaCompra = fechaCompra;
                    }

                    beJuego.Id = Convert.ToInt32(venta.Element("cod_Juego")?.Value);
                    var juego = doc.Descendants("Juego")
                                   .FirstOrDefault(j => j.Attribute("cod_Juego")?.Value == beJuego.Id.ToString());
                    if (juego != null)
                    {
                        beJuego.Descripcion = juego.Element("nombre")?.Value;
                        beJuego.Plataforma = juego.Element("plataforma")?.Value;
                        beJuego.Categoria = juego.Element("categoria")?.Value;
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el Juego correspondiente.");
                    }

                    beCliente.Id = Convert.ToInt32(venta.Element("cod_Cliente")?.Value);
                    var cliente = doc.Descendants("Cliente")
                                     .FirstOrDefault(c => c.Attribute("cod_Cliente")?.Value == beCliente.Id.ToString());
                    if (cliente != null)
                    {
                        beCliente.Nombre = cliente.Element("nombre")?.Value;
                        beCliente.Apellido = cliente.Element("apellido")?.Value;
                        beCliente.DNI = Convert.ToInt32(cliente.Element("DNI")?.Value);
                    }
                    else
                    {
                        Console.WriteLine("No se encontró el cliente correspondiente.");
                    }

                    beVenta.bEJuego = beJuego;
                    beVenta.bECliente = beCliente;
                    listaVenta.Add(beVenta);
                }

                return listaVenta;

            }
            catch (System.IO.IOException ioEx)
            {
                Logger.LogError("Error al realizar la busqueda", ioEx);
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                Logger.LogError("Error al realizar la busqueda", xmlEx);
                throw xmlEx;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al realizar la busqueda", ex);
                throw ex;
            }

        }
        public BEEmpleado VerEmpleadoVenta(BEVenta obBeVenta)
        {

            BEEmpleado empleadoVenta;
            try
            {
                XDocument doc = XDocument.Load(ruta);
                var registro = doc.Descendants("Registro").FirstOrDefault(r => (int)r.Element("cod_Venta") == obBeVenta.Id);
                var empleado = doc.Descendants("Empleado").FirstOrDefault(e => (int)e.Attribute("cod_Empleado") == Convert.ToInt32(registro.Element("cod_Empleado").Value));

                empleadoVenta = new BEEmpleado();
                empleadoVenta.Id = Convert.ToInt32(empleado.Attribute("cod_Empleado")?.Value);
                empleadoVenta.Nombre = empleado.Element("nombre")?.Value;
                empleadoVenta.Apellido = empleado.Element("apellido")?.Value;
                empleadoVenta.DNI =Convert.ToInt32(empleado.Element("DNI")?.Value);

                return empleadoVenta;
            }
            catch (System.IO.IOException ioEx)
            {
                Logger.LogError("Error al realizar la busqueda", ioEx);
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                Logger.LogError("Error al realizar la busqueda", xmlEx);
                throw xmlEx;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al realizar la busqueda", ex);
                throw ex;
            }
        }
        public bool GuardarCompleto(BEVenta obBeVenta,BEEmpleado obBeEmpleado)
        {
            string fechaFormateada = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int nuevoId;
            try
            {
                XDocument doc = XDocument.Load(ruta);
                if (obBeVenta.Id == 0)
                {
                    var ids = doc.Descendants("Venta")
                        .Select(e => (int)e.Attribute("cod_Venta"))
                        .ToList();

                    if (ids.Count > 0)
                    {
                        nuevoId = ids.Max() + 1;
                    }
                    else
                    {
                        nuevoId = 1;
                    }
                    XElement nuevaVenta = new XElement("Venta",
                        new XAttribute("cod_Venta", nuevoId),
                        new XElement("cod_Cliente", obBeVenta.bECliente.Id),
                        new XElement("cod_Juego", obBeVenta.bEJuego.Id),
                        new XElement("fecha", fechaFormateada),
                        new XElement("cod_Estado", "A"),
                        new XElement("pago", obBeVenta.Pago)
                );
                    var VentaElement = doc.Element("Empresa").Element("Ventas");
                    if (VentaElement == null)
                    {
                        VentaElement = new XElement("Ventas");
                        doc.Element("Empresa").Add(VentaElement);
                    }
                    VentaElement.Add(nuevaVenta);
                    doc.Save(ruta);
                    Logger.Log($"Venta realizada - ID: {nuevoId}, Cliente: {obBeVenta.bECliente.Id}, Monto: {obBeVenta.Pago:C}");
                    XElement nuevaEmpleadoVenta = new XElement("Registro",
                        new XElement("cod_Venta", nuevoId),
                        new XElement("cod_Empleado", obBeEmpleado.Id)
                            );
                    var EmpleadoVentaElement = doc.Element("Empresa").Element("Empleado_Ventas");
                    if (EmpleadoVentaElement == null)
                    {
                        EmpleadoVentaElement = new XElement("Empleado_Ventas");
                        doc.Element("Empresa").Add(EmpleadoVentaElement);
                    }
                    EmpleadoVentaElement.Add(nuevaEmpleadoVenta);
                    doc.Save(ruta);
                    var juego = doc.Descendants("Juego").FirstOrDefault(j => Convert.ToInt32(j.Attribute("cod_Juego").Value) == obBeVenta.bEJuego.Id && j.Element("cod_Estado").Value == "A");
                    var stockElement = juego.Element("stock");
                    int stockValue = Convert.ToInt32(stockElement.Value);
                    stockValue--;
                    stockElement.Value = stockValue.ToString();
                    doc.Save(ruta);
                    Logger.Log($"Registro Guardado - ID Venta: {nuevoId}, ID Empleado: {obBeEmpleado.Id}, {obBeEmpleado.Apellido} {obBeEmpleado.Nombre}, DNI {obBeEmpleado.DNI}");
                    return true;
                }
                else
                {
                    var venta = doc.Descendants("Venta").FirstOrDefault(e => (int)e.Attribute("cod_Venta") == obBeVenta.Id);
                    venta.Element("cod_Cliente")?.SetValue(obBeVenta.bECliente.Id);
                    venta.Element("cod_Juego")?.SetValue(obBeVenta.bEJuego.Id);
                    venta.Element("fecha")?.SetValue(obBeVenta.FechaCompra.ToString("yyyy-MM-dd"));
                    venta.Element("cod_Estado")?.SetValue("A");
                    venta.Element("pago")?.SetValue(obBeVenta.Pago);
                    doc.Save(ruta);
                    Logger.Log($"Venta Modificada - ID: {obBeVenta.Id}, Cliente: {obBeVenta.bECliente.Id}, Monto: {obBeVenta.Pago:C}, Empleado:{obBeEmpleado.Id}, {obBeEmpleado.Apellido} {obBeEmpleado.Nombre}, DNI {obBeEmpleado.DNI}");
                    return true;
                }
            }
            catch (System.IO.IOException ioEx)
            {
                Logger.LogError("Error al realizar la venta", ioEx);
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                Logger.LogError("Error al realizar la venta", xmlEx);
                throw xmlEx;
            }
            catch (Exception ex)
            {
                Logger.LogError("Error al realizar la venta", ex);
                throw ex;
            }
        }
    
        public string VentasDiaHoy(int opcion,List<DateTime> rangoFechas = null)
        {
            try
            {
                XDocument doc = XDocument.Load(ruta);
                DateTime hoy = DateTime.Today;              
                switch (opcion) 
                {
                    case 1:
                        int cantidadVentasHoy = doc.Descendants("Venta")
                                          .Count(venta => DateTime.Parse(venta.Element("fecha").Value).Date == hoy);

                        return cantidadVentasHoy.ToString();
                        
                    case 2:
                        DateTime inicioSemana = hoy.AddDays(-(int)hoy.DayOfWeek + 1);
                        DateTime finSemana = inicioSemana.AddDays(7);

                        int cantidadVentas = doc.Descendants("Venta")
                            .Count(venta =>
                            {
                                DateTime fechaVenta = (DateTime)venta.Element("fecha");
                                return fechaVenta >= inicioSemana && fechaVenta < finSemana;
                            });
                        return cantidadVentas.ToString();
                    case 3:
                        DateTime fechaLimite = hoy.AddDays(-30);
                        var cantidadVentastreinta = doc.Descendants("Venta")
                           .Where(v => DateTime.Parse(v.Element("fecha").Value) >= fechaLimite)
                           .Count();
                        return cantidadVentastreinta.ToString();
                    case 4:
                       DateTime primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
                        int ventasEsteMes = doc.Descendants("Venta")
                                                .Where(v =>
                                                {
                                                  DateTime fechaVenta;
                                                    return DateTime.TryParse(v.Element("fecha").Value, out fechaVenta) &&
                                                           fechaVenta.Date >= primerDiaDelMes.Date && fechaVenta.Date <= hoy.Date;
                                                })
                                                .Count();
                        return ventasEsteMes.ToString();
                    case 5:
                        int cantidadVentasRango = doc.Descendants("Venta")
                            .Count(venta =>
                            {
                                DateTime fechaVenta = (DateTime)venta.Element("fecha");
                                fechaVenta = fechaVenta.Date;
                                DateTime rangoInicio = rangoFechas[0].Date;
                                DateTime rangoFin = rangoFechas[1].Date;
                                return fechaVenta >= rangoInicio && fechaVenta <= rangoFin;
                            });
                        return cantidadVentasRango.ToString();
                    default:
                        return null;                   
                }
            }
            catch (System.IO.FileNotFoundException ioEx)
            {
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                throw xmlEx;
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string GananciasDia(int opcion, List<DateTime> rangoFechas = null)
        {
            try
            {
                XDocument doc = XDocument.Load(ruta);
                DateTime hoy = DateTime.Today;
                switch (opcion)
                {
                    case 1:
                        var totalVentasHoy = doc.Descendants("Venta")
                                      .Where(venta => DateTime.Parse(venta.Element("fecha").Value).Date == hoy)
                                      .Sum(venta => (decimal)venta.Element("pago"));
                        return totalVentasHoy.ToString();
                    case 2:
                        DateTime inicioSemana = hoy.AddDays(-(int)hoy.DayOfWeek + 1);
                        DateTime finSemana = inicioSemana.AddDays(7);
                        var totalVentasSemana = doc.Descendants("Venta")
                                    .Where(venta => (DateTime)venta.Element("fecha") >= inicioSemana && (DateTime)venta.Element("fecha") < finSemana)
                                    .Sum(venta => (decimal)venta.Element("pago"));
                        return totalVentasSemana.ToString();
                    case 3:
                        DateTime fechaLimite = hoy.AddDays(-30);
                        var totalVentasTreinta = doc.Descendants("Venta")
                                   .Where(venta => (DateTime)venta.Element("fecha") >= fechaLimite)
                                   .Sum(venta => (decimal)venta.Element("pago"));
                        return totalVentasTreinta.ToString();
                    case 4:
                        DateTime primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
                        decimal totalVentasMes = doc.Descendants("Venta")
                                               .Where(v =>
                                               {
                                                   DateTime fechaVenta;
                                                   return DateTime.TryParse(v.Element("fecha").Value, out fechaVenta) &&
                                                          fechaVenta.Date >= primerDiaDelMes.Date && fechaVenta.Date <= hoy.Date;
                                               }).Sum(venta => (decimal)venta.Element("pago"));
                        return totalVentasMes.ToString();
                    case 5:
                        DateTime rangoInicio = rangoFechas[0].Date;
                        DateTime rangoFin = rangoFechas[1].Date;
                        decimal totalVentasRango = doc.Descendants("Venta")
                                              .Where(v =>
                                              {
                                                  DateTime fechaVenta;
                                                  return DateTime.TryParse(v.Element("fecha").Value, out fechaVenta) &&
                                                         fechaVenta.Date >= rangoInicio.Date && fechaVenta.Date <= rangoFin;
                                              }).Sum(venta => (decimal)venta.Element("pago"));


                        return totalVentasRango.ToString();
                    default:
                        return null;
                }
            }
            catch (System.IO.FileNotFoundException ioEx)
            {
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                throw xmlEx;
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public Dictionary<string,int> VentaPorCategoria(int opcion, List<DateTime> rangoFechas = null)
        {
            XElement doc = XElement.Load(ruta);
            var ventasPorCategoria = new Dictionary<string, int>();
            DateTime hoy = DateTime.Today;
            try
            {
                switch (opcion)
                {
                    case 1:

                        var ventashoy = doc.Descendants("Venta")
                                            .Where(venta =>
                                            {
                                                DateTime fechaVenta;
                                                return DateTime.TryParse((string)venta.Element("fecha"), out fechaVenta) &&
                                                       fechaVenta.Date == hoy.Date;  // Comparar solo la parte de la fecha
                                            });

                        foreach (var venta in ventashoy)
                        {
                            string codJuego = (string)venta.Element("cod_Juego");
                            var juego = doc.Descendants("Juego")
                                           .FirstOrDefault(emp => (string)emp.Attribute("cod_Juego") == codJuego);
                            if (juego != null)
                            {
                                string juegoCategoria = (string)juego.Element("categoria");
                                if (ventasPorCategoria.ContainsKey(juegoCategoria))
                                {
                                    ventasPorCategoria[juegoCategoria]++;
                                }
                                else
                                {
                                    ventasPorCategoria[juegoCategoria] = 1;
                                }
                            }
                        }
                        return ventasPorCategoria;
                    case 2:
                        DateTime inicioSemana = hoy.AddDays(-(int)hoy.DayOfWeek + 1);
                        DateTime finSemana = inicioSemana.AddDays(7);
                        var ventasSemana = doc.Descendants("Venta")
                            .Where(venta =>
                            {
                                DateTime fechaVenta;
                                return DateTime.TryParse((string)venta.Element("fecha"), out fechaVenta) &&
                                       fechaVenta >= inicioSemana && fechaVenta < finSemana;
                            });
                        foreach (var venta in ventasSemana)
                        {
                            string codJuego = (string)venta.Element("cod_Juego");


                            var juego = doc.Descendants("Juego")
                                .FirstOrDefault(emp => (string)emp.Attribute("cod_Juego") == codJuego);

                            if (juego != null)
                            {
                                string juegoCateogoria = (string)juego.Element("categoria");
                                if (ventasPorCategoria.ContainsKey(juegoCateogoria))
                                {
                                    ventasPorCategoria[juegoCateogoria]++;
                                }
                                else
                                {
                                    ventasPorCategoria[juegoCateogoria] = 1;
                                }
                            }

                        }

                        return ventasPorCategoria;
                    case 3:

                        DateTime fechaLimite = hoy.AddDays(-30);
                        var ventasTreinta = doc.Descendants("Venta")
                             .Where(venta =>
                             {
                                 DateTime fechaVenta;
                                 return DateTime.TryParse((string)venta.Element("fecha"), out fechaVenta) &&
                                        fechaVenta >= fechaLimite;
                             });
                        foreach (var venta in ventasTreinta)
                        {
                            string codJuego = (string)venta.Element("cod_Juego");
                            var juego = doc.Descendants("Juego")
                                .FirstOrDefault(emp => (string)emp.Attribute("cod_Juego") == codJuego);

                            if (juego != null)
                            {
                                string juegoCateogoria = (string)juego.Element("categoria");
                                if (ventasPorCategoria.ContainsKey(juegoCateogoria))
                                {
                                    ventasPorCategoria[juegoCateogoria]++;
                                }
                                else
                                {
                                    ventasPorCategoria[juegoCateogoria] = 1;
                                }
                            }           
                        }
                        return ventasPorCategoria;
                    case 4:
                        DateTime primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
                        var ventasMes = doc.Descendants("Venta")
                             .Where(venta =>
                             {
                                 DateTime fechaVenta;
                                 return DateTime.TryParse((string)venta.Element("fecha"), out fechaVenta) &&
                                        fechaVenta >= primerDiaDelMes;
                             });
                        foreach (var venta in ventasMes)
                        {
                            string codJuego = (string)venta.Element("cod_Juego");
                            var juego = doc.Descendants("Juego")
                                .FirstOrDefault(emp => (string)emp.Attribute("cod_Juego") == codJuego);

                            if (juego != null)
                            {
                                string juegoCateogoria = (string)juego.Element("categoria");
                                if (ventasPorCategoria.ContainsKey(juegoCateogoria))
                                {
                                    ventasPorCategoria[juegoCateogoria]++;
                                }
                                else
                                {
                                    ventasPorCategoria[juegoCateogoria] = 1;
                                }
                            }
                        }
                        return ventasPorCategoria;
                    case 5:
                        DateTime fechaVentaRango;
                        DateTime rangoInicio = rangoFechas[0].Date;
                        DateTime rangoFin = rangoFechas[1].Date;
                        var juegosDict = doc.Descendants("Juego")
                            .ToDictionary(juego => (string)juego.Attribute("cod_Juego"), juego => (string)juego.Element("categoria"));

                        var ventasRango = doc.Descendants("Venta")
                            .Where(venta =>
                            {
                                if (DateTime.TryParse((string)venta.Element("fecha"), out fechaVentaRango))
                                {
                                    fechaVentaRango = fechaVentaRango.Date;
                                    return fechaVentaRango >= rangoInicio && fechaVentaRango <= rangoFin;
                                }
                                return false;
                            });

                        foreach (var venta in ventasRango)
                        {
                            string codJuego = (string)venta.Element("cod_Juego");
                            if (juegosDict.TryGetValue(codJuego, out string categoria))
                            {
                                if (ventasPorCategoria.ContainsKey(categoria))
                                {
                                    ventasPorCategoria[categoria]++;
                                }
                                else
                                {
                                    ventasPorCategoria[categoria] = 1;
                                }
                            }
                        }
                        return ventasPorCategoria;
                    default:
                        return null;

                }
            }

            catch (System.IO.FileNotFoundException ioEx)
            {
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                throw xmlEx;
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Dictionary<string, int> VentasPorVendedor(int opcion, List<DateTime> rangoFechas = null)
        {
            var ventasPorVendedor = new Dictionary<string, int>();
            try
            {
                XDocument doc = XDocument.Load(ruta);
                DateTime hoy = DateTime.Today;
                switch (opcion)
                {
                    case 1:
                        var ventasHoy = doc.Descendants("Venta")
                                           .Where(venta => DateTime.Parse(venta.Element("fecha").Value).Date == hoy)
                                           .Select(venta => (string)venta.Attribute("cod_Venta"));
                        var resultados = from registro in doc.Descendants("Registro")
                                         where ventasHoy.Contains((string)registro.Element("cod_Venta"))
                                         group registro by (string)registro.Element("cod_Empleado") into g
                                         select new
                                         {
                                             CodEmpleado = g.Key,
                                             CantidadVentas = g.Count()
                                         };
                        foreach (var item in resultados)
                        {
                            var nombreEmpleado = doc.Descendants("Empleado")
                                                    .FirstOrDefault(e => (string)e.Attribute("cod_Empleado") == item.CodEmpleado);

                            string nombre = nombreEmpleado != null
                                ? $"{nombreEmpleado.Element("nombre").Value} {nombreEmpleado.Element("apellido").Value}"
                                : "Desconocido";
                            ventasPorVendedor[nombre] = item.CantidadVentas;
                        }
                        return ventasPorVendedor;
                    case 2:
                        DateTime inicioSemana = hoy.AddDays(-(int)hoy.DayOfWeek + 1); 
                        DateTime finSemana = inicioSemana.AddDays(7); 
                        var ventas = doc.Descendants("Venta")
                            .Where(venta =>
                            {
                                DateTime fechaVenta;
                                return DateTime.TryParse((string)venta.Element("fecha"), out fechaVenta) &&
                                       fechaVenta >= inicioSemana && fechaVenta < finSemana;
                            });
                        foreach (var venta in ventas)
                        {
                            string codVenta = (string)venta.Attribute("cod_Venta");
                            var registros = doc.Descendants("Registro")
                                     .Where(r => (string)r.Element("cod_Venta") == codVenta)
                                     .ToList();
                            foreach (var registro in registros)
                            {
                                string codEmpleado = (string)registro.Element("cod_Empleado");
                                var empleado = doc.Descendants("Empleado")
                                    .FirstOrDefault(emp => (string)emp.Attribute("cod_Empleado") == codEmpleado);
                                if (empleado != null)
                                {
                                    string nombreEmpleado = (string)empleado.Element("nombre");
                                    string apellidoEmpleado = (string)empleado.Element("apellido");
                                    string nombreCompleto = $"{nombreEmpleado} {apellidoEmpleado}";
                                    if (ventasPorVendedor.ContainsKey(nombreCompleto))
                                    {
                                        ventasPorVendedor[nombreCompleto]++;
                                    }
                                    else
                                    {
                                        ventasPorVendedor[nombreCompleto] = 1;
                                    }
                                }
                            }
                        }

                        return ventasPorVendedor;
                    case 3:
                        DateTime fechaLimite = hoy.AddDays(-30);
                        var ventasTreinta = doc.Descendants("Venta")
                            .Where(venta =>
                            {
                                DateTime fechaVenta;
                                return DateTime.TryParse((string)venta.Element("fecha"), out fechaVenta) &&
                                       fechaVenta >= fechaLimite;
                            });
                        foreach (var venta in ventasTreinta)
                        {
                            string codVenta = (string)venta.Attribute("cod_Venta");
                            var registros = doc.Descendants("Registro")
                                     .Where(r => (string)r.Element("cod_Venta") == codVenta)
                                     .ToList();
                            foreach (var registro in registros)
                            {
                                string codEmpleado = (string)registro.Element("cod_Empleado");
                                var empleado = doc.Descendants("Empleado")
                                    .FirstOrDefault(emp => (string)emp.Attribute("cod_Empleado") == codEmpleado);
                                if (empleado != null)
                                {
                                    string nombreEmpleado = (string)empleado.Element("nombre");
                                    string apellidoEmpleado = (string)empleado.Element("apellido");
                                    string nombreCompleto = $"{nombreEmpleado} {apellidoEmpleado}";
                                    if (ventasPorVendedor.ContainsKey(nombreCompleto))
                                    {
                                        ventasPorVendedor[nombreCompleto]++;
                                    }
                                    else
                                    {
                                        ventasPorVendedor[nombreCompleto] = 1;
                                    }
                                }
                            }
                        }

                        return ventasPorVendedor;
                    case 4:
                        DateTime primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
                        var ventasMes = doc.Descendants("Venta")
                            .Where(venta =>
                            {
                                DateTime fechaVenta;
                                return DateTime.TryParse((string)venta.Element("fecha"), out fechaVenta) &&
                                       fechaVenta >= primerDiaDelMes;
                            });
                        foreach (var venta in ventasMes)
                        {
                            string codVenta = (string)venta.Attribute("cod_Venta");
                            var registros = doc.Descendants("Registro")
                                     .Where(r => (string)r.Element("cod_Venta") == codVenta)
                                     .ToList();
                            foreach (var registro in registros)
                            {
                                string codEmpleado = (string)registro.Element("cod_Empleado");
                                var empleado = doc.Descendants("Empleado")
                                    .FirstOrDefault(emp => (string)emp.Attribute("cod_Empleado") == codEmpleado);
                                if (empleado != null)
                                {
                                    string nombreEmpleado = (string)empleado.Element("nombre");
                                    string apellidoEmpleado = (string)empleado.Element("apellido");
                                    string nombreCompleto = $"{nombreEmpleado} {apellidoEmpleado}";
                                    if (ventasPorVendedor.ContainsKey(nombreCompleto))
                                    {
                                        ventasPorVendedor[nombreCompleto]++;
                                    }
                                    else
                                    {
                                        ventasPorVendedor[nombreCompleto] = 1;
                                    }
                                }
                            }
                        }

                        return ventasPorVendedor;
                    case 5:
                        var empleadosDict = doc.Descendants("Empleado")
                                .ToDictionary(emp => (string)emp.Attribute("cod_Empleado"), emp =>
                                {
                                    return $"{(string)emp.Element("nombre")} {(string)emp.Element("apellido")}";
                                });
                        DateTime rangoInicio = rangoFechas[0].Date;
                        DateTime rangoFin = rangoFechas[1].Date;
                        var ventasRango = doc.Descendants("Venta")
                            .Where(venta =>
                            {
                                DateTime fechaVentaRango;
                                return DateTime.TryParse((string)venta.Element("fecha"), out fechaVentaRango) &&
                                       fechaVentaRango.Date >= rangoInicio && fechaVentaRango.Date <= rangoFin;
                            });
                        foreach (var venta in ventasRango)
                        {
                            string codVenta = (string)venta.Attribute("cod_Venta");
                            var registros = doc.Descendants("Registro")
                                .Where(r => (string)r.Element("cod_Venta") == codVenta)
                                .ToList();
                            foreach (var registro in registros)
                            {
                                string codEmpleado = (string)registro.Element("cod_Empleado");
                                if (empleadosDict.TryGetValue(codEmpleado, out string nombreCompleto))
                                {
                                    if (ventasPorVendedor.ContainsKey(nombreCompleto))
                                    {
                                        ventasPorVendedor[nombreCompleto]++;
                                    }
                                    else
                                    {
                                        ventasPorVendedor[nombreCompleto] = 1;
                                    }
                                }
                            }
                        }
                        return ventasPorVendedor;
                    default:
                        return null;
                }
            }
            catch (System.IO.FileNotFoundException ioEx)
            {
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                throw xmlEx;
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BEJuego> ObtenerJuegosConPocoStock()
        {
            List<BEJuego> juegosConPocoStock = new List<BEJuego>();
          
            try
            {
                XDocument doc = XDocument.Load(ruta);
               ;
                juegosConPocoStock = doc.Descendants("Juego")
                    .Where(juego => (int)juego.Element("stock") <= 5)
                    .Select(juego => new BEJuego
                    {
                        Id = (int)juego.Attribute("cod_Juego"),
                        Descripcion = (string)juego.Element("nombre"),
                        Categoria = (string)juego.Element("categoria"),
                        Plataforma = (string)juego.Element("plataforma"),
                        Stock = (int)juego.Element("stock"),
                        Precio = (decimal)juego.Element("precio")
                       
                    }).ToList();
            }
            catch (System.IO.FileNotFoundException ioEx)
            {
                throw ioEx;
            }
            catch (System.Xml.XmlException xmlEx)
            {
                throw xmlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return juegosConPocoStock;
        }

        public List<BEJuego> TopVentas()
        {
            XDocument doc = XDocument.Load(ruta);
            DateTime hoy = DateTime.Today;

            try
            {
                DateTime inicioMes = new DateTime(hoy.Year, hoy.Month, 1);
                DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);

                var juegosConVentas = from venta in doc.Descendants("Venta")
                                      join juego in doc.Descendants("Juego")
                                      on (int)venta.Element("cod_Juego") equals (int)juego.Attribute("cod_Juego")
                                      where (DateTime)venta.Element("fecha") >= inicioMes && (DateTime)venta.Element("fecha") <= finMes
                                      group venta by new
                                      {
                                          Id = juego.Attribute("cod_Juego").Value,
                                          JuegoNombre = juego.Element("nombre").Value,
                                          Plataforma = juego.Element("plataforma").Value,
                                          Categoria = juego.Element("categoria")?.Value
                                      } into ventasPorJuego
                                      let totalVentas = ventasPorJuego.Count()
                                      orderby totalVentas descending
                                      select new BEJuego
                                      {
                                          Id = Convert.ToInt32(ventasPorJuego.Key.Id),
                                          Descripcion = ventasPorJuego.Key.JuegoNombre,
                                          Plataforma = ventasPorJuego.Key.Plataforma,
                                          Categoria = ventasPorJuego.Key.Categoria,
                                          Stock = totalVentas
                                      };

                return juegosConVentas.Take(5).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar las ventas", ex);
            }
        }
        public List<BEEmpleado> TopVentasEmpleados()
        {
            XDocument doc = XDocument.Load(ruta);
            DateTime hoy = DateTime.Today;

            try
            {
               
                DateTime inicioMes = new DateTime(hoy.Year, hoy.Month, 1);
                DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);

                var empleadosConVentas = from venta in doc.Descendants("Venta")
                                         join registro in doc.Descendants("Registro")
                                         on (int)venta.Attribute("cod_Venta") equals (int)registro.Element("cod_Venta")
                                         join empleado in doc.Descendants("Empleado")
                                         on (int)registro.Element("cod_Empleado") equals (int)empleado.Attribute("cod_Empleado")
                                         where (DateTime)venta.Element("fecha") >= inicioMes && (DateTime)venta.Element("fecha") <= finMes
                                         group venta by new
                                         {
                                             EmpleadoId = empleado.Attribute("cod_Empleado").Value,
                                             EmpleadoNombre = empleado.Element("nombre").Value,
                                             EmpleadoApellido = empleado.Element("apellido").Value,
                                             EmpleadoDNI = empleado.Element("DNI").Value
                                         } into ventasPorEmpleado
                                         let totalVentas = ventasPorEmpleado.Count()
                                         orderby totalVentas descending
                                         select new BEEmpleado
                                         {
                                             Id = Convert.ToInt32(ventasPorEmpleado.Key.EmpleadoId),
                                             Nombre = ventasPorEmpleado.Key.EmpleadoNombre,
                                             Apellido = ventasPorEmpleado.Key.EmpleadoApellido,
                                             DNI = Convert.ToInt32(ventasPorEmpleado.Key.EmpleadoDNI),
                                             Pass = totalVentas.ToString()
                                         };

                return empleadosConVentas.Take(5).ToList(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar las ventas de los empleados", ex);
            }
        }



        public IEnumerable<dynamic> TopMasVendidos(int option,List<DateTime> rangoFechas = null)
        {
           
            XDocument doc = XDocument.Load(ruta);
            DateTime hoy = DateTime.Today;
            try
            {
                switch (option)
                {
                    case 1:
                       
                        var juegosConVentasHoy = from venta in doc.Descendants("Venta")
                                                 join juego in doc.Descendants("Juego")
                                                 on (int)venta.Element("cod_Juego") equals (int)juego.Attribute("cod_Juego")
                                                 where (DateTime)venta.Element("fecha") >= hoy && (DateTime)venta.Element("fecha") < hoy.AddDays(1)
                                                 group venta by new
                                                 {
                                                     JuegoNombre = juego.Element("nombre").Value,
                                                     Plataforma = juego.Element("plataforma").Value
                                                 } into ventasPorJuego
                                                 let totalVentas = ventasPorJuego.Count()
                                                 orderby totalVentas descending
                                                 select $"{ventasPorJuego.Key.JuegoNombre} - {ventasPorJuego.Key.Plataforma}: {totalVentas} ventas";

                        return juegosConVentasHoy.Take(5).ToList();
                    case 2:
                        DateTime inicioSemana = hoy.AddDays(-(int)hoy.DayOfWeek + 1);
                        DateTime finSemana = inicioSemana.AddDays(7);
                        var juegosConVentasSemana = from venta in doc.Descendants("Venta")
                                                 join juego in doc.Descendants("Juego")
                                                 on (int)venta.Element("cod_Juego") equals (int)juego.Attribute("cod_Juego")
                                                 where (DateTime)venta.Element("fecha") >= inicioSemana && (DateTime)venta.Element("fecha") < finSemana.AddDays(1)
                                                 group venta by new
                                                 {
                                                     JuegoNombre = juego.Element("nombre").Value,
                                                     Plataforma = juego.Element("plataforma").Value
                                                 } into ventasPorJuego
                                                 let totalVentas = ventasPorJuego.Count()
                                                 orderby totalVentas descending
                                                 select $"{ventasPorJuego.Key.JuegoNombre} - {ventasPorJuego.Key.Plataforma}: {totalVentas} ventas";

                        return juegosConVentasSemana.Take(5).ToList();
                    case 3:
                        DateTime fechaLimite = hoy.AddDays(-30);
                        var juegosConVentasUltimos = from venta in doc.Descendants("Venta")
                                                    join juego in doc.Descendants("Juego")
                                                    on (int)venta.Element("cod_Juego") equals (int)juego.Attribute("cod_Juego")
                                                    where (DateTime)venta.Element("fecha") >= fechaLimite 
                                                    group venta by new
                                                    {
                                                        JuegoNombre = juego.Element("nombre").Value,
                                                        Plataforma = juego.Element("plataforma").Value
                                                    } into ventasPorJuego
                                                    let totalVentas = ventasPorJuego.Count()
                                                    orderby totalVentas descending
                                                    select $"{ventasPorJuego.Key.JuegoNombre} - {ventasPorJuego.Key.Plataforma}: {totalVentas} ventas";
                        return juegosConVentasUltimos.Take(5).ToList();
                    case 4:
                        DateTime primerDiaDelMes = new DateTime(hoy.Year, hoy.Month, 1);
                        var juegosConVentasMes = from venta in doc.Descendants("Venta")
                                                 join juego in doc.Descendants("Juego")
                                                 on (int)venta.Element("cod_Juego") equals (int)juego.Attribute("cod_Juego")
                                                 where (DateTime)venta.Element("fecha") >= primerDiaDelMes
                                                 group venta by new
                                                 {
                                                     JuegoNombre = juego.Element("nombre").Value,
                                                     Plataforma = juego.Element("plataforma").Value
                                                 } into ventasPorJuego
                                                 let totalVentas = ventasPorJuego.Count()
                                                 orderby totalVentas descending
                                                 select $"{ventasPorJuego.Key.JuegoNombre} - {ventasPorJuego.Key.Plataforma}: {totalVentas} ventas";
                        return juegosConVentasMes.Take(5).ToList();
                    case 5:
                        DateTime rangoInicio = rangoFechas[0].Date;
                        DateTime rangoFin = rangoFechas[1].Date;
                        var juegosConVentasRango = from venta in doc.Descendants("Venta")
                                                 join juego in doc.Descendants("Juego")
                                                 on (int)venta.Element("cod_Juego") equals (int)juego.Attribute("cod_Juego")
                                                 where (DateTime)venta.Element("fecha") >= rangoInicio && (DateTime)venta.Element("fecha") < rangoFin.AddDays(1)
                                                   group venta by new
                                                 {
                                                     JuegoNombre = juego.Element("nombre").Value,
                                                     Plataforma = juego.Element("plataforma").Value
                                                 } into ventasPorJuego
                                                 let totalVentas = ventasPorJuego.Count()
                                                 orderby totalVentas descending
                                                 select $"{ventasPorJuego.Key.JuegoNombre} - {ventasPorJuego.Key.Plataforma}: {totalVentas} ventas";
                        return juegosConVentasRango.Take(5).ToList();
                    default:
                        return null;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
}



 
}
