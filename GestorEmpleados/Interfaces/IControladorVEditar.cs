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

        public void eliminarDesarrollador();

        public void eliminarRecursoHumano();

        public void eliminarServicioLimpieza();
    }
}
