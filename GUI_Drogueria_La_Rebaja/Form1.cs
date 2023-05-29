namespace GUI_Drogueria_La_Rebaja
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cuando se presiona este boton, se cierra la pestaña.
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            crear_Cuenta cc = new crear_Cuenta();
            cc.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            iniciar_Sesion i = new iniciar_Sesion();
            i.Show();
        }
    }
}