using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestor_de_contenido_SG.FuncionesBD
{
    class BDPaginas
    {
        public static void insertarPagina(ClasePagina opagina)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string insertar = "INSERT INTO PAGINAS(TITULO,CIRCUITO_ID) VALUES (@titulo, @circuitoId)";
                OleDbCommand cmd = new OleDbCommand(insertar, BDConexion);

                cmd.Parameters.AddWithValue("@titulo", opagina.titulo);
                cmd.Parameters.AddWithValue("@circuitoId", opagina.circuito_id);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Registro guardado");
            }
            catch (DBConcurrencyException ex)
            {
                MessageBox.Show("Error de concurrencia:\n" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            BDConexion.Close();
        }

        public static int buscarIdPagina(string tituloPagina)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string buscar = "SELECT ID FROM PAGINAS WHERE TITULO = @titulo";
                OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);
                cmd.Parameters.AddWithValue("@titulo", tituloPagina);

                OleDbDataReader lector = cmd.ExecuteReader();
                object[] objeto = new object[10];
                bool read;
                if (lector.Read())
                {
                    do
                    {
                        int NumberOfColums = lector.GetValues(objeto);

                        int paginaId = Convert.ToInt16(objeto[0]);
                        Console.WriteLine();
                        read = lector.Read();

                        BDConexion.Close();
                        return paginaId;
                    }
                    while (read == true);
                }
                else
                {
                    MessageBox.Show("No hay filas");
                    BDConexion.Close();
                    return 0;
                }
            }
            catch (DBConcurrencyException ex)
            {
                MessageBox.Show("Error de concurrencia:\n" + ex.Message);
                BDConexion.Close();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                BDConexion.Close();
                return 0;
            }
        }

        public static ArrayList buscarPaginas()
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string buscar = "SELECT * FROM PAGINAS";
                OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);
                OleDbDataReader lector = cmd.ExecuteReader();
                object[] objeto = new object[10];
                bool read;
                if (lector.Read())
                {
                    do
                    {
                        int NumberOfColums = lector.GetValues(objeto);

                        ClasePagina opagina = new ClasePagina(Convert.ToInt16(objeto[0]), objeto[1].ToString(), Convert.ToInt16(objeto[2]));
                        Pagina.listaPaginas.Add(opagina);

                        Console.WriteLine();
                        read = lector.Read();
                    }
                    while (read == true);
                    BDConexion.Close();
                    return Pagina.listaPaginas;
                }
                else
                {
                    BDConexion.Close();
                    return null;
                }
            }
            catch (DBConcurrencyException ex)
            {
                MessageBox.Show("Error de concurrencia:\n" + ex.Message);
                BDConexion.Close();
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                BDConexion.Close();
                return null;
            }
        }
    }
}
