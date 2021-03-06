﻿using System;
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
    class BDBloques
    {
        public static void insertarBloque(ClaseBloque obloque)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string insertar = "INSERT INTO BLOQUES(TITULO,PAGINA_ID) VALUES (@titulo, @paginaId)";
                OleDbCommand cmd = new OleDbCommand(insertar, BDConexion);

                cmd.Parameters.AddWithValue("@titulo", obloque.titulo);
                cmd.Parameters.AddWithValue("@paginaId", obloque.pagina_id);

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

        /*public static void actu()
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string insertar = "ALTER TABLE ELEMENTOS ADD COLUMN alto CHAR(25)";
                OleDbCommand cmd = new OleDbCommand(insertar, BDConexion);

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
        }*/

        public static int buscarIdBloque(string tituloBloque)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string buscar = "SELECT ID FROM BLOQUES WHERE TITULO = @titulo";
                OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);

                cmd.Parameters.AddWithValue("@titulo", tituloBloque);

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

        public static ArrayList buscarBloques(string pagina_id)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string buscar = "SELECT * FROM BLOQUES WHERE PAGINA_ID = @paginaId";
                OleDbCommand cmd = new OleDbCommand(buscar, BDConexion);
                cmd.Parameters.AddWithValue("@paginaId", pagina_id);
                OleDbDataReader lector = cmd.ExecuteReader();
                object[] objeto = new object[10];
                bool read;
                if (lector.Read())
                {
                    do
                    {
                        int NumberOfColums = lector.GetValues(objeto);

                        ClaseBloque obloque = new ClaseBloque(Convert.ToInt16(objeto[0]), objeto[1].ToString(), Convert.ToInt16(objeto[2]));
                        Pagina.listaBloques.Add(obloque);

                        Console.WriteLine();
                        read = lector.Read();
                    }
                    while (read == true);
                    BDConexion.Close();
                    return Pagina.listaBloques;
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

        public static void borrarBloque(string id)
        {
            Controlador.Conectar();
            OleDbConnection BDConexion = Controlador.BDConexion;
            BDConexion.Open();
            try
            {
                string borrarElementos = "DELETE FROM ELEMENTOS WHERE COLUMNA_ID IN(SELECT ID FROM COLUMNAS WHERE BLOQUE_ID =" + id + ")";
                OleDbCommand cmd3 = new OleDbCommand(borrarElementos, BDConexion);

                cmd3.ExecuteNonQuery();

                string borrarColumna = "DELETE FROM COLUMNAS WHERE BLOQUE_ID = " + id;
                OleDbCommand cmd2 = new OleDbCommand(borrarColumna, BDConexion);

                cmd2.ExecuteNonQuery();

                string borrarBloque = "DELETE FROM BLOQUES WHERE ID = " + id;
                OleDbCommand cmd1 = new OleDbCommand(borrarBloque, BDConexion);

                cmd1.ExecuteNonQuery();

                MessageBox.Show("Bloque eliminado");
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
