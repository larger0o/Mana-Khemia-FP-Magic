using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.IO.Compression;

namespace Mana_Khemia_FP_Magic
{
    public partial class Form1 : Form
    {
        
        string fichero = "";
        byte[] contenido;
        byte[] cabecera = { 0x1f, 0x8b, 0x08, 0x00 };
        static int size = 100;

        int contador = 0;
        //falso - fin fichero sin guardar
        bool DetectFinFichero = true;

        //aquí se guardan todas las cabeceras
        byte[,] cabecerafichero = new byte[size,4];

        //aquí se guardan los punteros de los ficheros
        //la cabecera está 4 posiciones antes
        ArrayList posfichero = new ArrayList();

        //posicion de final de fichero
        //NO incluido en éste
        ArrayList finfichero = new ArrayList();

        byte[,] Datos = new byte[size,250000];
        int[] LongitudDatos = new int[size];

        int longitud = 0;
        int inicio = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            fichero = openFileDialog1.FileName;
            if (fichero != null)
                LoadFile(fichero);
        }

        public void LoadFile (string fichero)
        {

            //buscar la cabecera de GZ (1F8B0800)
            if (CargarInfo(fichero))
            {
                lblStatus.Text = openFileDialog1.SafeFileName + " OK";
                GetInfo(fichero);
                MostrarInfo();
                extraerToolStripMenuItem.Enabled = true;
                insertarToolStripMenuItem.Enabled = true;
            }
            else
                MessageBox.Show("Archivo FP inválido");
            
        }




        public void GetInfo (string fichero)
        {
            try
            {
                //copiar info
                for (int i = 0; i < contador; i++)
                {
                    longitud = (int)finfichero[i] - (int)posfichero[i];
                    LongitudDatos[i * 2] = longitud;
                    inicio = (int)posfichero[i];
                    Datos = Copiar(contenido, Datos, i*2, inicio, longitud);
                }
                //copiar ceros
                for (int i = 0; i < contador; i++)
                {
                    longitud = (int)posfichero[i+1] - (int)finfichero[i];
                    LongitudDatos[(i * 2)+1] = longitud;
                    inicio = (int)finfichero[i];
                    Datos = Copiar(contenido, Datos, (i*2)+1, inicio, longitud);
                }
            }
            catch (Exception e)
            { lblStatus.Text = e.ToString(); }

        }

        private bool CargarInfo(string fichero)
        {

            try
            {
                contenido = File.ReadAllBytes(fichero);
                //tenemos el contenido en un array de bytes

                contador = 0;
                for (int i = 0; i < contenido.Length; i++)
                {
                    //en este caso, coincide la cabecera, se anota la posición de inicio y a leer
                    if ((contenido[i] == cabecera[i - i]) && (contenido[i + 1] == cabecera[i - i + 1]) && (contenido[i + 2] == cabecera[i - i + 2]) && (contenido[i + 3] == cabecera[i - i + 3]))
                    {
                        posfichero.Add(i);
                        DetectFinFichero = false;
                        //guardar cabecera fichero
                        for (int x = 0; x < 4; x++)
                        {
                            cabecerafichero[contador, x] = contenido[i+x-4];
                        }
                    }
                    if (!DetectFinFichero) {
                        lblStatus.Text = i.ToString();
                        if ((contenido[i] == cabecerafichero[contador, 0]) && (contenido[i + 1] == cabecerafichero[contador, 1]) && (contenido[i + 2] == cabecerafichero[contador, 2]) && (contenido[i + 3] == cabecerafichero[contador, 3]))
                        {
                            finfichero.Add(i+4);
                            contador++;
                            DetectFinFichero = true;
                        }
                }

                }
                posfichero.Add(contenido.Length);
                if (contador == 0) return false;
                return true;
            }
            catch (Exception e) {
                lblStatus.Text += e.ToString();
                return false;
            }
       }

        public void MostrarInfo()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < contador; i++)
              listBox1.Items.Add(openFileDialog1.SafeFileName + " " + i);


        }
       public void RellenarCabecera()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cabecerafichero[i, j] = 0xFF;
                }
            }
        }

        public static string HexToString(string HexValue)
        {
            string StrValue = "";
            while (HexValue.Length > 0)
            {
                StrValue += System.Convert.ToChar(System.Convert.ToUInt32(HexValue.Substring(0, 2), 16)).ToString();
                HexValue = HexValue.Substring(2, HexValue.Length - 2);
            }
            return StrValue;
        }

        public byte[,] Copiar (byte[] origen, byte[,] destino, int indice, int inicio, int longitud)
        {
            try
            {
                for (int i = 0; i < longitud; i++)
                    destino[indice, i] = origen[inicio + i];
            }
            catch
            {
                for (int i = origen.Length; i < longitud; i++)
                    destino[indice, i] = 0x00;
            }
            return destino;
        }

        public byte[] Leer(byte[,] origen, int indice, int longitud)
        {
            byte[] destino = new byte[250000];
            for (int i = 0; i < longitud; i++)
                destino[i] = origen[indice,i];
            return destino;
        }

        public void extraerTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertarToolStripMenuItem.Enabled = true;
            FileStream descomprimirFS;
            GZipStream descomprimir;
            string filename = openFileDialog1.SafeFileName.Substring(0, (openFileDialog1.SafeFileName.Length - 3));
            DirectoryInfo dir = new DirectoryInfo(filename);
            if (!dir.Exists)
                dir.Create();
            for (int i = 0; i < contador; i++)
            {
                try
                {
                    descomprimirFS = File.Create(filename + "\\" + filename + i + ".tm2");
                    descomprimir = new GZipStream(new MemoryStream(Leer(Datos, i * 2, LongitudDatos[i * 2])), CompressionMode.Decompress);
                    descomprimir.CopyTo(descomprimirFS);
                    descomprimir.Dispose();
                    descomprimirFS.Dispose();
                }
                catch { }              
            }
            MessageBox.Show("Hecho");


        }

        private void extraerSeleccionadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertarToolStripMenuItem.Enabled = true;
            FileStream descomprimirFS;
            GZipStream descomprimir;
            int selected = listBox1.SelectedIndex;
            string filename = openFileDialog1.SafeFileName.Substring(0, (openFileDialog1.SafeFileName.Length - 3));
            DirectoryInfo dir = new DirectoryInfo(filename);
            if (!dir.Exists)
                dir.Create();
            if (selected != -1)
            {
                try
                {
                    descomprimirFS = File.Create(filename + "\\" + filename + selected + ".tm2");
                    descomprimir = new GZipStream(new MemoryStream(Leer(Datos, selected * 2, LongitudDatos[selected * 2])), CompressionMode.Decompress);
                    descomprimir.CopyTo(descomprimirFS);
                    MessageBox.Show("Hecho");
                    descomprimir.Dispose();
                    descomprimirFS.Dispose();
                }
                catch { MessageBox.Show("¡Error"); }
            }
        }

        private void insertarSeleccionadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                int selected = listBox1.SelectedIndex;
                string filename = openFileDialog1.SafeFileName.Substring(0, (openFileDialog1.SafeFileName.Length - 3));


                byte[] tmp = File.ReadAllBytes(filename + "\\" + filename + selected + ".tm2");
                byte[] tmp2 = Compress(tmp);

                Copiar(tmp2, Datos, selected * 2, 0, LongitudDatos[selected * 2]);
                if (!listBox1.Items[selected].ToString().Contains("*"))
                    listBox1.Items[selected] += "*";
                MessageBox.Show("Hecho");
                guardarToolStripMenuItem.Enabled = true;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Falta la imagen a reinsertar.");


            }
            catch (IOException ex)
            {
                MessageBox.Show("Error. El fichero está en uso por otro programa.");
            }


}

        private void insertarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = openFileDialog1.SafeFileName.Substring(0, (openFileDialog1.SafeFileName.Length - 3));
            byte[] tmp;
            try
            {
                for (int i = 0; i < contador; i++)
                {
                    tmp = File.ReadAllBytes(filename + "\\" + filename + i + ".tm2");
                    tmp = Compress(tmp);
                    Copiar(tmp, Datos, i * 2, 0, LongitudDatos[i * 2]);
                    if (!listBox1.Items[i].ToString().Contains("*"))
                        listBox1.Items[i] += "*";
                }
                MessageBox.Show("Hecho");
                guardarToolStripMenuItem.Enabled = true;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Falta alguna de las imágenes a reinsertar. Asegúrate de que haya {0} archivos.", contador.ToString());


            }
            catch (IOException ex)
            {
                MessageBox.Show("Error. Alguno de los ficheros está en uso por otro programa.");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }



        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filename = openFileDialog1.SafeFileName;
                ArrayList tmp = new ArrayList();
                tmp.Add(cabecerafichero[0, 0]);
                tmp.Add(cabecerafichero[0, 1]);
                tmp.Add(cabecerafichero[0, 2]);
                tmp.Add(cabecerafichero[0, 3]);

                for (int i = 0; i < contador * 2; i++)
                {
                    for (int j = 0; j < LongitudDatos[i]; j++)
                    {
                        tmp.Add(Datos[i, j]);
                    }
                }
                byte[] tmparray = (byte[])tmp.ToArray(typeof(byte));
                File.WriteAllBytes("NEW-" + filename, tmparray);
                MessageBox.Show("Hecho");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error. " + ex.ToString());

            }

        }


        public byte[] Compress(byte[] data)
        {
            using (var compressedStream = new MemoryStream())
            {
                using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                {
                    zipStream.Write(data, 0, data.Length);
                    zipStream.Close();
                    return compressedStream.ToArray();
                }
            }
        }

    }
}
