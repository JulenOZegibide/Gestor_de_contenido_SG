using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_contenido_SG.Clases
{
    class ClaseElemento
    {
        public int id, ancho, columna_id;
        public string tipo, contenido;

        public ClaseElemento(int id, string tipo, string contenido, int columna_id)
        {
            this.id = id;
            this.tipo = tipo;
            this.contenido = contenido;
            this.columna_id = columna_id;
        }

        public ClaseElemento(string tipo, string contenido, int columna_id)
        {
            this.tipo = tipo;
            this.contenido = contenido;
            this.columna_id = columna_id;
        }

        public ClaseElemento()
        {

        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public void setTipo(string tipo)
        {
            this.tipo = tipo;
        }

        public string getTipo()
        {
            return this.tipo;
        }

        public void setContenido(string contenido)
        {
            this.contenido = contenido;
        }

        public string getContenido()
        {
            return this.contenido;
        }

        public void setColumna_id(int columna_id)
        {
            this.columna_id = columna_id;
        }

        public int getColumna_id()
        {
            return this.columna_id;
        }

    }
}
