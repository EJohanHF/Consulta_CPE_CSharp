using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Consulta_Estado_Comprobante_Pago.ServicioConsultaEstadoCpv2
{
    public class ConsultaEstadoComprobante
    {

        private static String Consultar_Comprobante(String numRuc, String codComp , String numeroSerie , String numero , String fechaEmision, String monto)
        {
            String responseFromServer = "";
            // Create a request using a URL that can receive a post.
            WebRequest request = WebRequest.Create("https://ww1.sunat.gob.pe/ol-ti-itconsultaunificada/consultaUnificada/consultaIndividual");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            request.Headers.Add("Cookie", "f5_cspm=1234; f5avraaaaaaaaaaaaaaaa_session_=EMIHFOHKFECNLJJJKKDGLKOCIFFJAJAJFHFJCPFKLFKAGBLAFLPJNKBAGFGKGLAGLBODOKOHDEHNGIMHFDBAJPKDFLLMBEKEHNCOHMCJJJFPMPJNIHINKGEPHLAHMAON; _ga=GA1.3.1949244408.1644435820; dtCookie=v_4_srv_2_sn_E562ED0E569743C02707D5185533854E_perc_100000_ol_0_mul_1_app-3A7455eb26f91684bb_0; _gid=GA1.3.2097299283.1645143719; 20604111413FACTURA3=1; -2142441470=1; ITADMINFORUCMODIFDATOSSESSION=jyoNbXwpBS3ITw34RK88VYn5e0eq1eIL84BH1zmzzmblBt2O7Z1Z3thJ8MGUpf_Y4-JrVgbFdQS8GSwfpM0a0egDLcP-ylCZJ5PvUeBpL3McCa795dKLxAjZvjX6gTUoY9C1plaGW4y9MEnkuychJQypTyoRbQGSCYHIEuqoSlY6BHR6jnebnc4bHZeIqRnAFcWLD_tCuTgCbzEjT5zF20dP5vqpLs_N1QLi-jxqbYK0zfW-3kh4fVe74PGCrx01!-1576736380!-1257438183; ITCONSULTAUNIFICADASESSION=guINbX4FKCKqThlrQx5ZA-SJDuHoy4cbJQsvoe7IHR8SmYsOCoaUKRhzb_Zo9shPrt4gm9RjUnh_g3Z6BQ8_WG2xt7HirQVmpsxRWE2brI64Hfd5ny27kQUtbx9QK71_ToTVCDOU449DxDQmvCukZ89sofj5VOYp2BqZuAKdxikJ7b99AIGeZWeQf-TgRxopoQl52G2g2jtpoylVF4FpRi6WMOy9NOFOxFinUOtizng5ewH3Ycas67rDTpqh5Qtx!-1111645257!-1023687581; TSf806e172027=08fe7428c8ab2000d749be6eba526f0f46070389581297c68a2a77f52118a784ae2c9fc9d45c205b08d1180d3c113000ac8533b31d925b1f1c2e0b91152448717b121251a1c18351e488ebcbd70464a4bede2e18d412292052944987dc473a38");
            // Create POST data and convert it to a byte array.
            string postData = "numRuc="+ numRuc + "&codComp="+ codComp + "&numeroSerie="+ numeroSerie + "&numero="+ numero + "&fechaEmision="+ Convert.ToDateTime(fechaEmision).ToString("dd/MM/yyyy") + "&monto="+monto+"";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";
            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            Stream dataStream = request.GetRequestStream();
            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object.
            dataStream.Close();

            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                 responseFromServer = reader.ReadToEnd();
                // Display the content.
                //Console.WriteLine(responseFromServer);
                //Console.ReadLine();
            }

            // Close the response.
            response.Close();

            int StartIndex = responseFromServer.IndexOf("estadoCp", 0) + "estadoCp".Length;
            int EndIndex = responseFromServer.IndexOf(",", StartIndex);
            String Resutado = responseFromServer.Substring(StartIndex, EndIndex - StartIndex);
            String Estado = "";

            switch (Resutado.Replace("\"", "").Replace("\\", "").Replace(":", ""))
            {
                case "0":
                    Estado = "NO EXISTE";

                    break;
                case "1":
                    Estado = "ACEPTADO";
                    break;
                case "2":
                    Estado = "ANULADO";
                    break;
            }
            return numeroSerie + "-" + numero + "|" + Estado.Replace("OK","");
        }

        public static String Preparar_Datos_COMPROBANTE(String numRuc , String serieNumero ,  String fechaEmision , String monto)
        {
            String tipoDoc = "";

            switch (serieNumero.Substring(0,1))
            {
                case "B":
                    tipoDoc = "03";

                    break;
                case "F":
                    tipoDoc = "01";
                    break;    


            }

            return Consultar_Comprobante(numRuc, tipoDoc , serieNumero.Substring(0, serieNumero.IndexOf("-")), serieNumero.Substring(serieNumero.IndexOf("-") + 1),fechaEmision,monto);
        }
    }
}
