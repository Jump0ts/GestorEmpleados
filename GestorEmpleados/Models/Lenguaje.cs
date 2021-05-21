using System;
using System.Collections.Generic;

namespace GestorEmpleados.Models
{
    public partial class Lenguaje
    {
        public Lenguaje()
        {
            Desarrollador = new HashSet<Desarrollador>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Desarrollador> Desarrollador { get; set; }
    }
}
