using Base_de_datos.Accesos;
using Base_de_datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_3
{
    public partial class Formulario_Gestion_Usuarios : Form
    {
        public Formulario_Gestion_Usuarios()
        {
            InitializeComponent();
        }

        UsuarioDA usuarioDA = new UsuarioDA();
        String Operacion = String.Empty;
        Usuario User = new Usuario();

        private void Formulario_Gestion_Usuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();

        }

        private void ListarUsuarios()
        {
            ListaUsuariosdataGridView.DataSource = usuarioDA.ListarUsuarios();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            Operacion = "Nuevo";
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            PuestoTextBox.Enabled = true;
            ClaveTextBox.Enabled = true;
            EdadTextBox.Enabled = true;
            EstaActivocheckBox.Enabled = true;

            NuevoButton.Enabled = false;
            Guardarbutton.Enabled = true;
            Cancelarbutton.Enabled = true;
        }

        private void DesabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            PuestoTextBox.Enabled = false;
            ClaveTextBox.Enabled = false;
            EdadTextBox.Enabled = false;
            EstaActivocheckBox.Enabled = false;

            NuevoButton.Enabled = true;
            Guardarbutton.Enabled = false;
            Cancelarbutton.Enabled = false;
        }


        private void limpiarcontroles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Clear();
            PuestoTextBox.Clear();
            ClaveTextBox.Clear();
            EdadTextBox.Clear();
            EstaActivocheckBox.Enabled = false;




        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            User.Codigo = CodigoTextBox.Text;
            User.Nombre = NombreTextBox.Text;
            User.Puesto = PuestoTextBox.Text;
            User.Clave = ClaveTextBox.Text;
            User.Edad = Convert.ToInt32(EdadTextBox.Text);
            User.EstaActivo = EstaActivocheckBox.Checked;





            bool inserto = usuarioDA.InsertarUsuario(User);

            if (Operacion == "Nuevo")
            {
                if (inserto)
                {
                    MessageBox.Show("Usuario Creado");
                    ListarUsuarios();
                    limpiarcontroles();
                    DesabilitarControles();


                }
                else
                {
                    MessageBox.Show("Usuario no se pudo crear");
                }
            }
            else if (Operacion == "Modificar")
            {
                bool Modifico = usuarioDA.InsertarUsuario(User);

                if (Modifico)
                {
                    MessageBox.Show("Usuario Modificado");
                    ListarUsuarios();
                    limpiarcontroles();
                    DesabilitarControles();


                }
                else
                {
                    MessageBox.Show("Usuario no se pudo modificar");
                }
            }




        }

        private void Modificarbutton_Click(object sender, EventArgs e)
        {
            Operacion = "Modificar";
            if (ListaUsuariosdataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = ListaUsuariosdataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                NombreTextBox.Text = ListaUsuariosdataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                PuestoTextBox.Text = ListaUsuariosdataGridView.CurrentRow.Cells["Puesto"].Value.ToString();
                ClaveTextBox.Text = ListaUsuariosdataGridView.CurrentRow.Cells["Clave"].Value.ToString();
                EdadTextBox.Text = ListaUsuariosdataGridView.CurrentRow.Cells["Edad"].Value.ToString();
                EstaActivocheckBox.Checked = Convert.ToBoolean(ListaUsuariosdataGridView.CurrentRow.Cells["EstaActivo"].Value);
                HabilitarControles();




            }




        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (ListaUsuariosdataGridView.SelectedRows.Count > 0)
            {
                bool elimino = usuarioDA.EliminarUsuario(ListaUsuariosdataGridView.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {
                    MessageBox.Show("Usuario elimino");
                    ListarUsuarios();



                }
                else
                {
                    MessageBox.Show("Usuario no se pudo eliminar");


                }




            }
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}


