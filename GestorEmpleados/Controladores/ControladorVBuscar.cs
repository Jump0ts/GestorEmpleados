using GestorEmpleados.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorEmpleados.Interfaces;

namespace GestorEmpleados.Controladores
{
    public class ControladorVBuscar : IControladorVBuscar
    {
        private gestorempleadosContext db = new gestorempleadosContext();
        private static ControladorVBuscar _control = null;

        private ControladorVBuscar()
        {
        }

        public ArrayList getDesarrolladores()
        {
            ArrayList lista = new ArrayList();

            foreach (Desarrollador dev in db.Desarrollador.ToList())
            {
                lista.Add(dev);

            }

            return lista;
        }

        public ArrayList getCleaners()
        {
            ArrayList lista = new ArrayList();

            foreach (ServiciosLimpieza cleaner in db.ServiciosLimpieza.ToList())
            {
                lista.Add(cleaner);

            }

            return lista;
        }

        public ArrayList getRRHH()
        {
            ArrayList lista = new ArrayList();

            foreach (RecursosHumanos rh in db.RecursosHumanos.ToList())
            {
                lista.Add(rh);

            }

            return lista;
        }

        public static ControladorVBuscar control
        {
            get
            {
                if (_control == null)
                {
                    _control = new ControladorVBuscar();
                }
                return _control;
            }
        }
    }
}
