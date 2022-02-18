using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
namespace Consulta_Comprobante
{
    class Program
    {
        static void Main(string[] args)
        {
            Application excelApp = new Application();
            if (excelApp == null)
            {
                Console.WriteLine("Excel is not installed!!");
                return;
            }
            Workbook excelBook = excelApp.Workbooks.Open(@"C:\Users\JOHAN\Desktop\Consult_Comprobante de pago\alfonso22.xlsx");
            _Worksheet excelSheet = excelBook.Sheets[1];
            Range excelRange = excelSheet.UsedRange;

            int rows = excelRange.Rows.Count;
            int cols = excelRange.Columns.Count;
            String controlador = "";
            string path = @"D:\" + "alfonso22.xlsx.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {

                    try
                    {
                        for (int i = 2; i <= rows; i++)
                        {


                            controlador = excelRange.Cells[i, 2].Value2.ToString();
                            //create new line
                            //Console.Write("\r\n");
                            for (int j = 1; j <= cols; j++)
                            {
                                if (controlador == excelRange.Cells[i, j].Value2.ToString())
                                {
                                    String fechaEmision = excelRange.Cells[i, 1].Value2.ToString();
                                    String numeroSerie = excelRange.Cells[i, 2].Value2.ToString();
                                    String numero = excelRange.Cells[i, 2].Value2.ToString();
                                    String numRuc = excelRange.Cells[i, 3].Value2.ToString();
                                    String Monto = excelRange.Cells[i, 5].Value2.ToString();
                                    int endSeri = numeroSerie.IndexOf("-");
                                    sw.WriteLine(Consultar_Comprobante_De_Pago(numRuc, "03", numeroSerie.Substring(0, endSeri), numero.Substring(endSeri + 1), "", "", fechaEmision, Monto));
                                    Console.WriteLine(Consultar_Comprobante_De_Pago(numRuc, "03", numeroSerie.Substring(0, endSeri), numero.Substring(endSeri + 1), "", "", fechaEmision, Monto));



                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                         
                    }

                    }
            }
            Console.WriteLine("Finalizado");
            Console.ReadLine();
            //after reading, relaase the excel project
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            Console.ReadLine();
        }

        public static String Consultar_Comprobante_De_Pago(String numRuc, String codComp, String numeroSerie, String numero, String codDocRecep, String numDocRecep, String fechaEmision, String monto)
        {
            var client = new RestClient("https://ww1.sunat.gob.pe/ol-ti-itconsultaunificadalibre/consultaUnificadaLibre/consultaIndividual");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cookie", "f5_cspm=1234; f5avraaaaaaaaaaaaaaaa_session_=HAIIOPMLLAFCEFOMKKBFHOMOHPHEPPLLOHKHFLOGLAEAMKLGOMDBGIDHLPLGKOBINNFDPFNKBJCLGCIEHPDABGPJOFICIMFDCANHMLNHLBHIMCFNGEGMMKDIJPOENAGM; ITCONSULTAUNIFICADALIBRESESSION=bVdYZV66IQftNmxM7Y4XNs5gx2ByGg6KJsYFBSWUmjUmHBcEN00b9JXDq0b9sqxf4gNG_9-cvCsduprl0FLtiBTWRlKgxSQEflxzlMAdQ7IHcu_COUSHDpecaGkQtv18L9IoXcvettK3zH9o6VUy7TExgKcpGKK3UT8vOQdWNDiZA3aHj7pq-I-yEVxlJkcQJkxGk92-61DpF6nS804GzAbA-wd7eYMF2FyITsgpG3395LbQ3HGeDUAM-C2BxOlC!870997380!864476891");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("numRuc", numRuc/*"20381166491"*/);
            request.AddParameter("codComp", codComp/* "03"*/);
            request.AddParameter("numeroSerie", numeroSerie/*"B003"*/);
            request.AddParameter("numero", numero/*"00547947"*/);
            request.AddParameter("codDocRecep", codDocRecep/*/*""*/);
            request.AddParameter("numDocRecep", numDocRecep /*""*/);
            request.AddParameter("fechaEmision", DateTime.FromOADate(Convert.ToDouble(fechaEmision)).ToString("dd/MM/yyyy")/*"26/08/2021"*/);
            request.AddParameter("monto", monto/*"45.00"*/);
            IRestResponse response = client.Execute(request);
            int StartIndex = response.Content.IndexOf("estadoCp", 0) + "estadoCp".Length;
            int EndIndex = response.Content.IndexOf(",", StartIndex);
            String Resutado = response.Content.Substring(StartIndex, EndIndex - StartIndex);
            String Estado = "";

            switch (Resutado.Replace("\"", "").Replace("\\", "").Replace(":", ""))
            {
                case "0":
                    Estado = "No Existe";

                    break;
                case "1":
                    Estado = "ACEPTADO";
                    break;
                case "2":
                    Estado = "ANULADO";
                    break;
            }
            return numeroSerie + "-" + numero + "   " + Estado;
        }

    }


}
