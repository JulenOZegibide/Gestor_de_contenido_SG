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
        public CrearPagina()
        {
            InitializeComponent();
        }

        public void crearPagina_Load(object sender, EventArgs e)
        {
            Circuito.listaCircuitos.Clear();
            Circuito.listaCircuitos = BDCircuitos.buscarCircuitos();
            foreach (ClaseCircuito ocircuito in Circuito.listaCircuitos)
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

        public void button1_Click(object sender, EventArgs e)
        {
            string tituloPagina = titulo_pagina.Text;

            string circuito = lista_circuitos.SelectedItem.ToString();
            circuito = circuito.Replace(" ", "");

            ClaseCircuito ocircuito = BDCircuitos.buscarCircuitoPadre(circuito);

            int circuitoId = ocircuito.id;

            Pagina.crearPagina(tituloPagina, circuitoId);
        }
    }
}
