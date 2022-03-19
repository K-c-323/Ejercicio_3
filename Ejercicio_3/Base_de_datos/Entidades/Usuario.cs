using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_de_datos.Entidades
{
    public class Usuario
    {
        public String Codigo { get; set; }
        public String Nombre { get; set; }
        public String Puesto { get; set; }
        public String Clave { get; set; }
        public int Edad { get; set; }
        public bool EstaActivo { get; set; }

        public Usuario()
        {
        }

        public Usuario(string codigo, string nombre, string puesto, string Clave, int edad, bool estaActivo)
        {
            Codigo = codigo;
            Nombre = nombre;
            Puesto = puesto;
            this.Clave = Clave;
            Edad = edad;
            EstaActivo = estaActivo;
        }
    }
}
