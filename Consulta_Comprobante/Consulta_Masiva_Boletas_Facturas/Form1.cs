using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Consulta_Masiva_Boletas_Facturas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnPath_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlFicheroCSV = new OpenFileDialog();
                dlFicheroCSV.Title = "Abrir fichero CSV...";
                //dlFicheroCSV.InitialDirectory = @"C:\";
                dlFicheroCSV.Filter = "Ficheros de texto y CSV (*.txt, *.csv)|*.txt;*.csv|" +
                    "Ficheros de texto (*.txt)|*.txt|" +
                    "Ficheros CSV (*.csv)|*.csv|" +
                    "Todos los ficheros (*.*)|*.*";
                dlFicheroCSV.FilterIndex = 1;
                dlFicheroCSV.RestoreDirectory = true;
                if (dlFicheroCSV.ShowDialog() == DialogResult.OK)
                {
                    LblPath.Text = dlFicheroCSV.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error => " + ex.Message.ToString());
            }
        }

        private void BtnLeer_Click(object sender, EventArgs e)
        {

            if (File.Exists(LblPath.Text))
            {
                try
                {
                    CargarDatosCSV(LblPath.Text, txtSeparadorValores.Text, ChkEncabezado.Checked, Convert.ToChar(TxtSeparadorCampos.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error al leer CSV...",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No existe el fichero CSV seleccionado.",
                    "Fichero no encontrado...",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        //Carga un fichero CSV en un DataGridView
        private void CargarDatosCSV(string ficheroCSV, String separadorValores, bool primeraLineaTitulo, char separadorCampos)
        {



            //string[] lineas = File.ReadAllLines(ficheroCSV, Encoding.Default);
            //var asd = lineas;

            TblDatosLeidos.DataSource = null;
            TblDatosLeidos.Rows.Clear();


            DataTable tablaDatos = new DataTable();
            string[] lineas = File.ReadAllLines(ficheroCSV, Encoding.Default);
            string[] etiquetaTitulosFinal;

            if (lineas.Length > 0)
            {
                #region

                if (primeraLineaTitulo)
                {
                    //Limpiamos Comias que dividen los valores ""
                    string primelaLinea = lineas[0].Replace(separadorValores, "");
                    // Hacemos un array de separador de campos ;
                    String[] etiquetaTitulo = primelaLinea.Split(separadorCampos);
                    //List<String> Lista = new List<String>();
                    foreach (String CampoActual in etiquetaTitulo) 
                    {
                        tablaDatos.Columns.Add(new DataColumn(CampoActual));
                    }
                    


                    etiquetaTitulosFinal = etiquetaTitulo;

                    int inicioFila = 0;
                    if (primeraLineaTitulo)
                        inicioFila = 1;
                    for (int i = inicioFila; i < lineas.Length; i++)
                    {
                        string[] filasDatos = lineas[i].Split(separadorCampos);
                        DataRow dataGridS = tablaDatos.NewRow();
                        int columnIndex = 0;

                        foreach (string campoActual in etiquetaTitulosFinal)
                        {
                            string valor = filasDatos[columnIndex++];
                            valor = valor.Replace(separadorValores, "");
                            dataGridS[campoActual] = valor;
                        }
                        tablaDatos.Rows.Add(dataGridS);
                    }

                }


                #endregion


            }
            TblDatosLeidos.DataSource = tablaDatos;


            //    //Resto de filas de datos
            //    int inicioFila = 0;
            //    if (primeraLineaTitulo)
            //        inicioFila = 1;

            //    for (int i = inicioFila; i < lineas.Length; i++)
            //    {
            //        string[] filasDatos = lineas[i].Split(separador);
            //        DataRow dataGridS = tablaDatos.NewRow();
            //        int columnIndex = 0;
            //        foreach (string campoActual in etiquetaTitulosFinal)
            //        {
            //            string valor = filasDatos[columnIndex++];
            //            // Quitamos el posible carácter de inicio y fin de valor
            //            if (separadorCampos != "")
            //            {
            //                valor = valor.TrimEnd(Convert.ToChar(separadorCampos));
            //                valor = valor.TrimStart(Convert.ToChar(separadorCampos));
            //            }
            //            dataGridS[campoActual] = valor;
            //        }
            //        tablaDatos.Rows.Add(dataGridS);




            //DataTable tablaDatos = new DataTable();
            //string[] lineas = File.ReadAllLines(ficheroCSV, Encoding.Default);

            //if (lineas.Length > 0)
            //{
            //    //Si la primea línea contiene el título  
            //    string[] etiquetaTitulosFinal;
            //    if (primeraLineaTitulo)
            //    {
            //        string primelaLinea = lineas[0];
            //        string[] etiquetaTitulos = primelaLinea.Split(separador);
            //        List<string> lista = new List<string>();
            //        foreach (string campoActual in etiquetaTitulos)
            //        {
            //            string valor = campoActual;
            //            // Quitamos el posible carácter de inicio y fin de valor
            //            if (separadorCampos != "")
            //            {
            //                valor = valor.TrimEnd(Convert.ToChar(separadorCampos));
            //                valor = valor.TrimStart(Convert.ToChar(separadorCampos));
            //            }
            //            tablaDatos.Columns.Add(new DataColumn(valor));
            //            lista.Add(valor);
            //        }
            //        etiquetaTitulosFinal = lista.ToArray();
            //    }
            //    else
            //    {
            //        string primelaLinea = lineas[0];
            //        string[] etiquetaTitulos = primelaLinea.Split(separador);
            //        int numero = 0;
            //        List<string> lista = new List<string>();
            //        foreach (string campoActual in etiquetaTitulos)
            //        {
            //            string valor = "C" + Convert.ToString(numero);
            //            // Quitamos el posible carácter de inicio y fin de valor
            //            if (separadorCampos != "")
            //            {
            //                valor = valor.TrimEnd(Convert.ToChar(separadorCampos));
            //                valor = valor.TrimStart(Convert.ToChar(separadorCampos));
            //            }

            //            tablaDatos.Columns.Add(new DataColumn(valor));
            //            lista.Add(valor);
            //            numero++;
            //        }
            //        etiquetaTitulosFinal = lista.ToArray();
            //    }

            //    //Resto de filas de datos
            //    int inicioFila = 0;
            //    if (primeraLineaTitulo)
            //        inicioFila = 1;

            //    for (int i = inicioFila; i < lineas.Length; i++)
            //    {
            //        string[] filasDatos = lineas[i].Split(separador);
            //        DataRow dataGridS = tablaDatos.NewRow();
            //        int columnIndex = 0;
            //        foreach (string campoActual in etiquetaTitulosFinal)
            //        {
            //            string valor = filasDatos[columnIndex++];
            //            // Quitamos el posible carácter de inicio y fin de valor
            //            if (separadorCampos != "")
            //            {
            //                valor = valor.TrimEnd(Convert.ToChar(separadorCampos));
            //                valor = valor.TrimStart(Convert.ToChar(separadorCampos));
            //            }
            //            dataGridS[campoActual] = valor;
            //        }
            //        tablaDatos.Rows.Add(dataGridS);
            //    }
            //}
            //if (tablaDatos.Rows.Count > 0)
            //{
            //    TblDatosLeidos.DataSource = tablaDatos;
            //}
        }

    }
}
