using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI_Drogueria_La_Rebaja
{
    public partial class mostrar_Pedidos : Form
    {
        public mostrar_Pedidos()
        {
            InitializeComponent();
        }

        private void mostrar_Pedidos_Load(object sender, EventArgs e)
        {
            MySqlConnection conexionBD = conexion.Conexion();

            try
            {
                conexionBD.Open();
                MySqlCommand codigo = new MySqlCommand();
                codigo.Connection = conexionBD;
                codigo.CommandText = ("SELECT * FROM `pedidos`;");

                MySqlDataAdapter adapta = new MySqlDataAdapter();
                adapta.SelectCommand = codigo;

                DataTable table = new DataTable();
                adapta.Fill(table);
                dataview.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            conexionBD.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = idText.Text;
            string sql = "DELETE FROM `pedidos` WHERE id='"+id+"';";

            MySqlConnection conexionBD = conexion.Conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand codigo = new MySqlCommand(sql, conexionBD);
                codigo.ExecuteNonQuery();
                MessageBox.Show("Pedido eliminado, vuelve a consultar.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void dataview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
