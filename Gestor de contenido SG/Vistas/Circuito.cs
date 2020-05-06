using Gestor_de_contenido_SG.FuncionesBD;
using Gestor_de_contenido_SG.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_contenido_SG
{
    public partial class Circuito : Form
    {
        public static ArrayList listaCircuitos = new ArrayList();
        public static ArrayList circuitosHijos = new ArrayList();
        public static bool contieneCircuitos;
        public static ClaseCircuito ocircuitoPadre;

        public Circuito()
        {
            InitializeComponent();

            //funcion que se llama al cerrar la ventana
            this.FormClosing += new FormClosingEventHandler(Controlador.cerrarPaginaActual);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string circuito;
            //si selecciona una elemento de la lista de elementos se guarda en un string sin espacios
            if (lista_circuitos.SelectedItem != null)
            {
                circuito = lista_circuitos.SelectedItem.ToString();
                circuito = circuito.Replace(" ", "");
            }
            else
            {
                circuito = null;
                throw new Exception("Debes seleccionar a que circuito pertenece o si es un circuito padre");
            }

            string titulo = titulo_circuito.Text;

            int nivel, padre;

            //se busca si es un circuito padre o no y dependiendo de si lo es se creara la pagina de un modo u otro
            switch (circuito)
            {
                case "Crearcircuitopadre":

                    nivel = 1;
                    padre = 0;

                    break;
                default:
                    //se busca el id del circuito al que pertenece
                    ClaseCircuito ocircuito = BDCircuitos.buscarCircuitoPadre(circuito);

                    nivel = ocircuito.nivel + 1;
                    padre = ocircuito.id;
                    break;
            }

            //si el texto del titulo no esta vacio se guardara en base de datos
            if (titulo != "")
            {
                ClaseCircuito ocircuito = new ClaseCircuito(nivel, padre, titulo);

                BDCircuitos.insertarCircuito(ocircuito);

                this.Close();
                Controlador.mostrarMenu();
            }
            else
            {
                MessageBox.Show("Debes añadir un nombre al circuito");
            }
        }

        private void Circuito_Load(object sender, EventArgs e)
        {
            //se rellena la lista de circuitos desde base de datos
            listaCircuitos = BDCircuitos.buscarCircuitos();
            //si la lista de bloques no esta vacia se recorre dicha lista y se pintan los diferentes circuitos en la lista de elementos
            if (Circuito.listaCircuitos != null)
            {
                foreach (ClaseCircuito ocircuito in listaCircuitos)
                {
                    if (ocircuito.padre == 0)
                    {
                        lista_circuitos.Items.Add(ocircuito.titulo + " >");
                    }
                }
                listaCircuitos.Clear();
                lista_circuitos.SelectedValueChanged += delegate (object send, EventArgs ea) { string circuito = lista_circuitos.SelectedItem.ToString(); circuito = circuito.Replace(" >", ""); circuito = circuito.Replace(" ", ""); BuscarHijos(circuito); };
            }
        }

        private void BuscarHijos(string nombre)
        {
            int posicion = lista_circuitos.SelectedIndex;

            ocircuitoPadre = BDCircuitos.buscarCircuitoPadre(nombre);

            if (ocircuitoPadre != null)
            {
                int idPadre = ocircuitoPadre.id;
                circuitosHijos = BDCircuitos.buscarCircuitosHijos(idPadre);

                if (circuitosHijos != null)
                {
                    foreach (ClaseCircuito ocircuito in circuitosHijos)
                    {
                        for (int x = lista_circuitos.Items.Count - 1; x >= 0; --x)
                        {
                            string removelistitem = ocircuito.titulo;
                            if (lista_circuitos.Items[x].ToString().Contains(removelistitem))
                            {
                                lista_circuitos.Items.RemoveAt(x);
                            }
                        }
                        contieneCircuitos = BDCircuitos.contieneCircuitos(ocircuito.id);
                        if (contieneCircuitos)
                        {
                            int nivel = ocircuito.nivel;

                            //dependiendo de a que nivel esten se les pondra una separacion para poder diferenciar a que altura estan
                            switch (nivel)
                            {
                                case 1:
                                    lista_circuitos.Items.Add(ocircuito.titulo + " >");
                                    break;
                                case 2:
                                    lista_circuitos.Items.Insert(posicion + 1, "  " + ocircuito.titulo + " >");
                                    break;
                                case 3:
                                    lista_circuitos.Items.Insert(posicion + 1, "    " + ocircuito.titulo + " >");
                                    break;
                                case 4:
                                    lista_circuitos.Items.Insert(posicion + 1, "      " + ocircuito.titulo + " >");
                                    break;
                                case 5:
                                    lista_circuitos.Items.Insert(posicion + 1, "        " + ocircuito.titulo + " >");
                                    break;
                            }
                        }
                        else
                        {
                            int nivel = ocircuito.nivel;

                            //dependiendo de a que nivel esten se les pondra una separacion para poder diferenciar a que altura estan
                            switch (nivel)
                            {
                                case 1:
                                    lista_circuitos.Items.Insert(posicion + 1, ocircuito.titulo);
                                    break;
                                case 2:
                                    lista_circuitos.Items.Insert(posicion + 1, "  " + ocircuito.titulo);
                                    break;
                                case 3:
                                    lista_circuitos.Items.Insert(posicion + 1, "    " + ocircuito.titulo);
                                    break;
                                case 4:
                                    lista_circuitos.Items.Insert(posicion + 1, "      " + ocircuito.titulo);
                                    break;
                                case 5:
                                    lista_circuitos.Items.Insert(posicion + 1, "        " + ocircuito.titulo);
                                    break;
                            }
                        }
                    }
                    circuitosHijos.Clear();
                }
                else
                {
                    circuitosHijos = new ArrayList();
                }
                circuitosHijos.Clear();
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Controlador.mostrarMenu();
        }
    }
}
