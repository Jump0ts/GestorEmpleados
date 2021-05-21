using GestorEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorEmpleados.Interfaces;

namespace GestorEmpleados.Controladores
{
    class ControladorVEditar : IControladorVEditar
    {
        private static ControladorVEditar _control = null;
        private Desarrollador dev = null;
        private ServiciosLimpieza cleaner = null;
        private RecursosHumanos rh = null;
        private gestorempleadosContext bd = new gestorempleadosContext();

        private ControladorVEditar() { }
        
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

        public void desarrolladorEditado()
        {
            bd.Entry(dev).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            bd.SaveChanges();
        }

        public void limpiezaEditado()
        {
            bd.Entry(cleaner).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            bd.SaveChanges();
        }

        public void recursosHumanosEditado()
        {
            bd.Entry(rh).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            bd.SaveChanges();
        }

        public void eliminarDesarrollador()
        {
            bd.Remove(dev).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            bd.SaveChanges();
        }

        public void eliminarRecursoHumano()
        {
            bd.Remove(rh).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            bd.SaveChanges();
        }

        public void eliminarServicioLimpieza()
        {
            bd.Remove(limpieza).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            bd.SaveChanges();
        }

        public List<Lenguaje> getLenguajes()
        {
            return bd.Lenguaje.ToList();
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

        public String getNombreLenguaje(int id)
        {
            String nombre = "";
            foreach (Lenguaje dep in bd.Lenguaje)
            {
                if (dep.Id == id) nombre = dep.Nombre;
            }
            return nombre;
        }
    }
}
