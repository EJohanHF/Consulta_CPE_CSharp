using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new RestClient("https://ww1.sunat.gob.pe/ol-ti-itconsultaunificada/consultaUnificada/consultaIndividual");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Cookie", "f5_cspm=1234; f5avraaaaaaaaaaaaaaaa_session_=NFCFPMCDKJDAAHOFDKBPFHMBBEPHKNHJAEIDJHMAECPAAGAECHMIHKFPIFJPFAIFCBKDGFCCHEIAOOLLCGJADAHHDHMILKLBPENKBBGOAPHGKPGGGDNHPKIDLIOHOCOD; _ga=GA1.3.1949244408.1644435820; dtCookie=v_4_srv_4_sn_98B1D8381E54ED67DE939D7FDA2AE3D1_perc_100000_ol_0_mul_1_app-3A7455eb26f91684bb_0; _gid=GA1.3.1952017034.1645046618; 10103362755FACTURA3=1; -1316668142=1; ITCONSULTAUNIFICADASESSION=LZ0F4qj6LdaCxjbFxdl8ulgBdo0jvD8MuZzCT8Ea2_6tWHHgwQ8F8THtx13H8lX9Udxvgp8wPoGnWeE-Xmyvkya-qXB1_Ddgt3aRMhgtTkKRw7Ir4ry0lzKz5B8Y_jz9XpnBULTQiGTV3dbCP-nyFsBeWO1pO08h8sZrIHNfIEK4vsUv45f7AOE8DypyJKvg4Mjji0evFT5BsHuBav8BswLA2PwCEFxz0PPnrsKFxSC6u4GuBV4sWJpWCJP64Y17!55256296!-1543761795; TS0111bf25=019edc9eb8ab401f2319fe627b5891f5dbf9f4b813cd77c8c41c772c72799527f2be4a29238305131c1dab1cb5780f8b778f88db88915a702af2a34cec10f73a63a6cfedb2610dc72ccc428e0e836791cde18dfbd1203201ece0e4016f9eccdf1609e3fac3320d2fd06efa08fe740098ca9d9b6ab1; TS3281c147027=08d0cd49b8ab2000b9eac1769246b1f412cc1c6f1ce48be278b0edd5b4c3b36458f5f80db0123b4e087c23ccf41130003beca631316b81d5a3dc9c7e2904b9c7f210f0f0ed23fbe5d130bbbb1c029ab956d6ba45521d64de47c190befde880ed; ITCONSULTAUNIFICADALIBRESESSION=ajEFujty0e4kKEuIWtZ4U7rN0tLk5QK42TXUE8dtuizlrKZDLPjWUmoTK-MjHk23-5CdiXjaAf2ACpvuBprSbNiUr5q3CeBCuU-_EzDf4BAQk1Bc2ofoAg2jvbhorDG3Z5m_JTPVliiXen1meKV4ihpb7Y9snnEadXstA4HZghI0SEpZEHt-NtelE46i6jF6PW_YO3DOBecmDuuhdQFUH9b_kZEAfx2q1HiRCbCt5wxMePqF_vI1a05AaXqdhEE5!55256296!-1543761795; TS0111bf25=019edc9eb8a4fe2bcc7b37e29a33f3c17011273232047e11f22003715cbdf0a008c82299d9e34c7978775c05bb4626e46f17f86e9b827269f5fce79a3cfd3c74003221e185");
            //request.AlwaysMultipartFormData = true;
            //request.AddParameter("numRuc", " 20601736811");
            //request.AddParameter("codComp", " 01");
            //request.AddParameter("numeroSerie", " F001");
            //request.AddParameter("numero", " 00005570");
            //request.AddParameter("fechaEmision", " 31/01/2022");
            //request.AddParameter("monto", " 78.00");
            //IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);

            // Create a request using a URL that can receive a post.
            WebRequest request = WebRequest.Create("https://ww1.sunat.gob.pe/ol-ti-itconsultaunificada/consultaUnificada/consultaIndividual");
            // Set the Method property of the request to POST.
            request.Method = "POST";
            request.Headers.Add("Cookie", "f5_cspm=1234; f5avraaaaaaaaaaaaaaaa_session_=IGLAEJEIPLHDENBHIHJLDMIOMEDIEDIOEJGEEBJDOJAOLOFHPONINADHGDPKAAEKMADDCEHGIKKNDPGJIPBAPHAEDNHGGPBAHOJOMFENHKJEPHDLLMBGHDMOELOCPJJA; _ga=GA1.3.1949244408.1644435820; dtCookie=v_4_srv_4_sn_98B1D8381E54ED67DE939D7FDA2AE3D1_perc_100000_ol_0_mul_1_app-3A7455eb26f91684bb_0; _gid=GA1.3.1952017034.1645046618; TS0111bf25=019edc9eb8c676e98b8e1f766319169a378a62dfaf2bae63c5b71bfb08ad33c081372ac2fbf6fbe9944aa1558ba1f19c510bbe170694a8c73248d9c317c998a400a32bd4ab61997ca89cff7550f0255356c9943614186001bfc11271558efd598505d31fe525df74ca49d4250b9e6d73eca8902e28; 10103362755FACTURA3=1; 2071835537=1; f5avr0782439771aaaaaaaaaaaaaaaa_cspm_=KGKABMKFHMIEECIDALNHBNICDNHAIDHKJONHGOPKIALFKAGGEGMAHHIANAHKIEOGNDJCBBNEACKDKMPMKJGAFPIMAJMJFAFHGPOLNJJACNMADNHOCPLKHLEPOJPNPOEP; ITCONSULTAUNIFICADASESSION=KUwGI0nFsmIsjAalIwFXGkejt1soNd1ydVQc21wH4V2IfbU98e0Vv9T1WXemJ_4aw_0TKgcEWHjJiESiMEyLGxdYAaBb6_DJBDhaFI1UrwcCKXmx4TMLtXnvMKb3A46IclodJLFWKq5SpnfjVvpNmP89oUEQr8bwqb7rBkM5OisyeOXZYQZ7Vss59kbAEztrZ4CAbfFI15BEesNxoJiYyjRPN0MUafentREAlk969W8LRYoE4if_PFRbg-TAmp68!-559074031!363506420; -1316668142=1; TSf806e172027=08fe7428c8ab200033d0945b0287c871925ad579e502085c155394d1f933f6ad70c2c26cbf7be9bd08a509fd2e113000f9566c50a954e1d9141a0ba07c9a01874564dab06f7173f51ec7db3652fd4f885d3555a7aa3597ead267f123b5687659; f5avr2086455768aaaaaaaaaaaaaaaa_cspm_=PGIEGCDAHIHEKHBMDCHHOFIKBFMGILLIKPNCKHECMKOIDDONOLMEOACKAFNNJFOONHECLNGHALIDKEECMKIAPNOGAJPJPOINLOCAHPDNJKOEBDNKFNMNMICFDNPFJEEF");
            // Create POST data and convert it to a byte array.
            string postData = "numRuc=20601736811&codComp=01&numeroSerie=F001&numero=00005570&fechaEmision=31/01/2022&monto=78.00";
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
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            // Get the stream containing content returned by the server.
            // The using block ensures the stream is automatically closed.
            using (dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                Console.ReadLine();
            }

            // Close the response.
            response.Close();


        }
    }
}
