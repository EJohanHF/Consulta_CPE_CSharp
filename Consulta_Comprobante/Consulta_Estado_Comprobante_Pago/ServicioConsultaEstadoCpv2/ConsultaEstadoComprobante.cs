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
            request.Headers.Add("Cookie", "f5_cspm=1234; f5avraaaaaaaaaaaaaaaa_session_=PIOMLFCEMJBJAGLLHKAHKDHLJKGNIDOIIMPAIFHLBKEAJONPBBNFOKOLKJPGFNPPODDDLECCBENBNBCEONDAEPDNDECOKMJIGNHMLDJOGJGIAKJMAKNKOHLEHAFAFCAP; _ga=GA1.3.1949244408.1644435820; dtCookie=v_4_srv_6_sn_5031D9083504E9821D40767ED754F835_perc_100000_ol_0_mul_1_app-3A7455eb26f91684bb_0; 20603942036FACTU022=1; 269352767=1; ITCONSULTAUNIFICADASESSION=_702oWfR6ym7nlEEOUKe-YIt_z9bqInnF7_gQ8T4u7VFYrANJgU3VS37CdfXkxVTJmgWGraGwUufxKs9CRas5TsZokaPUWFzRPQfBdiibjv1rElYxN6QyGEmioOyPazKTCLwBmTspxIbfkLVTsmYGdpo2nbkDGZM8ackpG5oLFAAOUCWCDijFKKpgRA3-W0vpC3E3JmNplPrYPXz8p5MVJZVJQt_TgLZNHVcX4N6dbZNd0FVbesjwwKcteXDdgcv!1116837639!561757847; f5avr2086455768aaaaaaaaaaaaaaaa_cspm_=PEBMMAHDMCBKMIEMFODMCLGCAMFBMPFMLGNOGDFOHLJONMEDIEIBPNNBECHIDCCBBNLCAENNAGIDGHGPMJOAPEBEADHDIKAJGIFCBMHFNOEACGJOCPAFEBJLIGHNOGPC; TS44788fc0027=08fe7428c8ab20005209bc87a1925fedb5dadd7622234ee2c8e61bc346216ad9f6a3809da976eaac08c7cf44651130002c930b6ddd89005200ece2019ed73bbbff33e99c69f12f743f6ede428ec7c9c8103f788ae8d6663b2d96181b8e0c63dd; f5avr0782439771aaaaaaaaaaaaaaaa_cspm_=JDBJFFJMFDJKHGNHGKCHLDBAFEJACMGPKBNCJJMLGNCEDIMKHKNIBLBFEAEBJOIIEJLCMAEBAECBGCKBGEKAFGJKAEDDFIHKMHMIIFHLIJMLAMBNGIHIFDMFDFLGKEJO");
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
