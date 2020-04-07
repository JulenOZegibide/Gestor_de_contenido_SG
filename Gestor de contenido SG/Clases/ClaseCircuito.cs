using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_contenido_SG
{
    public class ClaseCircuito
    {
        public int id, nivel, padre;
        public string titulo;

        public ClaseCircuito(int id,int nivel, int padre,string titulo)
        {
            this.id = id;
            this.nivel = nivel;
            this.padre = padre;
            this.titulo = titulo;
        }

        public ClaseCircuito(int nivel, int padre, string titulo)
        {           
            this.nivel = nivel;
            this.padre = padre;
            this.titulo = titulo;
        }

        public ClaseCircuito()
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

        public void setNivel(int nivel)
        {
            this.nivel = nivel;
        }

        public int getNivel()
        {
            return this.nivel;
        }

        public void setPadre(int padre)
        {
            this.padre = padre;
        }

        public int getPadre()
        {
            return this.padre;
        }

        public void setTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public string getTitulo()
        {
            return this.titulo;
        }
    }
}
