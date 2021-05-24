using GestorEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Interfaces
{
    interface IControladorVEditar_Crear
    {
        void desarrolladorEditado(Boolean editado);

        void limpiezaEditado(Boolean editado);

        void recursosHumanosEditado(Boolean editado);

        void eliminarDesarrollador();

        void eliminarRecursoHumano();

        void eliminarServicioLimpieza();

        List<Lenguaje> getLenguajes();

        int getIdLenguaje(String nombre);

        String getNombreLenguaje(int id);

        Boolean editing();
    }
}
