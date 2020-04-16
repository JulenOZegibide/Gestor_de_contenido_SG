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
                string insertar = "INSERT INTO ELEMENTOS(TIPO,CONTENIDO,COLUMNA_ID) VALUES (@tipo, @contenido, @columnaId)";
                OleDbCommand cmd = new OleDbCommand(insertar, BDConexion);

                cmd.Parameters.AddWithValue("@tipo", oelemento.tipo);
                cmd.Parameters.AddWithValue("@contenido", oelemento.contenido);
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

                        ClaseElemento oelemento = new ClaseElemento(Convert.ToInt16(objeto[0]), objeto[1].ToString(), objeto[2].ToString(), Convert.ToInt16(objeto[3]));
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
    }
}
