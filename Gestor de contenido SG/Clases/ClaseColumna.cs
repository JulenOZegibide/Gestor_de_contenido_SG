using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_contenido_SG
{
    public class ClaseColumna
    {
        public int id, ancho, bloque_id, alto;
        public string titulo;

        public ClaseColumna(int id, string titulo, int ancho, int bloque_id, int alto)
        {
            this.id = id;
            this.titulo = titulo;
            this.ancho = ancho;           
            this.bloque_id = bloque_id;
            this.alto = alto;
        }

        public ClaseColumna(string titulo, int ancho, int bloque_id, int alto)
        {
            this.titulo = titulo;
            this.ancho = ancho;
            this.bloque_id = bloque_id;
            this.alto = alto;
        }

        public ClaseColumna()
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

        public void setTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public string getTitulo()
        {
            return this.titulo;
        }

        public void setAncho(int ancho)
        {
            this.ancho = ancho;
        }

        public int getAncho()
        {
            return this.ancho;
        }

        public void setBloque_id(int bloque_id)
        {
            this.bloque_id = bloque_id;
        }

        public int getBloque_id()
        {
            return this.bloque_id;
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
