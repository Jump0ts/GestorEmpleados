using System;
using System.Collections.Generic;

namespace GestorEmpleados.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Desarrollador = new HashSet<Desarrollador>();
            RecursosHumanos = new HashSet<RecursosHumanos>();
            ServiciosLimpieza = new HashSet<ServiciosLimpieza>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Desarrollador> Desarrollador { get; set; }
        public ICollection<RecursosHumanos> RecursosHumanos { get; set; }
        public ICollection<ServiciosLimpieza> ServiciosLimpieza { get; set; }
    }
}
