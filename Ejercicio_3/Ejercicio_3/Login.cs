using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Base_de_datos.Accesos;
using Base_de_datos.Entidades;


namespace Ejercicio_3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            UsuarioDA UsuarioDA = new UsuarioDA();  
            Usuario Usuario = new Usuario();

            Usuario = UsuarioDA.Login(CodigoTextBox.Text,ContraseniaTextBox.Text);



            if (Usuario == null)
            {
                MessageBox.Show("Usuario o contraseña no validos");
                return; 
            }
            else if (Usuario.EstaActivo)
            {
                MessageBox.Show("Usuario Inactivo");
                return;
            }

            Formulario_Gestion_Usuarios formulario_Gestion_Usuarios = new Formulario_Gestion_Usuarios();
            formulario_Gestion_Usuarios.Show();



        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
