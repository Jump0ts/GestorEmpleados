﻿#pragma checksum "..\..\..\..\Vistas\VMenuBuscar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0B2EA78DB974E26C2FDEA0E9D7D6E244B782B335"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using GestorEmpleados.Vistas;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace GestorEmpleados.Vistas {
    
    
    /// <summary>
    /// VMenuBuscar
    /// </summary>
    public partial class VMenuBuscar : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\Vistas\VMenuBuscar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\Vistas\VMenuBuscar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdBDev;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\Vistas\VMenuBuscar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdBCleaner;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\Vistas\VMenuBuscar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rdBRH;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Vistas\VMenuBuscar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnadirEmpleado;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Vistas\VMenuBuscar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridEmpleados;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GestorEmpleados;component/vistas/vmenubuscar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vistas\VMenuBuscar.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbl = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.rdBDev = ((System.Windows.Controls.RadioButton)(target));
            
            #line 22 "..\..\..\..\Vistas\VMenuBuscar.xaml"
            this.rdBDev.Checked += new System.Windows.RoutedEventHandler(this.rdBDev_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.rdBCleaner = ((System.Windows.Controls.RadioButton)(target));
            
            #line 23 "..\..\..\..\Vistas\VMenuBuscar.xaml"
            this.rdBCleaner.Checked += new System.Windows.RoutedEventHandler(this.rdBCleaner_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.rdBRH = ((System.Windows.Controls.RadioButton)(target));
            
            #line 24 "..\..\..\..\Vistas\VMenuBuscar.xaml"
            this.rdBRH.Checked += new System.Windows.RoutedEventHandler(this.rdBRH_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnAnadirEmpleado = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\Vistas\VMenuBuscar.xaml"
            this.btnAnadirEmpleado.Click += new System.Windows.RoutedEventHandler(this.btnAnadirEmpleado_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.gridEmpleados = ((System.Windows.Controls.DataGrid)(target));
            
            #line 32 "..\..\..\..\Vistas\VMenuBuscar.xaml"
            this.gridEmpleados.Loaded += new System.Windows.RoutedEventHandler(this.gridEmpleados_Loaded);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\..\Vistas\VMenuBuscar.xaml"
            this.gridEmpleados.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.gridEmpleados_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

