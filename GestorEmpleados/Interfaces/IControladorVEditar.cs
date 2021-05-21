using GestorEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Interfaces
{
    interface IControladorVEditar
    {
        void desarrolladorEditado();

        void limpiezaEditado();

        void recursosHumanosEditado();

        void eliminarDesarrollador();

        void eliminarRecursoHumano();

        void eliminarServicioLimpieza();

        List<Lenguaje> getLenguajes();

        int getIdLenguaje(String nombre);

        String getNombreLenguaje(int id);
    }
}
