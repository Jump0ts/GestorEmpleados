using GestorEmpleados.Controladores;
using GestorEmpleados.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestorEmpleados.Vistas
{
    /// <summary>
    /// Lógica de interacción para VEditarEmpleado.xaml
    /// </summary>
    public partial class VEditarEmpleado : Page
    {
        private String tipo = "";
        private ArrayList lenguajes = new ArrayList();
        private readonly Regex _regex = new Regex("[^0-9.-]+");

        public VEditarEmpleado()
        {
            InitializeComponent();
            getLenguajes();
            
            inicializarComponentes();

        }

        private void inicializarComponentes()
        {
            if (ControladorVEditar.control.desarrollador != null)
            {
                rellenaCombo();
                rellenaDev();
                

            }
            else
            {
                if (ControladorVEditar.control.recurso_humano != null)
                {
                    rellenaRecursoHumano();
                    
                }
                else
                {
                    rellenaCleaner();
                }
                comboLenguaje.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void getLenguajes()
        {
            List<Lenguaje> lista = ControladorVEditar.control.getLenguajes();

            foreach (Lenguaje dep in lista)
            {
                lenguajes.Add(dep);
            }
        }

        private void rellenaCombo()
        {
            ArrayList nombres = new ArrayList();

            foreach(Lenguaje dep in lenguajes)
            {
                nombres.Add(dep.Nombre);
            }

            comboLenguaje.ItemsSource = nombres;
        }

        private void rellenaDev()
        {
            tipo = "desarrollador";

            txtNombre.Text = ControladorVEditar.control.desarrollador.Nombre;
            txtApe1.Text = ControladorVEditar.control.desarrollador.Apellido1;
            txtApe2.Text = ControladorVEditar.control.desarrollador.Apellido2;
            txtDir.Text = ControladorVEditar.control.desarrollador.Direccion;
            txtDni.Text = ControladorVEditar.control.desarrollador.Dni;
            txtPrecioHora.Text = ControladorVEditar.control.desarrollador.PrecioHora + "";
            txtHorasSemanales.Text = ControladorVEditar.control.desarrollador.HorasSemanales + "";
            txtPrecioHoraExtra.Text = ControladorVEditar.control.desarrollador.PrecioHorasExtras + "";
            lblVariable.Content = "Lenguaje:";
            comboLenguaje.SelectedItem = ControladorVEditar.control.getNombreLenguaje(ControladorVEditar.control.desarrollador.Lenguaje);
            txtVariable.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void rellenaRecursoHumano()
        {
            tipo = "recurso humano";

            txtNombre.Text = ControladorVEditar.control.recurso_humano.Nombre;
            txtApe1.Text = ControladorVEditar.control.recurso_humano.Apellido1;
            txtApe2.Text = ControladorVEditar.control.recurso_humano.Apellido2;
            txtDir.Text = ControladorVEditar.control.recurso_humano.Direccion;
            txtDni.Text = ControladorVEditar.control.recurso_humano.Dni;
            txtPrecioHora.Text = ControladorVEditar.control.recurso_humano.PrecioHora + "";
            txtHorasSemanales.Text = ControladorVEditar.control.recurso_humano.HorasSemanales + "";
            txtPrecioHoraExtra.Text = ControladorVEditar.control.recurso_humano.PrecioHorasExtras + "";
            lblVariable.Content = "Funciones:";
            txtVariable.Text = ControladorVEditar.control.recurso_humano.Funciones;
        }

        private void rellenaCleaner()
        {
            tipo = "limpiador";

            txtNombre.Text = ControladorVEditar.control.limpieza.Nombre;
            txtApe1.Text = ControladorVEditar.control.limpieza.Apellido1;
            txtApe2.Text = ControladorVEditar.control.limpieza.Apellido2;
            txtDir.Text = ControladorVEditar.control.limpieza.Direccion;
            txtDni.Text = ControladorVEditar.control.limpieza.Dni;
            txtPrecioHora.Text = ControladorVEditar.control.limpieza.PrecioHora + "";
            txtHorasSemanales.Text = ControladorVEditar.control.limpieza.HorasSemanales + "";
            txtPrecioHoraExtra.Text = ControladorVEditar.control.limpieza.PrecioHorasExtras + "";
            lblVariable.Content = "Area de limpieza:";
            txtVariable.Text = ControladorVEditar.control.limpieza.AreaLimpieza;
        }

        private bool esTextoValido(String cadena)
        {
            return _regex.IsMatch(cadena);
        }

        private bool hayVacio()
        {
            bool vacio = true;
            if(txtNombre.Text != "" && txtApe1.Text!="" && txtApe2.Text!="" && txtDir.Text !="" && txtDni.Text!="" && txtHorasSemanales.Text!="" && txtPrecioHora.Text!="" && txtPrecioHoraExtra.Text!="")
            {
                if (tipo == "desarrollador") vacio = false;
                else
                {
                    if (txtVariable.Text != "") vacio = false;
                }
            }
            return vacio;
        }

        private void sustituyeCambiosDesarrollador()
        {
            ControladorVEditar.control.desarrollador.Nombre = txtNombre.Text;
            ControladorVEditar.control.desarrollador.Apellido1 = txtApe1.Text;
            ControladorVEditar.control.desarrollador.Apellido2 = txtApe2.Text;
            ControladorVEditar.control.desarrollador.Direccion = txtDir.Text;
            ControladorVEditar.control.desarrollador.Dni = txtDni.Text;
            ControladorVEditar.control.desarrollador.HorasSemanales = Double.Parse(txtHorasSemanales.Text);
            ControladorVEditar.control.desarrollador.PrecioHora = Double.Parse(txtPrecioHora.Text);
            ControladorVEditar.control.desarrollador.PrecioHorasExtras = Double.Parse(txtPrecioHoraExtra.Text);
            ControladorVEditar.control.desarrollador.Lenguaje = ControladorVEditar.control.getIdLenguaje(comboLenguaje.SelectedItem.ToString());

            ControladorVEditar.control.desarrolladorEditado();
        }

        private void sustituyeCambiosLimpieza()
        {
            ControladorVEditar.control.limpieza.Nombre = txtNombre.Text;
            ControladorVEditar.control.limpieza.Apellido1 = txtApe1.Text;
            ControladorVEditar.control.limpieza.Apellido2 = txtApe2.Text;
            ControladorVEditar.control.limpieza.Direccion = txtDir.Text;
            ControladorVEditar.control.limpieza.Dni = txtDni.Text;
            ControladorVEditar.control.limpieza.HorasSemanales = Double.Parse(txtHorasSemanales.Text);
            ControladorVEditar.control.limpieza.PrecioHora = Double.Parse(txtPrecioHora.Text);
            ControladorVEditar.control.limpieza.PrecioHorasExtras = Double.Parse(txtPrecioHoraExtra.Text);
            ControladorVEditar.control.limpieza.AreaLimpieza = txtVariable.Text;

            ControladorVEditar.control.limpiezaEditado();
        }

        private void sustituyeCambiosRecursosHumanos()
        {
            ControladorVEditar.control.recurso_humano.Nombre = txtNombre.Text;
            ControladorVEditar.control.recurso_humano.Apellido1 = txtApe1.Text;
            ControladorVEditar.control.recurso_humano.Apellido2 = txtApe2.Text;
            ControladorVEditar.control.recurso_humano.Direccion = txtDir.Text;
            ControladorVEditar.control.recurso_humano.Dni = txtDni.Text;
            ControladorVEditar.control.recurso_humano.HorasSemanales = Double.Parse(txtHorasSemanales.Text);
            ControladorVEditar.control.recurso_humano.PrecioHora = Double.Parse(txtPrecioHora.Text);
            ControladorVEditar.control.recurso_humano.PrecioHorasExtras = Double.Parse(txtPrecioHoraExtra.Text);
            ControladorVEditar.control.recurso_humano.Funciones = txtVariable.Text;
            
            ControladorVEditar.control.recursosHumanosEditado();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (hayVacio() == true)
            {
                System.Windows.MessageBox.Show("Debe rellenar todos los campos y no dejar ninguno vacío.", "ERROR", MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("¿Desea confirmar los cambios?", "Confirmación", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    if (tipo == "desarrollador")sustituyeCambiosDesarrollador();
                    else
                    {
                        if (tipo == "recurso humano") sustituyeCambiosRecursosHumanos();
                        else sustituyeCambiosLimpieza();
                    }

                    Uri uri = new Uri("Vistas/VMenuBuscar.xaml", UriKind.Relative);
                    NavigationService.Navigate(uri);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("¿Está seguro de que desea cancelar la edición del "+tipo+"?", "Confirmación", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Uri uri = new Uri("Vistas/VMenuBuscar.xaml", UriKind.Relative);
                NavigationService.Navigate(uri);
            } 
        }

        private void soloNumeros(object sender, TextCompositionEventArgs e)
        {
            e.Handled = esTextoValido(e.Text);
        }

        private void controlPegar(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!esTextoValido(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("¿Desea confirmar la eliminación de este empleado?", "Confirmación", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                if (tipo == "desarrollador") ControladorVEditar.control.eliminarDesarrollador();
                else
                {
                    if (tipo == "recurso humano") ControladorVEditar.control.eliminarRecursoHumano();
                    else ControladorVEditar.control.eliminarServicioLimpieza();
                }

                Uri uri = new Uri("Vistas/VMenuBuscar.xaml", UriKind.Relative);
                NavigationService.Navigate(uri);
            }
        }
    }
}
