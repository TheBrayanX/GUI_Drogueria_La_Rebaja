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
    public partial class forget_Password : Form
    {
        public forget_Password()
        {
            InitializeComponent();
        }

        private void forget_Password_Load(object sender, EventArgs e)
        {
            new_pass1.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cedula = txtcc.Text;
            String nueva_contraseña = new_pass1.Text;

            string SQL = "UPDATE `clientes` SET `contraseña` = '" + nueva_contraseña + "' WHERE `clientes`.`cedula` = '" + cedula + "';";

            MySqlConnection conexionBD = conexion.Conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand codigo = new MySqlCommand(SQL, conexionBD);
                codigo.ExecuteNonQuery();

                iniciar_Sesion devolver = new iniciar_Sesion();
                devolver.Show();
                this.Close();
                MessageBox.Show("Has modificado tu contraseña.");
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
    }
}
