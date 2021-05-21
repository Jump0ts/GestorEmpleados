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
using GestorEmpleados.Controladores;

namespace GestorEmpleados.Vistas
{
    /// <summary>
    /// Lógica de interacción para VAnadirEmpleado.xaml
    /// </summary>
    public partial class VAnadirEmpleado : Page
    {

        private readonly Regex _regex = new Regex("[^0-9.-]+");
        private ArrayList lenguajes = new ArrayList();
        private String tipo = "";

        public VAnadirEmpleado()
        {
            InitializeComponent();
            rellenaComboLenguaje();
            iniciaComboTipo();

            tipo = "Servicio de limpieza";
            lblVariable.Content = "Area de limpieza:";
            comboLenguaje.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void iniciaComboTipo()
        {
            ArrayList lista = new ArrayList();
            lista.Add("Desarrollador");
            lista.Add("Recursos Humanos");
            lista.Add("Servicio de limpieza");

            comboTipo.ItemsSource = lista;
            comboTipo.SelectedIndex = 2;
        }

        private bool esTextoValido(String cadena)
        {
            return _regex.IsMatch(cadena);
        }

        private void anadirDesarrollador()
        {
            Desarrollador dev = new Desarrollador();

            dev.Nombre = txtNombre.Text;
            dev.Apellido1 = txtApe1.Text;
            dev.Apellido2 = txtApe2.Text;
            dev.Direccion = txtDir.Text;
            dev.Dni = txtDni.Text;
            dev.HorasSemanales = Double.Parse(txtHorasSemanales.Text);
            dev.PrecioHora = Double.Parse(txtPrecioHora.Text);
            dev.PrecioHorasExtras = Double.Parse(txtPrecioHoraExtra.Text);
            dev.Lenguaje = ControladorVAnadir.control.getIdLenguaje(comboLenguaje.SelectedItem.ToString());


            ControladorVAnadir.control.anadirDesarrollador(dev);
        }

        private void anadirServicioLimpieza()
        {
            ServiciosLimpieza limpieza = new ServiciosLimpieza();

            limpieza.Nombre = txtNombre.Text;
            limpieza.Apellido1 = txtApe1.Text;
            limpieza.Apellido2 = txtApe2.Text;
            limpieza.Direccion = txtDir.Text;
            limpieza.Dni = txtDni.Text;
            limpieza.HorasSemanales = Double.Parse(txtHorasSemanales.Text);
            limpieza.PrecioHora = Double.Parse(txtPrecioHora.Text);
            limpieza.PrecioHorasExtras = Double.Parse(txtPrecioHoraExtra.Text);
            limpieza.AreaLimpieza = txtVariable.Text;


            ControladorVAnadir.control.anadirServicioLimpieza(limpieza);
        }

        private void anadirRecursoHumano()
        {
            RecursosHumanos rh = new RecursosHumanos();

            rh.Nombre = txtNombre.Text;
            rh.Apellido1 = txtApe1.Text;
            rh.Apellido2 = txtApe2.Text;
            rh.Direccion = txtDir.Text;
            rh.Dni = txtDni.Text;
            rh.HorasSemanales = Double.Parse(txtHorasSemanales.Text.Replace(".",","));
            rh.PrecioHora = Double.Parse(txtPrecioHora.Text);
            rh.PrecioHorasExtras = Double.Parse(txtPrecioHoraExtra.Text);
            rh.Funciones = txtVariable.Text;


            ControladorVAnadir.control.anadirRecursoHumano(rh);
        }

        private bool hayVacio()
        {
            bool vacio = false;
            if (txtNombre.Text == "" && txtApe1.Text == "" && txtApe2.Text == "" && txtDir.Text == "" && txtDni.Text == "" && txtHorasSemanales.Text == "" && txtPrecioHora.Text == "" && txtPrecioHoraExtra.Text == "")
            {
                if (tipo == "Desarrollador") vacio = true;
                else
                {
                    if (txtVariable.Text == "") vacio = true;
                }
            }
            return vacio;
        }

        private void rellenaComboLenguaje()
        {
            ArrayList nombres = new ArrayList();

            foreach (Lenguaje dep in ControladorVAnadir.control.getLenguajes())
            {
                nombres.Add(dep.Nombre);
            }

            comboLenguaje.ItemsSource = nombres;
            comboLenguaje.SelectedIndex = 0;
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

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (hayVacio() == true)
            {
                System.Windows.MessageBox.Show("Debe rellenar todos los campos y no dejar ninguno vacío.", "ERROR", MessageBoxButton.OK);
            }
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("¿Está seguro de añadir el empleado?", "Confirmación", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    if (tipo == "Desarrollador") anadirDesarrollador();
                    else
                    {
                        if (tipo == "Recursos Humanos") anadirRecursoHumano(); 
                        else anadirServicioLimpieza();
                    }

                    Uri uri = new Uri("Vistas/VMenuBuscar.xaml", UriKind.Relative);
                    NavigationService.Navigate(uri);
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("¿Está seguro de que desea salir de la pantalla de añadir empleado?", "Confirmación", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Uri uri = new Uri("Vistas/VMenuBuscar.xaml", UriKind.Relative);
                NavigationService.Navigate(uri);
            }
        }

        private void comboTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl.Content = comboTipo.SelectedItem.ToString();
            if (comboTipo.SelectedItem.ToString() == "Desarrollador")
            {
                tipo = "Desarrollador";
                lblVariable.Content = "Lenguajes:";
                comboLenguaje.Visibility = System.Windows.Visibility.Visible;
                txtVariable.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                if(comboTipo.SelectedItem.ToString() == "Recursos Humanos")
                {
                    tipo = "Recursos Humanos";
                    lblVariable.Content = "Funciones:";
                }
                else
                {
                    tipo = "Servicio de limpieza";
                    lblVariable.Content = "Area de limpieza:";
                }
                comboLenguaje.Visibility = System.Windows.Visibility.Collapsed;
                txtVariable.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
