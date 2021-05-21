﻿using System;
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

namespace GestorEmpleados.Vistas
{
    /// <summary>
    /// Lógica de interacción para VAnadirEmpleado.xaml
    /// </summary>
    public partial class VAnadirEmpleado : Page
    {
        public VAnadirEmpleado()
        {
            InitializeComponent();
        }

        private void btnBuscarEmpleado_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Vista/VBuscarEmpleado.xaml", UriKind.Relative);
            NavigationService.Navigate(uri);
        }
    }
}
