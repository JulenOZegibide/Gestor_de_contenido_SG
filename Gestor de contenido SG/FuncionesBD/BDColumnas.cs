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
                string insertar = "INSERT INTO COLUMNAS(TITULO,ANCHO,BLOQUE_ID,ALTO,ESPACIO_IZQUIERDA,ESPACIO_ARRIBA) VALUES (@titulo, @ancho, @bloqueId, @alto, @espacio_izquierda, @espacio_arriba)";
                OleDbCommand cmd = new OleDbCommand(insertar, BDConexion);

                cmd.Parameters.AddWithValue("@titulo", ocolumna.titulo);
                cmd.Parameters.AddWithValue("@ancho", ocolumna.ancho);
                cmd.Parameters.AddWithValue("@bloqueId", ocolumna.bloque_id);
                cmd.Parameters.AddWithValue("@alto", ocolumna.alto);
                cmd.Parameters.AddWithValue("@espacio_izquierda", ocolumna.espacio_izquierda);
                cmd.Parameters.AddWithValue("@espacio_arriba", ocolumna.espacio_arriba);

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
                //MessageBox.Show(ex.Message);
                BDConexion.Close();
                return 0;
            }
        }

        public static ArrayList buscarColumnas(string bloque_id)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string buscar = "SELECT * FROM COLUMNAS WHERE BLOQUE_ID = @bloqueId";
                OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);
                cmd.Parameters.AddWithValue("@bloqueId", bloque_id);
                OleDbDataReader lector = cmd.ExecuteReader();
                object[] objeto = new object[10];
                bool read;
                if (lector.Read())
                {
                    do
                    {
                        int NumberOfColums = lector.GetValues(objeto);

                        ClaseColumna ocolumna = new ClaseColumna(Convert.ToInt16(objeto[0]), objeto[1].ToString(), Convert.ToInt16(objeto[2]), Convert.ToInt16(objeto[3]), Convert.ToInt16(objeto[4]), Convert.ToInt16(objeto[5]), Convert.ToInt16(objeto[6]));
                        Bloque.listaColumnas.Add(ocolumna);

                        Console.WriteLine();
                        read = lector.Read();
                    }
                    while (read == true);
                    BDConexion.Close();
                    return Bloque.listaColumnas;
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

        public static void actualizarAncho(int ancho,int id)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string actualizar = "UPDATE COLUMNAS SET ANCHO = @ancho WHERE ID = @id";
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

        public static void actualizarAlto(int alto, int id)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string actualizar = "UPDATE COLUMNAS SET ALTO = @alto WHERE ID = @id";
                OleDbCommand cmd = new OleDbCommand(actualizar, BDConexion);

                cmd.Parameters.AddWithValue("@alto", alto);
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

        public static int buscarIdColumna(string tituloColumna)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string buscar = "SELECT ID FROM COLUMNAS WHERE TITULO = @titulo";
                OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);

                cmd.Parameters.AddWithValue("@titulo", tituloColumna);

                OleDbDataReader lector = cmd.ExecuteReader();
                object[] objeto = new object[10];
                bool read;
                if (lector.Read())
                {
                    do
                    {
                        int NumberOfColums = lector.GetValues(objeto);

                        int id = Convert.ToInt16(objeto[0]);

                        Console.WriteLine();
                        read = lector.Read();

                        BDConexion.Close();
                        return id;
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
                //MessageBox.Show(ex.Message);
                BDConexion.Close();
                return 0;               
            }
        }

        public static void actualizarPosicion(int izquierda, int arriba, string nombre)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string actualizar = "UPDATE COLUMNAS SET ESPACIO_IZQUIERDA = @izquierda , ESPACIO_ARRIBA = @arriba WHERE TITULO = @nombre";
                OleDbCommand cmd = new OleDbCommand(actualizar, BDConexion);

                cmd.Parameters.AddWithValue("@izquierda", izquierda);
                cmd.Parameters.AddWithValue("@arriba", arriba);
                cmd.Parameters.AddWithValue("@nombre", nombre);

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

        public static void borrarColumna(string id)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {                
                string borrarColumna = "DELETE FROM COLUMNAS WHERE ID = " + id;
                OleDbCommand cmd1 = new OleDbCommand(borrarColumna, BDConexion);

                cmd1.ExecuteNonQuery();

                string borrarElementos = "DELETE FROM ELEMENTOS WHERE COLUMNA_ID = " + id;
                OleDbCommand cmd2 = new OleDbCommand(borrarElementos, BDConexion);

                cmd2.ExecuteNonQuery();

                MessageBox.Show("Columna eliminada");
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
