using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorEmpleados.Interfaces;
using GestorEmpleados.Models;

namespace GestorEmpleados.Controladores
{
    class ControladorVAnadir : IControladorVAnadir
    {
        private static ControladorVAnadir _control = null;
        private gestorempleadosContext bd = new gestorempleadosContext();

        private ControladorVAnadir() { }

        public static ControladorVAnadir control
        {
            get
            {
                if (_control == null)
                {
                    _control = new ControladorVAnadir();
                }
                return _control;
            }
        }

        public int getIdLenguaje(String nombre)
        {
            int id = -5;
            foreach (Lenguaje lenguaje in bd.Lenguaje)
            {
                if (lenguaje.Nombre == nombre) id = lenguaje.Id;
            }
            return id;
        }

        public List<Lenguaje> getLenguajes()
        {
            return bd.Lenguaje.ToList();
        }

        public void anadirDesarrollador(Desarrollador dev)
        {
            bd.Desarrollador.Add(dev);
            bd.SaveChanges();
        }

        public void anadirRecursoHumano(RecursosHumanos rh)
        {
            bd.RecursosHumanos.Add(rh);
            bd.SaveChanges();
        }

        public void anadirServicioLimpieza(ServiciosLimpieza limpieza)
        {
            bd.ServiciosLimpieza.Add(limpieza);
            bd.SaveChanges();
        }
    }
}
