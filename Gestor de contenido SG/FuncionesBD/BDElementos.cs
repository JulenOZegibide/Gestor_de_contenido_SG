using Gestor_de_contenido_SG.Clases;
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
    class BDElementos
    {
        public static void insertarElemento(ClaseElemento oelemento)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string insertar = "INSERT INTO ELEMENTOS(TIPO,CONTENIDO,ANCHO,ESPACIO_IZQUIERDA,ESPACIO_ARRIBA,COLUMNA_ID) VALUES (@tipo, @contenido, @ancho, @espacio_izquierda, @espacio_arriba, @columnaId)";
                OleDbCommand cmd = new OleDbCommand(insertar, BDConexion);

                cmd.Parameters.AddWithValue("@tipo", oelemento.tipo);
                cmd.Parameters.AddWithValue("@contenido", oelemento.contenido);
                cmd.Parameters.AddWithValue("@ancho", oelemento.ancho);
                cmd.Parameters.AddWithValue("@espacio_izquierda", oelemento.espacio_izquierda);
                cmd.Parameters.AddWithValue("@espacio_arriba", oelemento.espacio_arriba);
                cmd.Parameters.AddWithValue("@columnaId", oelemento.columna_id);

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

        public static ArrayList buscarElementos(string columna_id)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string buscar = "SELECT * FROM ELEMENTOS WHERE COLUMNA_ID = @columnaId";
                OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);

                cmd.Parameters.AddWithValue("@columnaId", columna_id);

                OleDbDataReader lector = cmd.ExecuteReader();
                object[] objeto = new object[10];
                bool read;
                if (lector.Read())
                {
                    do
                    {
                        int NumberOfColums = lector.GetValues(objeto);

                        ClaseElemento oelemento = new ClaseElemento(Convert.ToInt16(objeto[0]), objeto[1].ToString(), objeto[2].ToString(), Convert.ToInt16(objeto[3]), Convert.ToInt16(objeto[4]), Convert.ToInt16(objeto[5]), Convert.ToInt16(objeto[6]));
                        Columna.listaElementos.Add(oelemento);
                        
                        Console.WriteLine();
                        read = lector.Read();
                    }
                    while (read == true);
                    BDConexion.Close();
                    return Columna.listaElementos;
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

        public static void actualizarAncho(int ancho, int id)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string actualizar = "UPDATE ELEMENTOS SET ANCHO = @ancho WHERE ID = @id";
                OleDbCommand cmd = new OleDbCommand(actualizar, BDConexion);

                cmd.Parameters.AddWithValue("@ancho", ancho);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
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

        public static void actualizarPosicion(int izquierda, int arriba, int id)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string actualizar = "UPDATE ELEMENTOS SET ESPACIO_IZQUIERDA = @izquierda , ESPACIO_ARRIBA = @arriba WHERE ID = @id";
                OleDbCommand cmd = new OleDbCommand(actualizar, BDConexion);

                cmd.Parameters.AddWithValue("@izquierda", izquierda);
                cmd.Parameters.AddWithValue("@arriba", arriba);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
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

        public static void borrarElemento(int id)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string borrar = "DELETE FROM ELEMENTOS WHERE ID = "+ id;
                OleDbCommand cmd = new OleDbCommand(borrar, BDConexion);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Elemento eliminado");
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
    }
}
