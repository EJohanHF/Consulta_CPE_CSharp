using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consulta_Estado_Comprobante_Pago
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
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\RutaArchivos\" +DateTime.Now.ToString("dd-mm-yyyy hh mm ss s") + ".txt" , true))
                        {


                            int count = 0;
                            do
                            {
                                while (reader.Read())
                                {
                                    count += 1;
                                    if (count > 1)
                                    {

                                        String infor = ServicioConsultaEstadoCpv2.ConsultaEstadoComprobante.Preparar_Datos_COMPROBANTE(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString());
                                        Console.WriteLine(infor);
                                        //Console.WriteLine(
                                        //    "fechaEmicion -> " + reader.GetValue(0).ToString() + " " +
                                        //    "serieNumero -> " + reader.GetValue(1).ToString() + " " +
                                        //    "numeroDocIdentidadEmisor -> " + reader.GetValue(2).ToString() + " " +
                                        //    "importeTotalVenta  -> " + reader.GetValue(4).ToString());

                                        file.WriteLine(infor);

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
                var fileName = System.Reflection.Assembly.GetExecutingAssembly().Location;
                System.Diagnostics.Process.Start(fileName);
            }



        }

    }
}
