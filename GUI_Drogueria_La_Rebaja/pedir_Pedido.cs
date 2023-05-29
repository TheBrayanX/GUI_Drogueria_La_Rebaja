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

namespace GUI_Drogueria_La_Rebaja
{
    public partial class pedir_Pedido : Form
    {
        public pedir_Pedido()
        {
            InitializeComponent();
        }

        private void lblDate_Click(object sender, EventArgs e)
        {

        }

        private void pedir_Pedido_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("D");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String fullname = txtFullName.Text;
            String address = txtAddress.Text;
            String phone = txtPhone.Text;
            String home_presential = comboDomicilio.Text;
            String type = comboType.Text;
            String brand = comboBrand.Text;
            String acomount = txtAcomount.Text;

            string sql = "INSERT INTO `pedidos` (`id`,`nombre_Completo`, `direccion`, `phone`, `domicilio`, `tipo`, `marca`, `cantidad`) VALUES (NULL,'" + fullname + "','"+address+"','"+phone+"','"+home_presential+"', '"+type+"','"+brand+"','"+acomount+"');";

            MySqlConnection conexionBD = conexion.Conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand codigo = new MySqlCommand(sql, conexionBD);
                codigo.ExecuteNonQuery();
                MessageBox.Show("Tu pedido ha sido registrado.");
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

        private void button3_Click(object sender, EventArgs e)
        {
            mostrar_Pedidos mp = new mostrar_Pedidos();
            mp.Show();
        }
    }
}
