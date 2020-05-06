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
    class BDCircuitos
    {
        public static void insertarCircuito(ClaseCircuito ocircuito)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string insertar = "INSERT INTO CIRCUITOS(TITULO,CIRCUITO_PADRE,NIVEL) VALUES (@titulo, @padre, @nivel)";
                OleDbCommand cmd = new OleDbCommand(insertar, BDConexion);

                cmd.Parameters.AddWithValue("@titulo", ocircuito.titulo);
                cmd.Parameters.AddWithValue("@padre", ocircuito.padre);
                cmd.Parameters.AddWithValue("@nivel", ocircuito.nivel);

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

        public static ArrayList buscarCircuitos()
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string buscar = "SELECT * FROM CIRCUITOS";
                OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);
                OleDbDataReader lector = cmd.ExecuteReader();
                object[] objeto = new object[10];
                bool read;
                if (lector.Read())
                {
                    do
                    {
                        int NumberOfColums = lector.GetValues(objeto);

                        ClaseCircuito ocircuito = new ClaseCircuito(Convert.ToInt16(objeto[0]), Convert.ToInt16(objeto[1]), Convert.ToInt16(objeto[2]), objeto[3].ToString());
                        Circuito.listaCircuitos.Add(ocircuito);

                        Console.WriteLine(ocircuito);
                        read = lector.Read();
                    }
                    while (read == true);
                    BDConexion.Close();
                    return Circuito.listaCircuitos;
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

        public static ArrayList buscarCircuitosHijos(int id)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            string buscar = "SELECT * FROM CIRCUITOS WHERE CIRCUITO_PADRE = @id";
            OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);
            cmd.Parameters.AddWithValue("@id", id);

            OleDbDataReader lector = cmd.ExecuteReader();
            object[] objeto = new object[10];
            bool read;
            if (lector.Read())
            {
                do
                {
                    int NumberOfColums = lector.GetValues(objeto);

                    ClaseCircuito ocircuito = new ClaseCircuito(Convert.ToInt16(objeto[0]), Convert.ToInt16(objeto[1]), Convert.ToInt16(objeto[2]), objeto[3].ToString());
                    Circuito.circuitosHijos.Add(ocircuito);

                    Console.WriteLine(ocircuito);
                    read = lector.Read();
                }
                while (read == true);
                BDConexion.Close();
                return Circuito.circuitosHijos;
            }
            else
            {
                BDConexion.Close();
                return null;
            }
        }

        public static ClaseCircuito buscarCircuitoPadre(string circuito)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            string buscar = "SELECT * FROM CIRCUITOS WHERE TITULO = @titulo";
            OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);
            cmd.Parameters.AddWithValue("@titulo", circuito);

            OleDbDataReader lector = cmd.ExecuteReader();
            object[] objeto = new object[10];
            bool read;
            if (lector.Read())
            {
                do
                {
                    int NumberOfColums = lector.GetValues(objeto);

                    ClaseCircuito ocircuito = new ClaseCircuito(Convert.ToInt16(objeto[0]), Convert.ToInt16(objeto[1]), Convert.ToInt16(objeto[2]), objeto[3].ToString());

                    Console.WriteLine();
                    read = lector.Read();

                    BDConexion.Close();
                    return ocircuito;
                }
                while (read == true);
            }
            else
            {
                BDConexion.Close();
                return null;
            }
        }

        public static bool contieneCircuitos(int circuitoId)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string buscar = "SELECT * FROM CIRCUITOS WHERE CIRCUITO_PADRE = " + circuitoId;
                OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);
                OleDbDataReader lector = cmd.ExecuteReader();
                object[] objeto = new object[10];
                bool read;
                if (lector.Read())
                {
                    do
                    {
                        int NumberOfColums = lector.GetValues(objeto);

                        Circuito.contieneCircuitos = true;

                        read = lector.Read();
                    }
                    while (read == true);
                    BDConexion.Close();
                    return Circuito.contieneCircuitos;
                }
                else
                {
                    BDConexion.Close();
                    return false;
                }
            }
            catch (DBConcurrencyException ex)
            {
                MessageBox.Show("Error de concurrencia:\n" + ex.Message);
                BDConexion.Close();
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                BDConexion.Close();
                return false;
            }

        }
    }
}
