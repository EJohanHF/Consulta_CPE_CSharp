using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consulta_Estado_Comprobante_Pago.ServicioConsultaestadoCp
{
    public class ConsultaEstadoComprobante
    {

        private static String Consultar_Comprobante(String numRuc, String codComp, String numeroSerie, String numero, String codDocRecep, String numDocRecep, String fechaEmision, String monto)
        {
            var client = new RestClient("https://ww1.sunat.gob.pe/ol-ti-itconsultaunificadalibre/consultaUnificadaLibre/consultaIndividual");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Cookie", "f5_cspm=1234; f5avraaaaaaaaaaaaaaaa_session_=LPILJIOKDGALBKHPNNPDBBJKFIKHJKNFAEACAEKIAINNJOOMCIMOGDLMOAFPKCOACBBDHHONPKMLOOIICMNAFHHHKDGIMFEBILNHFOBBKAGBHCOAJLOIHJFKPFOAJIEN; _ga=GA1.3.1949244408.1644435820; dtCookie=v_4_srv_4_sn_98B1D8381E54ED67DE939D7FDA2AE3D1_perc_100000_ol_0_mul_1_app-3A7455eb26f91684bb_0; f5avraaaaaaaaaaaaaaaa_session_=HIJKMICIANDGCLMDPLFGCIHFCNALAEHEJNOABGNBLIDLMFGICOPKGADJJGBGNBLFMPMDPGMNADPOACOCGNMAHKFLEBOAGKLBOJGGPJBLOHDGGJPDMLKDNLKLMFBCDFAF; ITCONSULTAUNIFICADALIBRESESSION=hjcDbq47Ic2y5zkP4hCuGZnYfLsNXztuDlgJCSz87aOL2VHlUCl9venVo4I5dy-dTFsvgMjx5a-lWzpvHkPW1KKcY7WWxDj2q5vZGFdP6KEk-6cA_KmcqYZASpF9vaW2DACMD1uTF-TfZKdCeYAEe-S7mZa-spE93mYxzM3gzPzzcEUQEhrvt0DGAqXw1rpgpaH9reqs2c9PlS1MTlrCAyyxlWzxOeZi4bAoIix8NH7OB7w--l1Ig0yZErsFcA7d!-1543761795!55256296; TS44788fc0027=08fe7428c8ab20002dde2463ab051bcef6d4718cbd4c85d858c0b6814346259b6692185502d13ba6085a33bcbd113000c895f648940e7f9a37cbd068bfe8891334df6635412710536d722390f86d0b74a7adc272ea9ba028edbacb4b76e6531c");
            request.AlwaysMultipartFormData = true;
            request.AddParameter("numRuc", numRuc/*"20381166491"*/);
            request.AddParameter("codComp", codComp/* "03"*/);
            request.AddParameter("numeroSerie", numeroSerie/*"B003"*/);
            request.AddParameter("numero", numero/*"00547947"*/);
            request.AddParameter("codDocRecep", codDocRecep/*/*""*/);
            request.AddParameter("numDocRecep", numDocRecep /*""*/);
            request.AddParameter("fechaEmision", /*DateTime.FromOADate(Convert.ToDouble(fechaEmision))*/Convert.ToDateTime(fechaEmision).ToString("dd/MM/yyyy")/*"26/08/2021"*/);
            request.AddParameter("monto", monto/*"45.00"*/);
            request.AddParameter("token", "HFZXc5dg4fcB9HcEgMS10dShhpZgA9bQ9gPHJxFAkxaShdYhVWG2NzbxZUYiwQbjIXDDZTDFdRAQRBInQodg5CYm59bUFSbgJ1AwdNHX0ZfX5EL2xhSGcnWFQoEUYdAQQ-QHklQyhfRWw3OmEPXiN5bVZhXVscUXllVyI-MUk4cB8zdUIWV0MUUFwOOkxpR103bCYNSVtzNDtfFUUcR1MjMVBhLnNHJHUgDDZRZk8bbGcXVA8DKW4vO19qUn4Aby4fSxg5CglcL3ou");
            IRestResponse response = client.Execute(request);
            int StartIndex = response.Content.IndexOf("estadoCp", 0) + "estadoCp".Length;
            int EndIndex = response.Content.IndexOf(",", StartIndex);
            String Resutado = response.Content.Substring(StartIndex, EndIndex - StartIndex);
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
            return numeroSerie + "-" + numero + "|" + Estado;
        }

        public static String Preparar_Datos_COMPROBANTE(String fechaEmicion , String numeroSerie, String rucEmisor, String importeVenta)        
        {                       
            return Consultar_Comprobante(rucEmisor, "03", numeroSerie.Substring(0, numeroSerie.IndexOf("-")), numeroSerie.Substring(numeroSerie.IndexOf("-") + 1), "", "", fechaEmicion, importeVenta);
        }

    }
}
