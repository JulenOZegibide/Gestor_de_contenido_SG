using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_contenido_SG
{
    public class ClasePagina
    {
        public int id, circuito_id;
        public string titulo;

        public ClasePagina(int id, string titulo , int circuito_id)
        {
            this.id = id;            
            this.titulo = titulo;
            this.circuito_id = circuito_id;
        }

        public ClasePagina(string titulo, int circuito_id)
        {
            this.titulo = titulo;
            this.circuito_id = circuito_id;
        }

        public ClasePagina()
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

        public void setCircuito_id(int circuito_id)
        {
            this.circuito_id = circuito_id;
        }

        public int getCircuito_id()
        {
            return this.circuito_id;
        }
    }
}
