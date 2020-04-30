using Gestor_de_contenido_SG.FuncionesBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_contenido_SG
{
    public partial class CrearPagina : Form
    {
        //variables globales
        public static bool contieneCircuitos;

        public CrearPagina()
        {
            InitializeComponent();

            //funcion que se llama al cerrar la ventana
            this.FormClosing += new FormClosingEventHandler(Controlador.cerrarPaginaActual);
        }

        public void crearPagina_Load(object sender, EventArgs e)
        {
            //se rellena la lista de circuitos desde base de datos
            Circuito.listaCircuitos = BDCircuitos.buscarCircuitos();
            //si la lista de circuitos no esta vacia se recorre dicha lista y se pintan los diferentes bloques en la pagina
            if (Circuito.listaCircuitos != null)
            {
                foreach (ClaseCircuito ocircuito in Circuito.listaCircuitos)
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
                Circuito.listaCircuitos.Clear();
            }
            else
            {
                MessageBox.Show("No existe ningun circuito todavia, asegurate de tener algun circuito antes de insertar una pagina");
                this.Close();
            }
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string tituloPagina = titulo_pagina.Text;
            string circuito;

            if (lista_circuitos.SelectedItem != null)
            {
                circuito = lista_circuitos.SelectedItem.ToString();
                circuito = circuito.Replace(" ", "");
            }
            else
            {
                circuito = null;
                throw new Exception("Debes seleccionar a que circuito pertenece la pagina");
            }
           
            //se busca el id del circuito al que pertenece en base al texto del elemento seleccionado de la lista de circuitos 
            ClaseCircuito ocircuito = BDCircuitos.buscarCircuitoPadre(circuito);

            int circuitoId = ocircuito.id;

            contieneCircuitos = BDCircuitos.contieneCircuitos(circuitoId);

            if (contieneCircuitos)
            {
                throw new Exception("No puedes seleccionar un circuito que contenga circuitos, es decir que sea un circuito padre");
            }
            else
            {
                //se crea la pagina con el titulo de la pagina y el id del circuito padre
                Pagina.crearPagina(tituloPagina, circuitoId);
            }

            this.Close();
            Controlador.mostrarMenu();
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Controlador.mostrarMenu();
        }
    }
}
