using ExcelDataReader;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS_TIC_ENVIO_RESUMEN
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ingresar la ruta del archivo y precionar enter");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.Write("->");
            String filePath = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("                          Empzando a enviar comprobante de pago                            ");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            try
            {

                int count2 = 3;
                int count = 0;
                for (int i = 0; i < count2; i++)
                {


                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {


                            do
                            {
                                while (reader.Read())
                                {
                                    count += 1;
                                    if (count > 1)
                                    {
                                        //int cantidadBoletas = Convert.ToInt16(reader.GetValue(0).ToString());
                                        //String FechaResumen = reader.GetValue(1).ToString();

                                        String rpt1 = Generar_XMl(reader.GetValue(1).ToString(), "20381166491");
                                        String rpt2 = Enviar_Datos(reader.GetValue(1).ToString(), "20381166491");
                                        Console.WriteLine("Fecha enviada: " + reader.GetValue(1).ToString());

                                        // int CalcularVueltas = cantidadBoletas / 50;                                  

                                        //Console.WriteLine(ServicioConsultaestadoCp.ConsultaEstadoComprobante.Preparar_Datos_COMPROBANTE(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(4).ToString()));
                                        //Console.WriteLine(
                                        //    "fechaEmicion -> " + reader.GetValue(0).ToString() + " " +
                                        //    "serieNumero -> " + reader.GetValue(1).ToString() + " " +
                                        //    "numeroDocIdentidadEmisor -> " + reader.GetValue(2).ToString() + " " +
                                        //    "importeTotalVenta  -> " + reader.GetValue(4).ToString());
                                    }
                                }
                            } while (reader.NextResult());

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Hubo un error al procesar -> " + e.Message);
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.WriteLine("                                Finalizo el proceso                                        ");
            Console.WriteLine("-------------------------------------------------------------------------------------------");
            Console.Write("Precionar enter para salir ->");
            String exit = Console.ReadLine();
            if (exit == "" || exit != "")
            {
                Environment.Exit(0);
            }


        }


        public static string Generar_XMl(string fecha_res, string ruc_res)
        {
            var client = new RestClient("https://portal.sos-fact.com/facturador/busqueda/xml_res2.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("fecha_res", Convert.ToDateTime(fecha_res).ToString("yyyy/MM/dd") /*"2021-09-04"*/);
            request.AddParameter("ruc_res", ruc_res);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            String rpt = response.Content;

            return rpt;
        }


        public static string Enviar_Datos(string fecha_res, string ruc_res)
        {
            var client = new RestClient("https://portal.sos-fact.com/facturador/busqueda/datos_res2.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("fecha_res", Convert.ToDateTime(fecha_res).ToString("yyyy/MM/dd") /*"2021-09-04"*/);
            request.AddParameter("ruc_res", ruc_res);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            String rpt = response.Content;
            return rpt;
        }


    }
}
