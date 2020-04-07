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
    class BDColumnas
    {
        public static void insertarColumna(ClaseColumna ocolumna)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string insertar = "INSERT INTO COLUMNAS(TITULO,ANCHO,BLOQUE_ID) VALUES (@titulo, @ancho, @bloqueId)";
                OleDbCommand cmd = new OleDbCommand(insertar, BDConexion);

                cmd.Parameters.AddWithValue("@titulo", ocolumna.titulo);
                cmd.Parameters.AddWithValue("@ancho", ocolumna.ancho);
                cmd.Parameters.AddWithValue("@bloqueId", ocolumna.bloque_id);

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

        public static int buscarIdColumnaMax()
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string buscar = "SELECT MAX(ID) FROM COLUMNAS";
                OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);

                OleDbDataReader lector = cmd.ExecuteReader();
                object[] objeto = new object[10];
                bool read;
                if (lector.Read())
                {
                    do
                    {
                        int NumberOfColums = lector.GetValues(objeto);

                        int idMaximo = Convert.ToInt16(objeto[0]);

                        Console.WriteLine();
                        read = lector.Read();

                        BDConexion.Close();
                        return idMaximo;
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
                //problema cuando no existen ningun bloque devuelve error y lo fuerzo a que devuelva 0
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
    }
}
