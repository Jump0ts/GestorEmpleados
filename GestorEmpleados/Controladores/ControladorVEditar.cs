using GestorEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleados.Controladores
{
    class ControladorVEditar
    {
        private static ControladorVEditar _control = null;
        private Desarrollador dev = null;
        private ServiciosLimpieza cleaner = null;
        private RecursosHumanos rh = null;
        private gestorempleadosContext db = new gestorempleadosContext();

        private ControladorVEditar() { }
        
        public void editedDev(Desarrollador editado)
        {
            db.Entry(editado);
            db.SaveChanges();
        }

        public static ControladorVEditar control
        {
            get
            {
                if (_control == null)
                {
                    _control = new ControladorVEditar();
                }
                return _control;
            }
        }
        public Desarrollador desarrollador
        {
            get
            {
                return dev;
            }
            set
            {
                dev = value;
                rh = null;
                cleaner = null;
            }
        }
        public ServiciosLimpieza limpieza
        {
            get
            {
                return cleaner;
            }
            set
            {
                cleaner = value;
                rh = null;
                dev = null;
            }
        }
        public RecursosHumanos recurso_humano
        {
            get
            { 
                return rh;
            }
            set
            {
                rh = value;
                cleaner = null;
                dev = null;
            }
        }
        public List<Departamento> getDepartamentos()
        {
            return db.Departamento.ToList();   
        }

        public List<Lenguaje> getLenguajes()
        {
            return db.Lenguaje.ToList();
        }
    }
}
