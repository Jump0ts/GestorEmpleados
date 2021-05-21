using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using GestorEmpleados.Models;

namespace GestorEmpleados.Vistas
{
    /// <summary>
    /// Lógica de interacción para VMenuBuscar.xaml
    /// </summary>
    public partial class VMenuBuscar : Page
    {
        
        public VMenuBuscar()
        {
            InitializeComponent();

            gridEmpleados.ItemsSource = ControladorVBuscar.control.getDesarrolladores();
        }

        

        private void gridEmpleados_Loaded(object sender, RoutedEventArgs e)
        {

            if (gridEmpleados.Columns.Count > 1)
            {
                gridEmpleados.Columns.RemoveAt(0);
                gridEmpleados.Columns.RemoveAt(0);
                gridEmpleados.Columns.RemoveAt(0);
            }
        }

        private void actualizaLista(ArrayList lista)
        {
            if (gridEmpleados != null)
            {
                gridEmpleados.ItemsSource = lista;

                if (gridEmpleados.Items.Count > 1)
                {
                    if (rdBDev.IsChecked == true) gridEmpleados.Columns.RemoveAt(0);
                    gridEmpleados.Columns.RemoveAt(0);
                    gridEmpleados.Columns.RemoveAt(0);
                }
            }
        }

        private void rdBDev_Checked(object sender, RoutedEventArgs e)
        {
            actualizaLista(ControladorVBuscar.control.getDesarrolladores());
        }

        private void rdBCleaner_Checked(object sender, RoutedEventArgs e)
        {
            actualizaLista(ControladorVBuscar.control.getCleaners());
        }

        private void rdBRH_Checked(object sender, RoutedEventArgs e)
        {
            actualizaLista(ControladorVBuscar.control.getRRHH());
        }

        private void btnAnadirEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Vistas/VAnadirEmpleado.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }

        private void gridEmpleados_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (gridEmpleados.SelectedIndex != -1)
            {
                if (rdBDev.IsChecked == true) ControladorVEditar.control.desarrollador = (Desarrollador)gridEmpleados.SelectedItem;
                else
                {
                    if (rdBRH.IsChecked == true) ControladorVEditar.control.recurso_humano = (RecursosHumanos)gridEmpleados.SelectedItem;
                    else
                    {
                        ControladorVEditar.control.limpieza = (ServiciosLimpieza)gridEmpleados.SelectedItem;
                    }
                }
                Uri uri = new Uri("Vistas/VEditarEmpleado.xaml", UriKind.Relative);
                NavigationService.Navigate(uri);
            }
            
            

        }
    }
}
