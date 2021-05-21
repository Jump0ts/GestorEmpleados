using System;
using System.Collections.Generic;

namespace GestorEmpleados.Models
{
    public partial class Desarrollador : Persona
    {
        
        public int Lenguaje { get; set; }

        
        public Lenguaje LenguajeNavigation { get; set; }
    }
}
