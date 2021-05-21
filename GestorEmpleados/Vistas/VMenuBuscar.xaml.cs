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
using GestorEmpleados.Models;

namespace GestorEmpleados.Vista
{
    /// <summary>
    /// Lógica de interacción para VMenuBuscar.xaml
    /// </summary>
    public partial class VMenuBuscar : Page
    {
        
        public VMenuBuscar()
        {
            InitializeComponent();
            
           
            var db = new gestorempleadosContext();
            ArrayList lista = new ArrayList();
            foreach (Desarrollador dev in db.Desarrollador.ToList())
            {
                lista.Add(dev); 
                
            }

            gridEmpleados.ItemsSource = lista;
            Console.WriteLine( gridEmpleados.Columns.Count());
            lbl.Content = gridEmpleados.Columns.Count();
            
            

        }

        private void btnAnadirEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Vista/VAnadirEmpleado.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbl.Content = gridEmpleados.Columns.Count();
        }

        private void gridEmpleados_Loaded(object sender, RoutedEventArgs e)
        {
            gridEmpleados.Columns.RemoveAt(1);
            gridEmpleados.Columns.RemoveAt(1);
            gridEmpleados.Columns.RemoveAt(1);
        }
    }
}
