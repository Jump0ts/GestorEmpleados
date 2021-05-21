using GestorEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Interfaces
{
    interface IControladorVAnadir
    {

        List<Lenguaje> getLenguajes();

        int getIdLenguaje(String nombre);

        void anadirDesarrollador(Desarrollador dev);

        void anadirRecursoHumano(RecursosHumanos rh);

        void anadirServicioLimpieza(ServiciosLimpieza limpieza);


    }
}
