﻿using Gestor_de_contenido_SG.FuncionesBD;
using System;
using System.Collections;
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
        public CrearPagina()
        {
            InitializeComponent();

            //funcion que se llama al cerrar la ventana
            this.FormClosing += new FormClosingEventHandler(Controlador.cerrarPaginaActual);

            //Para evitar que el usuario de la aplicacion cambie el tamaño de la pestaña
            this.FormBorderStyle = FormBorderStyle.None;
        }

        public void crearPagina_Load(object sender, EventArgs e)
        {
            //se rellena la lista de circuitos desde base de datos
            Circuito.listaCircuitos = BDCircuitos.buscarCircuitos();

            //si la lista de bloques no esta vacia se recorre dicha lista y se pintan los diferentes circuitos en la lista de elementos
            if (Circuito.listaCircuitos != null)
            {
                foreach (ClaseCircuito ocircuito in Circuito.listaCircuitos)
                {
                    if (ocircuito.padre == 0)
                    {
                        lista_circuitos.Items.Add(ocircuito.titulo + " >");
                    }
                }
                Circuito.listaCircuitos.Clear();
                lista_circuitos.SelectedValueChanged += delegate (object send, EventArgs ea) { string circuito = lista_circuitos.SelectedItem.ToString(); circuito = circuito.Replace(" >", ""); circuito = circuito.Replace(" ", ""); BuscarHijos(circuito); };
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

            Circuito.contieneCircuitos = BDCircuitos.contieneCircuitos(circuitoId);

            if (Circuito.contieneCircuitos)
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

        private void BuscarHijos(string nombre)
        {
            //se guarda la posicion para a la hora de insertar los circuitos hijos se coloquen justo detras del circuito padre
            int posicion = lista_circuitos.SelectedIndex;

            //se busca el circuito padre
            Circuito.ocircuitoPadre = BDCircuitos.buscarCircuitoPadre(nombre);

            //si existe el circuito padre se rellenara la lista sino no hara nada
            if (Circuito.ocircuitoPadre != null)
            {
                //se guarda el id del padre y se rellena una lista con todos los circuitos hijos de ese padre
                int idPadre = Circuito.ocircuitoPadre.id;
                Circuito.circuitosHijos = BDCircuitos.buscarCircuitosHijos(idPadre);

                //si la lista de circuitos hijos no esta vacia se recorrera para rellenar el menu de seleccion de circuito
                if (Circuito.circuitosHijos != null)
                {
                    foreach (ClaseCircuito ocircuito in Circuito.circuitosHijos)
                    {
                        //funcion para evitar repetidos
                        for (int x = lista_circuitos.Items.Count - 1; x >= 0; --x)
                        {
                            string removelistitem = ocircuito.titulo;
                            if (lista_circuitos.Items[x].ToString().Contains(removelistitem))
                            {
                                lista_circuitos.Items.RemoveAt(x);
                            }
                        }
                        //se busca si el circuito que se va a insertar al menu tiene hijos
                        Circuito.contieneCircuitos = BDCircuitos.contieneCircuitos(ocircuito.id);

                        //si el circuito que se va a insertar tiene hijos se insertara con un " >" por detras sino no
                        if (Circuito.contieneCircuitos)
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
                    Circuito.circuitosHijos.Clear();
                }
                else
                {
                    Circuito.circuitosHijos = new ArrayList();
                }
                Circuito.circuitosHijos.Clear();
            }
        }

        private void volver_Click(object sender, EventArgs e)
        {
            this.Close();
            Controlador.mostrarMenu();
        }
    }
}
