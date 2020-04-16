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
                    /*if(ocircuito != null)
                    {
                        nivel = ocircuito.nivel + 1;
                        padre = ocircuito.id;
                    }
                    else
                    {
                        MessageBox.Show("Ha habido un error al buscar el circuito padre");
                    }*/
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
                    int nivel = ocircuito.nivel;

                    //dependiendo de a que nivel esten se les pondra una separacion para poder diferenciar a que altura estan
                    switch (nivel)
                    {
                        case 1:
                            lista_circuitos.Items.Add(ocircuito.titulo);
                            break;
                        case 2:
                            lista_circuitos.Items.Add("  " + ocircuito.titulo);
                            break;
                        case 3:
                            lista_circuitos.Items.Add("    " + ocircuito.titulo);
                            break;
                        case 4:
                            lista_circuitos.Items.Add("      " + ocircuito.titulo);
                            break;
                        case 5:
                            lista_circuitos.Items.Add("        " + ocircuito.titulo);
                            break;
                    }
                    lista_circuitos.Sorted = true;                   
                }
                listaCircuitos.Clear();
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Controlador.mostrarMenu();
        }
    }
}
