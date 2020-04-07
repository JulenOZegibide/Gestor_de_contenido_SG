using System;
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
    public partial class Columna : Form
    {
        public Columna(string id, string nombre)
        {
            InitializeComponent();
            columna_id.Text = id;
            nombre_columna.Text = nombre;
        }

        private void Columna_Load(object sender, EventArgs e)
        {

        }
    }
}
