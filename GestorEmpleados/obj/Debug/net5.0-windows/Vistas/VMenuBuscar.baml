   M S B A M L   `   `   `  ����J  FGestorEmpleados, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:GestorEmpleados.VistasGestorEmpleados.Vistas  5      (    "GestorEmpleados.Vistas.VMenuBuscar   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      AControls,http://metro.mahapps.com/winfx/xaml/controls     5      6local$clr-namespace:GestorEmpleados.Vistas     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  VMenuBuscar��5
      $	��575��6   $	��950��6(   .��5      � 
�������.+�5   
   #  MaterialDesignThemes.Wpf.Card  $
��Left=�6   $��46��69   $	��Top=�6E   $	��950��6]   ���	#FF000D95$��0,0,-1,0q�6�   .��5      �� -   5         ��Name$	 lbl��5      $��Buscar empleado��6!   $
��Left=�6;   $��10,0,0,0q�6V   $	��Top=�6h   $
��Bold"�6�   
�������$��Arial)�6�   $��27(�6�   5      � 5   
   $
��Left=�6   $	��529��6*   $	��Top=�67   $	��139��6O   $��0,46,0,0q�6[   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    � MappingMode$ RelativeToBoundingBox=�67    �� 
StartPoint$ 0.5,0&�6[   .��5      �  � Color$ 	#FF12131F��6#    � Offset$ 1Q�65   � 5      $ 	#FF000D95��6#   5      .+�5      	� -   5         	�Name$ rdBDev��5      $��Desarrolladores��6*   $
��Left=�6D   $��0,22,0,0q�6_   $	��Top=�6q   $��20��6�   $	��119��6�   
������� d� 	IsChecked$
 TrueY�6�   
�������6�   	� 5      -   5        $ 
rdBCleaner��5      $��Servicio de limpieza��6.   $
��Left=�6M   $��0,42,0,0q�6h   $	��Top=�6z   $��20��6�   $	��129��6�   
�������
�������6�   	� 5      -   5        $ rdBRH��5      $��Recursos humanos��6)   $
��Left=�6D   $��0,62,0,0q�6_   $	��Top=�6q   $��20��6�   $	��129��6�   
�������
�������6�   �� 5      -   5        	 ��Name$	 btnAnadirEmpleado��5      $��Añadir��60   $��Center=�6A   $��	0,104,0,0q�6^   $	��Top=�6q   $��28��6�   $��95��6�   ���	#FF673AB76�   5       &   System.Windows.Controls.DataGrid  5!   
   -   5        
  Name$
 gridEmpleados��5!      $��
139,46,0,0q�6*      CanUserSortColumns$ False��6>      CanUserAddRows$ False��6Y      CanUserDeleteRows$ False��6p      CanUserResizeRows$ False��6�      
IsReadOnly$
 True��6�   5#      5&      5'      