using Base_de_datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_de_datos.Accesos
{
    public class UsuarioDA
    {
        readonly String Cadena = "Server=localhost; Port=3306; Database=ejercicio_3; Uid=root; Pwd=21436587;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public Usuario Login(String Codigo, String Clave)
        {
            Usuario User = null;

            try
            {
                String Sql = "SELECT * FROM usuarios WHERE Codigo = @Codigo AND Clave= @Clave";
                conn = new MySqlConnection(Cadena);
                conn.Open();

                cmd = new MySqlCommand(Sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);
                cmd.Parameters.AddWithValue("@Clave", Clave);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User = new Usuario();
                    User.Codigo = reader[0].ToString();
                    User.Nombre = reader[1].ToString();
                    User.Puesto = reader[2].ToString();
                    User.Clave = reader[3].ToString();
                    User.Edad = Convert.ToInt32(reader[4]);
                    User.EstaActivo = Convert.ToBoolean(reader[4]);



                }
                reader.Close();
                conn.Close();


            }
            catch (Exception ex)
            {

            }
            return User;




        }


        public DataTable ListarUsuarios()
        {
            DataTable ListaUsuariosDT = new DataTable();

            try
            {
                string sql = "SELECT * FROM Usuarios;";
                conn = new MySqlConnection(Cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                ListaUsuariosDT.Load(reader);
                reader.Close();
                conn.Close();


            }
            catch (Exception XD)
            {

            }
            return ListaUsuariosDT;

        }


        public bool InsertarUsuario(Usuario usuario)
        {
            bool Inserto = false;

            try
            {
                String Sql = "INSERT INTO Usuarios VALUES (@Codigo, @Nombre, @Puesto, @Clave, @Edad, @EstaActivo);";

                conn = new MySqlConnection(Cadena);
                conn.Open();

                cmd = new MySqlCommand(Sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", usuario.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Puesto", usuario.Puesto);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                cmd.Parameters.AddWithValue("@EstaActivo", usuario.EstaActivo);

                cmd.ExecuteNonQuery();
                Inserto = true;
               
                conn.Close();



            }
            catch (Exception XD)
            {

                
            }

            return Inserto;

        }

        public bool ModificarUsuario(Usuario usuario)
        {
            bool Modifico = false;

            try
            {
                String Sql = "UPDATE Usuarios SET Codigo = @Codigo, Nombre = @Nombre, Puesto = @Puesto, Clave = @Clave, Edad = @Edad, EstaActivo = @EstaActivo WHERE Codigo = @Codigo;";

                conn = new MySqlConnection(Cadena);
                conn.Open();

                cmd = new MySqlCommand(Sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", usuario.Codigo);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Puesto", usuario.Puesto);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                cmd.Parameters.AddWithValue("@EstaActivo", usuario.EstaActivo);

                cmd.ExecuteNonQuery();
                Modifico = true;
            



            }
            catch (Exception XD)
            {


            }

            return Modifico;


        }

        public bool EliminarUsuario( String Codigo)
        {
            bool Elimino = false;

            try
            {
                String Sql = "DELETE FROM Usuarios  WHERE Codigo = @Codigo;";

                conn = new MySqlConnection(Cadena);
                conn.Open();

                cmd = new MySqlCommand(Sql, conn);
                cmd.Parameters.AddWithValue("@Codigo", Codigo);

                cmd.ExecuteNonQuery();
                Elimino = true;
                conn.Close();



            }
            catch (Exception XD)
            {


            }

            return Elimino;




        }

    }
}
