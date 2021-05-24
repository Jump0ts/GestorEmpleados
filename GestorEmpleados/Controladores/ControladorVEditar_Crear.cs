using GestorEmpleados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorEmpleados.Interfaces;

namespace GestorEmpleados.Controladores
{
    class ControladorVEditar_Crear : IControladorVEditar_Crear
    {
        private static ControladorVEditar_Crear _control = null;
        private Desarrollador dev = null;
        private ServiciosLimpieza cleaner = null;
        private RecursosHumanos rh = null;
        private gestorempleadosContext bd = new gestorempleadosContext();

        private ControladorVEditar_Crear() { }
        
        public static ControladorVEditar_Crear control
        {
            get
            {
                if (_control == null)
                {
                    _control = new ControladorVEditar_Crear();
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

        public void desarrolladorEditado(Boolean editado)
        {
            if(editado == true)bd.Entry(dev).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            else bd.Desarrollador.Add(dev);

            bd.SaveChanges();
            resetEmpleado();
        }

        public void limpiezaEditado(Boolean editado)
        {
            if(editado == true)bd.Entry(cleaner).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            else bd.ServiciosLimpieza.Add(cleaner);

            bd.SaveChanges();
            resetEmpleado();
        }

        public void recursosHumanosEditado(Boolean editado)
        {
            if (editado == true) bd.Entry(rh).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            else bd.RecursosHumanos.Add(rh);

            bd.SaveChanges();
            resetEmpleado();
        }

        public Boolean editing()
        {
            Boolean editando = true;
            if(dev == null && rh == null && cleaner == null)
            {
                editando = false;
            }
            return editando;
        }

        public void eliminarDesarrollador()
        {
            bd.Remove(dev).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            bd.SaveChanges();
            resetEmpleado();
        }

        public int eliminarDesarrollador(int a)
        {
            bd.Remove(dev).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            a = bd.SaveChanges();
            resetEmpleado();
            return a;
        }

        public void eliminarRecursoHumano()
        {
            bd.Remove(rh).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            bd.SaveChanges();
            resetEmpleado();
        }

        public void eliminarServicioLimpieza()
        {
            bd.Remove(limpieza).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            bd.SaveChanges();
            resetEmpleado();
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

        private void resetEmpleado()
        {
            dev = null;
            rh = null;
            cleaner = null;
        }
    }
}
