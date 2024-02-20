using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro.Clases
{
    internal class CRegistro
    {
        public void mostrarRegistro(DataGridView tablaRegistro)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "select * from Departamento";
                tablaRegistro.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaRegistro.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos, error : " + ex.ToString());

            }

        }
        public void guardarRegistro(TextBox ID_Depart, TextBox Nom_Dept, TextBox ID_Fab, TextBox Estatus)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "insert into Departamento (ID_Depart, Nom_Dept, ID_Fab, Estatus)" +
                    "values ('" + ID_Depart.Text + "','" + Nom_Dept.Text + "','" + ID_Fab.Text + "','" + Estatus.Text + "');";
                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myComand.ExecuteReader();
                MessageBox.Show("se guardaron los registros");
                while (reader.Read())
                {

                }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se guardaron los datos, error : " + ex.ToString());

            }
        }

        public void eliminarRegistro(TextBox ID_Depart, TextBox Nom_Dept, TextBox ID_Fab, TextBox Estatus)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "delete from Departamento";

                MySqlCommand myComand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = myComand.ExecuteReader();
                MessageBox.Show("se eliminaron los registros");
                while (reader.Read())
                {

                }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos, error : " + ex.ToString());

            }

        }

    }
}

