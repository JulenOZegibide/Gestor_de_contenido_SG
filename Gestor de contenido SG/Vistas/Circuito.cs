using Gestor_de_contenido_SG.FuncionesBD;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string circuito = lista_circuitos.SelectedItem.ToString();
            circuito = circuito.Replace(" ", "");

            string titulo = titulo_circuito.Text;

            int nivel, padre;

            switch (circuito)
            {
                case "Crear circuito padre":

                    nivel = 1;
                    padre = 0;

                    break;
                default:
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

            if (titulo != "")
            {
                ClaseCircuito ocircuito = new ClaseCircuito(nivel, padre, titulo);

                BDCircuitos.insertarCircuito(ocircuito);
            }
            else
            {
                MessageBox.Show("Debes añadir un nombre al circuito");
            }
        }

        private void Circuito_Load(object sender, EventArgs e)
        {
            listaCircuitos.Clear();
            listaCircuitos = BDCircuitos.buscarCircuitos();
            foreach (ClaseCircuito ocircuito in listaCircuitos)
            {
                int nivel = ocircuito.nivel;

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
        }
    }
}
