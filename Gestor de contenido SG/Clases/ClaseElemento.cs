using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_contenido_SG.Clases
{
    class ClaseElemento
    {
        public int id, ancho, espacio_izquierda, espacio_arriba, columna_id, alto;
        public string tipo, contenido;

        public ClaseElemento(int id, string tipo, string contenido, int columna_id, int ancho, int espacio_izquierda, int espacio_arriba, int alto)
        {
            this.id = id;
            this.tipo = tipo;
            this.contenido = contenido;
            this.ancho = ancho;
            this.espacio_izquierda = espacio_izquierda;
            this.espacio_arriba = espacio_arriba;
            this.columna_id = columna_id;
            this.alto = alto;
        }

        public ClaseElemento(string tipo, string contenido, int columna_id, int ancho, int espacio_izquierda, int espacio_arriba, int alto)
        {
            this.tipo = tipo;
            this.contenido = contenido;
            this.ancho = ancho;
            this.espacio_izquierda = espacio_izquierda;
            this.espacio_arriba = espacio_arriba;
            this.columna_id = columna_id;
            this.alto = alto;
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

        public void setAncho(int ancho)
        {
            this.ancho = ancho;
        }

        public int getAncho()
        {
            return this.ancho;
        }

        public void setEspacio_izquierda(int espacio_izquierda)
        {
            this.espacio_izquierda = espacio_izquierda;
        }

        public int getEspacio_izquierda()
        {
            return this.espacio_izquierda;
        }

        public void setEspacio_arriba(int espacio_arriba)
        {
            this.espacio_arriba = espacio_arriba;
        }

        public int getEspacio_arriba()
        {
            return this.espacio_arriba;
        }

        public void setColumna_id(int columna_id)
        {
            this.columna_id = columna_id;
        }

        public int getColumna_id()
        {
            return this.columna_id;
        }

        public void setAlto(int alto)
        {
            this.alto = alto;
        }

        public int getAlto()
        {
            return this.alto;
        }
    }
}
