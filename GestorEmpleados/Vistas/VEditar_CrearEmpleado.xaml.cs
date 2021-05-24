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
    /// Lógica de interacción para VEditar_CrearEmpleado.xaml
    /// </summary>
    public partial class VEditar_CrearEmpleado : Page
    {
        private String tipoEmpleado = "";
        private ArrayList lenguajes = new ArrayList();
        private readonly Regex _regex = new Regex("[^0-9.-]+");
        private Boolean editando = false;
        private double imgFlag = 2;

        public VEditar_CrearEmpleado()
        {
            InitializeComponent();
            getLenguajes();
            editando = ControladorVEditar_Crear.control.editing();
            
            rellenaComboTipo();
            rellenaComboLeng();
            vaciaTxtBox();
            if (editando == true)
            {
                inicializarComponentes();
            }
            else
            {
                Uri fileUri = new Uri("https://picsum.photos/200/300?random=1");
                imgPerfil.Source = new BitmapImage(fileUri);
            }
            

            comboTipo.IsEnabled = !editando;
            btnEliminar.IsEnabled = editando;

        }

        private void vaciaTxtBox()
        {
            txtNombre.Text = "";
            txtApe1.Text = "";
            txtApe2.Text = "";
            txtDir.Text = "";
            txtDni.Text = "";
            txtPrecioHora.Text = "";
            txtHorasSemanales.Text = "";
            txtPrecioHoraExtra.Text = "";
            txtVariable.Text = "";
        }

        private void inicializarComponentes()
        {
            if (ControladorVEditar_Crear.control.desarrollador != null)
            {
                rellenaDev();
                

            }
            else
            {
                if (ControladorVEditar_Crear.control.recurso_humano != null)
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
            
            List<Lenguaje> lista = ControladorVEditar_Crear.control.getLenguajes();

            foreach (Lenguaje dep in lista)
            {
                lenguajes.Add(dep);
            }
        }

        private void rellenaComboTipo()
        {
            ArrayList lista = new ArrayList();
            lista.Add("Desarrollador");
            lista.Add("Recursos Humanos");
            lista.Add("Servicio de limpieza");

            comboTipo.ItemsSource = lista;
            comboTipo.SelectedIndex = 2;
        }

        private void rellenaComboLeng()
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
            tipoEmpleado = "Desarrollador";

            txtNombre.Text = ControladorVEditar_Crear.control.desarrollador.Nombre;
            txtApe1.Text = ControladorVEditar_Crear.control.desarrollador.Apellido1;
            txtApe2.Text = ControladorVEditar_Crear.control.desarrollador.Apellido2;
            txtDir.Text = ControladorVEditar_Crear.control.desarrollador.Direccion;
            txtDni.Text = ControladorVEditar_Crear.control.desarrollador.Dni;
            txtPrecioHora.Text = ControladorVEditar_Crear.control.desarrollador.PrecioHora + "";
            txtHorasSemanales.Text = ControladorVEditar_Crear.control.desarrollador.HorasSemanales + "";
            txtPrecioHoraExtra.Text = ControladorVEditar_Crear.control.desarrollador.PrecioHorasExtras + "";
            lblVariable.Content = "Lenguaje:";
            comboLenguaje.SelectedItem = ControladorVEditar_Crear.control.getNombreLenguaje(ControladorVEditar_Crear.control.desarrollador.Lenguaje);
            txtVariable.Visibility = System.Windows.Visibility.Collapsed;
            imgPerfil.Source = new BitmapImage(new Uri(ControladorVEditar_Crear.control.desarrollador.Imagen));
        }

        private void rellenaRecursoHumano()
        {
            tipoEmpleado = "recurso humano";

            txtNombre.Text = ControladorVEditar_Crear.control.recurso_humano.Nombre;
            txtApe1.Text = ControladorVEditar_Crear.control.recurso_humano.Apellido1;
            txtApe2.Text = ControladorVEditar_Crear.control.recurso_humano.Apellido2;
            txtDir.Text = ControladorVEditar_Crear.control.recurso_humano.Direccion;
            txtDni.Text = ControladorVEditar_Crear.control.recurso_humano.Dni;
            txtPrecioHora.Text = ControladorVEditar_Crear.control.recurso_humano.PrecioHora + "";
            txtHorasSemanales.Text = ControladorVEditar_Crear.control.recurso_humano.HorasSemanales + "";
            txtPrecioHoraExtra.Text = ControladorVEditar_Crear.control.recurso_humano.PrecioHorasExtras + "";
            lblVariable.Content = "Funciones:";
            txtVariable.Text = ControladorVEditar_Crear.control.recurso_humano.Funciones;
            imgPerfil.Source = new BitmapImage(new Uri(ControladorVEditar_Crear.control.recurso_humano.Imagen));
        }

        private void rellenaCleaner()
        {
            tipoEmpleado = "limpiador";

            txtNombre.Text = ControladorVEditar_Crear.control.limpieza.Nombre;
            txtApe1.Text = ControladorVEditar_Crear.control.limpieza.Apellido1;
            txtApe2.Text = ControladorVEditar_Crear.control.limpieza.Apellido2;
            txtDir.Text = ControladorVEditar_Crear.control.limpieza.Direccion;
            txtDni.Text = ControladorVEditar_Crear.control.limpieza.Dni;
            txtPrecioHora.Text = ControladorVEditar_Crear.control.limpieza.PrecioHora + "";
            txtHorasSemanales.Text = ControladorVEditar_Crear.control.limpieza.HorasSemanales + "";
            txtPrecioHoraExtra.Text = ControladorVEditar_Crear.control.limpieza.PrecioHorasExtras + "";
            lblVariable.Content = "Area de limpieza:";
            txtVariable.Text = ControladorVEditar_Crear.control.limpieza.AreaLimpieza;
            imgPerfil.Source = new BitmapImage(new Uri(ControladorVEditar_Crear.control.limpieza.Imagen));
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
                if (tipoEmpleado == "Desarrollador") vacio = false;
                else
                {
                    if (txtVariable.Text != "") vacio = false;
                }
            }
            return vacio;
        }

        private void sustituyeCambiosDesarrollador()
        {

            if (ControladorVEditar_Crear.control.desarrollador == null) ControladorVEditar_Crear.control.desarrollador = new Desarrollador();

            ControladorVEditar_Crear.control.desarrollador.Nombre = txtNombre.Text;
            ControladorVEditar_Crear.control.desarrollador.Apellido1 = txtApe1.Text;
            ControladorVEditar_Crear.control.desarrollador.Apellido2 = txtApe2.Text;
            ControladorVEditar_Crear.control.desarrollador.Direccion = txtDir.Text;
            ControladorVEditar_Crear.control.desarrollador.Dni = txtDni.Text;
            ControladorVEditar_Crear.control.desarrollador.HorasSemanales = Double.Parse(txtHorasSemanales.Text);
            ControladorVEditar_Crear.control.desarrollador.PrecioHora = Double.Parse(txtPrecioHora.Text);
            ControladorVEditar_Crear.control.desarrollador.PrecioHorasExtras = Double.Parse(txtPrecioHoraExtra.Text);
            ControladorVEditar_Crear.control.desarrollador.Lenguaje = ControladorVEditar_Crear.control.getIdLenguaje(comboLenguaje.SelectedItem.ToString());
            ControladorVEditar_Crear.control.desarrollador.Imagen = imgPerfil.Source.ToString();

            ControladorVEditar_Crear.control.desarrolladorEditado(editando);
        }

        private void sustituyeCambiosLimpieza()
        {

            if (ControladorVEditar_Crear.control.limpieza == null) ControladorVEditar_Crear.control.limpieza = new ServiciosLimpieza();

            ControladorVEditar_Crear.control.limpieza.Nombre = txtNombre.Text;
            ControladorVEditar_Crear.control.limpieza.Apellido1 = txtApe1.Text;
            ControladorVEditar_Crear.control.limpieza.Apellido2 = txtApe2.Text;
            ControladorVEditar_Crear.control.limpieza.Direccion = txtDir.Text;
            ControladorVEditar_Crear.control.limpieza.Dni = txtDni.Text;
            ControladorVEditar_Crear.control.limpieza.HorasSemanales = Double.Parse(txtHorasSemanales.Text);
            ControladorVEditar_Crear.control.limpieza.PrecioHora = Double.Parse(txtPrecioHora.Text);
            ControladorVEditar_Crear.control.limpieza.PrecioHorasExtras = Double.Parse(txtPrecioHoraExtra.Text);
            ControladorVEditar_Crear.control.limpieza.AreaLimpieza = txtVariable.Text;
            ControladorVEditar_Crear.control.limpieza.Imagen = imgPerfil.Source.ToString();

            ControladorVEditar_Crear.control.limpiezaEditado(editando);
        }

        private void sustituyeCambiosRecursosHumanos()
        {
            if (ControladorVEditar_Crear.control.recurso_humano == null) ControladorVEditar_Crear.control.recurso_humano = new RecursosHumanos();

            ControladorVEditar_Crear.control.recurso_humano.Nombre = txtNombre.Text;
            ControladorVEditar_Crear.control.recurso_humano.Apellido1 = txtApe1.Text;
            ControladorVEditar_Crear.control.recurso_humano.Apellido2 = txtApe2.Text;
            ControladorVEditar_Crear.control.recurso_humano.Direccion = txtDir.Text;
            ControladorVEditar_Crear.control.recurso_humano.Dni = txtDni.Text;
            ControladorVEditar_Crear.control.recurso_humano.HorasSemanales = Double.Parse(txtHorasSemanales.Text);
            ControladorVEditar_Crear.control.recurso_humano.PrecioHora = Double.Parse(txtPrecioHora.Text);
            ControladorVEditar_Crear.control.recurso_humano.PrecioHorasExtras = Double.Parse(txtPrecioHoraExtra.Text);
            ControladorVEditar_Crear.control.recurso_humano.Funciones = txtVariable.Text;
            ControladorVEditar_Crear.control.recurso_humano.Imagen = imgPerfil.Source.ToString();

            ControladorVEditar_Crear.control.recursosHumanosEditado(editando);
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            lblTitulo.Content = tipoEmpleado;
            if (hayVacio() == true)
            {
                System.Windows.MessageBox.Show("Debe rellenar todos los campos y no dejar ninguno vacío.", "ERROR", MessageBoxButton.OK);
            }
            else
            {
                if(Double.TryParse(txtHorasSemanales.Text, out double num1)==false || Double.TryParse(txtPrecioHora.Text, out double num2) == false || Double.TryParse(txtPrecioHoraExtra.Text, out double num3) == false)
                {
                    System.Windows.MessageBox.Show("Ha introducido letras en un campo numérico (Horas semanales, precio hora o precio horas extras).", "ERROR", MessageBoxButton.OK);
                }
                else { 
                    MessageBoxResult result = System.Windows.MessageBox.Show("¿Desea confirmar los cambios?", "Confirmación", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        if (tipoEmpleado == "Desarrollador") sustituyeCambiosDesarrollador();
                        else
                        {
                            if (tipoEmpleado == "Recursos Humanos") sustituyeCambiosRecursosHumanos();
                            else sustituyeCambiosLimpieza();
                        }

                        Uri uri = new Uri("Vistas/VMenuBuscar.xaml", UriKind.Relative);
                        NavigationService.Navigate(uri);
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            String cadena = "";
            if(editando == true)
            {
                cadena = "¿Está seguro de que desea cancelar la edición del " + tipoEmpleado + "?";
            }
            else
            {
                cadena = "¿Está seguro de que desea cancelar la creación del empleado?";
            }
            MessageBoxResult result = System.Windows.MessageBox.Show(cadena, "Confirmación", MessageBoxButton.YesNo);

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
                if (tipoEmpleado == "Desarrollador") System.Windows.MessageBox.Show(""+ControladorVEditar_Crear.control.eliminarDesarrollador(4),"",MessageBoxButton.OK);
                else
                {
                    if (tipoEmpleado == "recurso humano") ControladorVEditar_Crear.control.eliminarRecursoHumano();
                    else ControladorVEditar_Crear.control.eliminarServicioLimpieza();
                }

                Uri uri = new Uri("Vistas/VMenuBuscar.xaml", UriKind.Relative);
                NavigationService.Navigate(uri);
            }
        }

        private void comboTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (editando == false)
            {
                lblTitulo.Content = "Añadir: " + comboTipo.SelectedItem.ToString();
                if (comboTipo.SelectedItem.ToString() == "Desarrollador")
                {
                    tipoEmpleado = "Desarrollador";
                    lblVariable.Content = "Lenguajes:";
                    comboLenguaje.Visibility = System.Windows.Visibility.Visible;
                    txtVariable.Visibility = System.Windows.Visibility.Collapsed;
                }
                else
                {
                    if (comboTipo.SelectedItem.ToString() == "Recursos Humanos")
                    {
                        tipoEmpleado = "Recursos Humanos";
                        lblVariable.Content = "Funciones:";
                    }
                    else
                    {
                        tipoEmpleado = "Servicio de limpieza";
                        lblVariable.Content = "Area de limpieza:";
                    }
                    comboLenguaje.Visibility = System.Windows.Visibility.Collapsed;
                    txtVariable.Visibility = System.Windows.Visibility.Visible;
                }
            }
        }

        private void btnCambiar_Click(object sender, RoutedEventArgs e)
        {
            Uri fileUri = new Uri("https://picsum.photos/200/300?random=" + imgFlag);
            
            imgPerfil.Source = new BitmapImage(fileUri);
            imgFlag++;
        }

       

        
    }
}
