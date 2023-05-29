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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI_Drogueria_La_Rebaja
{
    public partial class iniciar_Sesion : Form
    {
        public iniciar_Sesion()
        {
            InitializeComponent();
        }

        private void iniciar_Sesion_Load(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Cedula = txtcc.Text;
            string password = txtpassword.Text;
            MySqlCommand codigo = new MySqlCommand();
            MySqlConnection conexionBD = conexion.Conexion();
            conexionBD.Open();
            codigo.Connection = conexionBD;
            codigo.CommandText = "SELECT cedula,contraseña FROM `clientes` WHERE cedula='" + Cedula + "' and contraseña='" + password + "'";
            MySqlDataReader leer = codigo.ExecuteReader();
            if (leer.Read())
            {
                pedir_Pedido p = new pedir_Pedido();
                p.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Su usuario no está encontrado. ");
            }
            conexionBD.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            forget_Password fp = new forget_Password();
            fp.Show();
        }
    }
}
