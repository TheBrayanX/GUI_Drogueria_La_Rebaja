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
    public partial class crear_Cuenta : Form
    {
        public crear_Cuenta()
        {
            InitializeComponent();
        }

        private void crear_Cuenta_Load(object sender, EventArgs e)
        {
            txtpassword.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Se define las variables de los TextBox como tipo cadena de texto.
            string Cedula = txtcc.Text;
            string Nombre = txtname.Text;
            string Apellido = txtapellido.Text;
            string password = txtpassword.Text;

            //Consulta
            string sql = "INSERT INTO `clientes` (`cedula`, `nombre`, `apellido`, `contraseña`) VALUES ('" + Cedula + "','" + Nombre + "','" + Apellido + "','" + password + "');";

            //Se instancia la clase conexión y se abre.
            MySqlConnection conexionBD = conexion.Conexion();
            conexionBD.Open();

            try
            {
                //Se crea una variable para que pueda tomar el comando de la consulta y la conexión de la base de datos de MySQL.
                MySqlCommand codigo = new MySqlCommand(sql, conexionBD);
                //Ejecuta el codigo.
                codigo.ExecuteNonQuery();
                //Al ejecutarse el codigo, se instancia la pestaña y se envia un aviso cerrandose la actual.
                iniciar_Sesion devolver = new iniciar_Sesion();
                devolver.Show();
                this.Close();
                MessageBox.Show("Cuenta creada con éxito.");
            }
            catch (MySqlException ex)
            {
                //Mensaje de error si hay algún problema.
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Se cierra la conexión.
                conexionBD.Close();
            }
        }
    }
}
