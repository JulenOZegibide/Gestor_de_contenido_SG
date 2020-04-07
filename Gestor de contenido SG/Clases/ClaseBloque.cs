using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_contenido_SG
{
    public class ClaseBloque
    {
        public int id, pagina_id;
        public string titulo;

        public ClaseBloque(int id, string titulo, int pagina_id)
        {
            this.id = id;
            this.titulo = titulo;
            this.pagina_id = pagina_id;
        }

        public ClaseBloque(string titulo, int pagina_id)
        {
            this.titulo = titulo;
            this.pagina_id = pagina_id;    
        }

        public ClaseBloque()
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

        public void setPagina_id(int pagina_id)
        {
            this.pagina_id = pagina_id;
        }

        public int getPagina_id()
        {
            return this.pagina_id;
        }
    }
}
