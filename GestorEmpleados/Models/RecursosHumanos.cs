using System;
using System.Collections.Generic;

namespace GestorEmpleados.Models
{
    public partial class RecursosHumanos: Persona
    {
        /*public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Direccion { get; set; }
        public string Dni { get; set; }
        public int Departamento { get; set; }
        public double HorasSemanales { get; set; }
        public double PrecioHora { get; set; }
        public double PrecioHorasExtras { get; set; }*/
        public string Funciones { get; set; }

        //public Departamento DepartamentoNavigation { get; set; }
    }
}
